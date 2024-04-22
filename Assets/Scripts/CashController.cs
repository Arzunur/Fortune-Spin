using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CashController : MonoBehaviour
{
    public TextMeshProUGUI cashText;

    [SerializeField] private int cash = 100000; //baslangýc miktari
    [SerializeField] private GameObject wheelPanel;

    public int Cash => cash;

    private void Start()
    {
        LoadCash();
        UpdateScoreText();  
    }

    public void DeductCash()
    {
        if (cash >= 1000)
        {
            cash -= 1000;
            SaveCash();
            UpdateScoreText();
        }
        else
        {
            wheelPanel.SetActive(true);
        }
    }
    public void ActivateWheelPanel()
    {
        wheelPanel.SetActive(true);
    }

    public void AddPoints(int points)
    {
        cash += points;
        SaveCash();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        cashText.text = " " + cash.ToString();
    }
    private void SaveCash()
    {
        PlayerPrefs.SetInt("Cash", cash);
        PlayerPrefs.Save();
    }
    private void LoadCash()
    {
        cash = PlayerPrefs.GetInt("Cash", 100000);
    }

}
