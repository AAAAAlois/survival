using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] Transform skillContainer;
    [SerializeField] SkillData skillData;

    private void Start()
    {
        
    }

    private void AddSkill(SkillData skillData)
    {
        GameObject skillObject = Instantiate(skillData.weaponBasePrefab, skillContainer);
    }
}
