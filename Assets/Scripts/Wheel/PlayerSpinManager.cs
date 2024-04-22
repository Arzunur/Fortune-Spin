using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerSpinManager : MonoBehaviour
{
    public List<WheelSlice> wheelSlices;
    public CashController cashController;
    public TextMeshProUGUI odulTxt;

    void Start()
    {
        if (cashController == null)
        {
            cashController = FindObjectOfType<CashController>();
        }
    }

    public void Award(int sliceIndex)
    {
        if (sliceIndex < wheelSlices.Count)
        {
            int value = wheelSlices[sliceIndex].value;
            //Debug.Log("Kazanýlan Puan: " + value);
            cashController.AddPoints(value);
        }
    }

}

