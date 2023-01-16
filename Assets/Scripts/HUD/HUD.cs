using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject skillUI;

    [SerializeField] TextMeshProUGUI timeCounter;
  

    float timer = 0.0f;
    float lastUITime = 0.0f;

    private void Update()
    {
        CountTime();
        ShowSkillUI();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseUI.activeInHierarchy == false)
            {
                pauseUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    void CountTime()
    {

        timer += Time.deltaTime;


        int hour = (int)timer / 3600;
        int minute = (int)(timer - hour * 3600) / 60;
        int second = (int)(timer - hour * 3600 - minute * 60);

        if (hour == 0)
        {
            timeCounter.text = "Time: "+ minute.ToString("D2") + ":" + second.ToString("D2") ;
        }
        else
        {
            timeCounter.text = "Time: " + hour.ToString("D2") + ":" + minute.ToString("D2") + second.ToString("D2");
        }

    }

    void ShowSkillUI()
    {
        float currentTime = Time.time;

        if (currentTime - lastUITime > 10)
        {
            skillUI.SetActive(true);
            Time.timeScale = 0f;
            lastUITime = currentTime;
        }
    }


}
