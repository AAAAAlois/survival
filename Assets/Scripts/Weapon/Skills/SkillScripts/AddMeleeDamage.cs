using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMeleeDamage : SkillBase
{
    SkillManager skillManager;
    Melee melee;

    private void Awake()
    {
        skillManager = FindObjectOfType<SkillManager>();
        melee = FindObjectOfType<Melee>();
    }

    private void Start()
    {
        skillManager.meleeDamageAmount++;
        melee.meleeDamage += skillManager.meleeDamageAmount;
        
    }

    private void OnDestroy()
    {
        skillManager.meleeDamageAmount--;
        melee.meleeDamage -= skillManager.meleeDamageAmount;

    }


}