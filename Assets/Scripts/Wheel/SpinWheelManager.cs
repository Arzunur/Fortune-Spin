using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheelManager : MonoBehaviour
{
    private bool spinning;
    private const float CountdownDuration = 30f;
    private float countdown = CountdownDuration;
    private const int MinSpinDegree = 300; 
    private const int MaxSpinDegree = 1500; 
    private const int NumSlices = 15;       
    bool countdownActive;


    public Button spinButton;
    public TMP_Text countdownText;
    public List<AnimationCurve> animationCurves;
    public PlayerSpinManager playerSpinManager;

    void Start()
    {
        spinning = false;
        playerSpinManager = FindObjectOfType<PlayerSpinManager>();
        spinButton.onClick.AddListener(SpinWheel);
        countdownText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (countdownActive)
        {
            countdown -= Time.deltaTime;
            countdownText.text = Mathf.CeilToInt(countdown).ToString();

            if (countdown <= 0)
            {
                EndCountdown();
            }
        }
    }

    private void EndCountdown()
    {
        countdownText.gameObject.SetActive(false);
        spinButton.gameObject.SetActive(true);
        countdownActive = false;
    }

    public void SpinWheel()
    {
        if (!spinning)
        {
            int spinDegree = UnityEngine.Random.Range(MinSpinDegree, MaxSpinDegree);
            StartCoroutine(LerpFunction(2f));
            BeginCountdown();
        }
    }

    private void BeginCountdown()
    {
        spinning = true;
        countdownText.gameObject.SetActive(true);
        spinButton.gameObject.SetActive(false);
        countdown = CountdownDuration;
        countdownActive = true;
    }

    IEnumerator LerpFunction(float duration)
    {
        spinning = true;
        float time = 0;
        float startValue = transform.eulerAngles.z;
        int randomSlice = UnityEngine.Random.Range(0, 15); //15 dilim var
        float endValue = randomSlice * 24 + 4;
        endValue += 360 * UnityEngine.Random.Range(1, 4); 

        while (time < duration)
        {
            float valueToChange = Mathf.Lerp(startValue, endValue, animationCurves[0].Evaluate(time / duration));
            transform.eulerAngles = new Vector3(0, 0, valueToChange);
            time += Time.deltaTime;
            yield return null;
        }

        transform.eulerAngles = new Vector3(0, 0, endValue % 360);
        OdulVer();
        spinning = false;
    }

    void OdulVer()
    {
        float finalAngle = transform.eulerAngles.z % 360;
        int sliceIndex = (int)(finalAngle / (360f / NumSlices));
        playerSpinManager.Award(sliceIndex);
    }

}