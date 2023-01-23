using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHUD : MonoBehaviour
{
    [SerializeField] Button closeButton;

    private void Start()
    {
        closeButton.onClick.AddListener(CloseSkillMenu);
    }

    public void CloseSkillMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("close skill");
    }
}
