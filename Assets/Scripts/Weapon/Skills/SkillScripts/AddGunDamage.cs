using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGunDamage : SkillBase
{
    SkillManager skillManager;
    Bullet bullet;

    private void Awake()
    {
        skillManager = FindObjectOfType<SkillManager>();
        bullet = FindObjectOfType<Bullet>();
    }

    private void Start()
    {
        skillManager.gunDamageAmount++;
        bullet.bulletDamage += skillManager.gunDamageAmount;

    }

    private void OnDestroy()
    {
        skillManager.gunDamageAmount--;
        bullet.bulletDamage -= skillManager.gunDamageAmount;

    }


}