using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillBase : MonoBehaviour
{
    public SkillData skillData;

    public SkillStats skillStats;

    public float timeToAttack = 1f;
    float timer;

    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0f)
        {
            Attack();
            timer = timeToAttack;
        }
    }

    public virtual void SetData(SkillData sd)
    {
        skillData = sd;
        timeToAttack = skillData.skillStats.timeToAttack;

        skillStats = new SkillStats(sd.skillStats.damage, sd.skillStats.timeToAttack);
    }

    public abstract void Attack();
}
