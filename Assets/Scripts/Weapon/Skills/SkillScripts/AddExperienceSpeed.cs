using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddExperienceSpeed : SkillBase
{
    SkillManager skillManager;



    private void Awake()
    {
        skillManager = FindObjectOfType<SkillManager>();

    }

    private void Start()
    {
        skillManager.experienceSpeedAmount++;
       

    }

    private void OnDestroy()
    {
        skillManager.experienceSpeedAmount--;
        
    }


}

