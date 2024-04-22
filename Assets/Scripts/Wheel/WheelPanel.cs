using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPanel : MonoBehaviour
{
    public bool panelOpenOff = false;

    public GameObject wheelPanel;
    private GameController gameController;
    private Vector3 startPosition;
    public void WheelPanelAcKapaFNC()
    {
        panelOpenOff = !panelOpenOff;
        if (wheelPanel)
        {
            wheelPanel.SetActive(panelOpenOff);
        }
    }
    public void ContinueGameFNC()
    {
        WheelPanelAcKapaFNC();
        Time.timeScale = 1;
        if (gameController != null)
        {
            gameController.transform.position = startPosition;
        }
    }
}
