using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;


public class GameController : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject[] slotImages; // Slotlarý temsil eden resimler(image)
    public TextMeshProUGUI winText;

    public bool isSpinning = false; // Dönme durumu kontrolu


    public AudioSource audioSource;
    public AudioClip spinSound;

    public CashController cashController;
    public RotateAnimation rotateAnimation;
    public LineSystemManager lineSystemManager;
    public LineData lineData;
    public TransparencyImage transparencyImage;
    

    void Start()
    {
        transparencyImage.SetInitialTransparency(0.1f);
    }
    void AssignSpriteNames()
    {
        foreach (GameObject slotImage in slotImages)
        {
            Image img = slotImage.GetComponent<Image>();
            if (img != null && img.sprite != null)
            {
                string spriteName = img.sprite.name;
                //Debug.Log("Image üzerindeki sprite'ýn ismi: " + spriteName);
            }
            else
            {
                Debug.Log("Image bileþeni bulunamadý");
            }
        }
    }
    public void Spin()
    {
        if (!isSpinning) 
        {
            transparencyImage.RestoreTransparency();
            if (cashController.Cash < 1000) 
            {
                cashController.ActivateWheelPanel(); 
            }
            else
            {
                StartCoroutine(DelayedSpin()); // Yeterli cash varsa donusu baslat
            }
        }
    }
    private IEnumerator DelayedSpin()
    {
        isSpinning = true;
        yield return new WaitForSeconds(0.9f);

        SoundManager.Instance.PlaySpinSound();
        cashController.DeductCash();
        foreach (GameObject slotImage in slotImages)
        {
            int index = UnityEngine.Random.Range(0, sprites.Length);
            Image img = slotImage.GetComponent<Image>();
            if (img != null)
            {
                img.sprite = sprites[index]; // Image komponentindeki sprite'ý güncelle
            }
        }

        rotateAnimation.StartReel();
        AssignSpriteNames();
        CheckCombination();
        isSpinning = false;
    }
    void CheckCombination()
    {
        // Kombinasyonlar ve puanlar --- 30 Lýne
        foreach (var combo in lineData.combinations)
        {
            var indices = combo.indices;
            var points = combo.points;

            // Bu kombinasyon için sprite'larýn ayný olup olmadýðýný kontrol et
            if (IsSameSprite(indices))
            {
              //  winText.text = $"WIN:{points}";
                StartCoroutine(ShowWinAndReset(points));
                //Debug.Log($"Combination found: {String.Join(", ", indices)} Points: {points}");
                cashController.AddPoints(points);
                lineSystemManager.LineAnimation(indices);
                return;
            }
        }
        bool IsSameSprite(int[] indices)// Belirtilen indekslerdeki slotImages'in ayný sprite'a sahip olup- olmadigini kontrol etme islemi
        {
            if (indices.Length == 0) return true;

            Image firstImage = slotImages[indices[0]].GetComponent<Image>();
            if (firstImage == null || firstImage.sprite == null) return false;
            string firstSpriteName = firstImage.sprite.name;

            for (int i = 1; i < indices.Length; i++)
            {
                Image img = slotImages[indices[i]].GetComponent<Image>();
                if (img == null || img.sprite == null || img.sprite.name != firstSpriteName)
                {
                    return false;
                }
            }
            return true; // tum kontrol edilen sprite'lar ayniysa, true 
        }
    }
    IEnumerator ShowWinAndReset(int points)
    {
        winText.text = $"WIN: {points}";
        yield return new WaitForSeconds(2.0f);
        winText.text = "GOOD LUCK";
    }
}
