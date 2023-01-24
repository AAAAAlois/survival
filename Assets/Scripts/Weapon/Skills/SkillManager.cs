using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] Transform skillContainer;
    [SerializeField] SkillData skillData;

    private void Start()
    {
        //AddSkill(skillData);
    }

    public void AddSkill(SkillData skillData)
    {
        GameObject skillObject = Instantiate(skillData.weaponBasePrefab, skillContainer);

        skillObject.GetComponent<SkillBase>().SetData(skillData);
    }
}
