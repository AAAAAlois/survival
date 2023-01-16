using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseHUD : MonoBehaviour
{
    [SerializeField] Button mainmenuButton;
    [SerializeField] Button continueButton;

    private void Start()
    {
        mainmenuButton.onClick.AddListener(MainMenu);
        continueButton.onClick.AddListener(Continue);
    }

    void MainMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    void Continue()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
