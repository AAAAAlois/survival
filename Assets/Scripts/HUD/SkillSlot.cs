using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    public Image icon;

    UpgradeData upgradeData;

    public void AddSkillToInventory(UpgradeData newUpgradeData)
    {
        upgradeData = newUpgradeData;

        icon.sprite = upgradeData.upgradeIcon;
    }

    public void ClearSkill()
    {
        upgradeData = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
