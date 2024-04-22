using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LineSystemManager : MonoBehaviour
{
    public GameObject[] slotObjects; 
    private Vector3 startingScale; // Baslangýctaki ölçek deðeri
    private Transform[] slotTransforms;
    private const float maxScale = 1.3f;
    private const float scaleDuration = 0.5f; // Animasyon süresi
    private const float resetSlotDelay = 2f;

    private void Start()
    {
        startingScale = slotObjects[0].transform.localScale; 
        slotTransforms = new Transform[slotObjects.Length];
        for (int i = 0; i < slotObjects.Length; i++)
        {
            slotTransforms[i] = slotObjects[i].transform;
        }
    }
    public void LineAnimation(int[] lineSlots)
    {
        foreach (int index in lineSlots)
        {
            slotTransforms[index].DOScale(startingScale * maxScale, scaleDuration);
        }
        StartCoroutine(ResetSlotSizes(lineSlots));
    }
    private IEnumerator ResetSlotSizes(int[] winningSlots)//baþlangýç deðerine dondurme islemi
    {
        yield return new WaitForSeconds(resetSlotDelay);

        foreach (int index in winningSlots)
        {
            slotTransforms[index].DOScale(startingScale, scaleDuration);
        }
    }
}


