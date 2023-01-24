using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    [SerializeField] Image icon;
    public int ButtonNumber;

    HUD hud;

    private void Start()
    {
        hud = FindObjectOfType<HUD>();


        
    }

    public void SetSkillData(UpgradeData upgradeData)
    {
        icon.sprite = upgradeData.upgradeIcon;
    }
}
