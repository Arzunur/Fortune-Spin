using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool oyunDurdumu = false;

    public GameObject pausePanel;
    private GameController gameController;
    private Vector3 startPosition;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }
    void Start()
    {
        if (pausePanel)
            pausePanel.SetActive(true); 
    }

    public void PausePanelAcKapaFNC()
    {
        oyunDurdumu = !oyunDurdumu;
        if (pausePanel)
        {
            pausePanel.SetActive(oyunDurdumu);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PausePanelAcKapaFNC();
        }
    }
    public void ContinueGameFNC()
    {
        PausePanelAcKapaFNC();
        Time.timeScale = 1;
        if (gameController != null)
        {
            gameController.transform.position = startPosition;
        }
    }
    public void HomeFNC()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu"); 
    }
}
