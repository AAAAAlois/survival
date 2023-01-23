using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class startHUD : MonoBehaviour
{
    [SerializeField] Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(startGame);

    }

    void startGame()
    {
        SceneManager.LoadScene(1);
    }
}
