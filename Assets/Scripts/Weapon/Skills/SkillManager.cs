using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] Transform skillContainer;
    [SerializeField] SkillData skillData;

    [Header("Skill Amount")]
    public int addSpeedAmount;
    public int addHpAmount;


    private void Start()
    {
        //AddSkill(skillData);

        addSpeedAmount = 0;
        addHpAmount = 0;
    }

    public void AddSkill(SkillData skillData)
    {
        GameObject skillObject = Instantiate(skillData.weaponBasePrefab, skillContainer);

        skillObject.GetComponent<SkillBase>().SetData(skillData);
    }
}
