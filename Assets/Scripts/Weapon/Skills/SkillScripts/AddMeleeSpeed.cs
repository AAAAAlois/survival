using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMeleeSpeed : SkillBase
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
        skillManager.meleeTimeToAttackAmount++;
        melee.timeToAttack *= (float)(1+0.05*skillManager.meleeDamageAmount);

    }

    private void OnDestroy()
    {
        skillManager.meleeTimeToAttackAmount--;
        melee.timeToAttack *= (float)(1 - 0.05 * skillManager.meleeDamageAmount);

    }

}
