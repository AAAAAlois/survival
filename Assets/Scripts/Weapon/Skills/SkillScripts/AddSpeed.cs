using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeed : SkillBase
{
    SkillManager skillManager;

    private void Awake()
    {
        skillManager = FindObjectOfType<SkillManager>();
    }

    private void Start()
    {
        skillManager.addSpeedAmount++;
    }

    private void OnDestroy()
    {
        skillManager.addSpeedAmount--;
    }

    public override void Attack()
    {
        
    }
}
