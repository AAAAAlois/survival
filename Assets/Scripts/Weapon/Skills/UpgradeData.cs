using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    SkillUpgrade,
    ItemUpgrade,
    SkillUnlock,
    ItemUnlock
}

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeType upgradeType;
    public string upgradeName;
    public Sprite upgradeIcon;
    public SkillData skillData;


}