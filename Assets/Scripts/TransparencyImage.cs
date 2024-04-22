using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparencyImage : MonoBehaviour
{
    public List<Image> images;
    private int count;

    public const float fadeDuration = 0.8f; // Animasyon s�resi

    private void Start()
    {
        count = images.Count; // Her d�ng�de tekrar hesaplanmak yerine bir kere hesaplan�p saklanacak
    }

    public void SetInitialTransparency(float alpha = 0.1f)
    {
        foreach (var image in images)
        {
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }
    }

    public void RestoreTransparency()
    {
        foreach (var image in images)
        {
            image.DOFade(1f, fadeDuration).SetEase(Ease.InOutQuad);
        }
    }
}
