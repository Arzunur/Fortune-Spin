using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public bool oyunDurdumu = false;
    private GameController gameController;
    public GameObject menuPanel;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void Start()
    {
        if (menuPanel)
             menuPanel.SetActive(false);
    }
    public void PaylinesMenu()
    {
        oyunDurdumu = !oyunDurdumu;
        if (menuPanel)
        {
            menuPanel.SetActive(oyunDurdumu);
        }
        if (oyunDurdumu)
        {
            Time.timeScale = 0; 
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void OpenMenu()
    {
        oyunDurdumu = true;
        if (menuPanel)
            menuPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseMenu()
    {
        oyunDurdumu = false;
        if (menuPanel)
            menuPanel.SetActive(false);
        Time.timeScale = 1; 
    }
    public void WheelPanel()
    {
        oyunDurdumu = false; 
        if (menuPanel)
            menuPanel.SetActive(false); 
        Time.timeScale = 1; // Oyun zamanini normale dondur
    }
}
