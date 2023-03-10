using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGunSpeed : SkillBase
{
    SkillManager skillManager;
    Gun gun;

    private void Awake()
    {
        skillManager = FindObjectOfType<SkillManager>();
        gun = FindObjectOfType<Gun>();
    }

    private void Start()
    {
        skillManager.gunTimeToAttackAmount++;
        gun.timeToAttack *= (float)(1 - 0.1 * skillManager.gunTimeToAttackAmount);
        Debug.Log(gun.timeToAttack);

    }

    private void OnDestroy()
    {
        skillManager.gunTimeToAttackAmount--;
        gun.timeToAttack *= (float)(1 + 0.1 * skillManager.gunTimeToAttackAmount);

    }


}
