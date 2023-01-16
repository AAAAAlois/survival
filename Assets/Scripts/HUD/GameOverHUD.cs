using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHUD : MonoBehaviour
{
    [SerializeField] Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        SceneManager.LoadScene(1);
    }
}
