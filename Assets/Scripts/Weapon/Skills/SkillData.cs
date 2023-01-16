using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class SkillStats
{
    public int damage;
    public float timeToAttack;

    public SkillStats(int damage, float timeToAttack)
    {
        this.damage = damage;
        this.timeToAttack = timeToAttack;
    }
}


[CreateAssetMenu]
public class SkillData : ScriptableObject
{
    public string Name;
    public SkillStats skillStats;
    public GameObject weaponBasePrefab;

}


