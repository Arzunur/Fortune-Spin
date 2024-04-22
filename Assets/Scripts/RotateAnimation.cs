using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RotateAnimation : MonoBehaviour
{
    public List<Image> symbols; 
    public const float rotationDuration = 1.0f; // donme animasyon süresi

    public void StartReel()
    {
        foreach (var symbol in symbols)
        {
            symbol.rectTransform.DORotate(symbol.rectTransform.rotation.eulerAngles + new Vector3(360.0f, 0, 0), rotationDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear);
        }
    }
}


