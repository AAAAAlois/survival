using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePickUp : MonoBehaviour,IPickUpObject
{
    public int experience = 100;
    SkillManager skillManager;

    public void OnPickUp(Character character)
    {
        skillManager = FindObjectOfType<SkillManager>();
        character.AddExperience(experience * (int)(1 + 0.08 * skillManager.experienceSpeedAmount));
        //Debug.Log((int)experience*(1 + 0.08 * skillManager.experienceSpeedAmount));
    }
}
