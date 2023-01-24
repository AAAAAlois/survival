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
    public int experienceSpeedAmount;
    public int meleeDamageAmount;
    public int meleeTimeToAttackAmount;
    public int gunDamageAmount;
    public int gunTimeToAttackAmount;


    private void Start()
    {
        //AddSkill(skillData);

        addSpeedAmount = 0;
        addHpAmount = 0;
        experienceSpeedAmount = 0;
        meleeDamageAmount = 0;
        meleeTimeToAttackAmount = 0;
        gunDamageAmount = 0;
        gunTimeToAttackAmount = 0;
    }

    public void AddSkill(SkillData skillData)
    {
        GameObject skillObject = Instantiate(skillData.weaponBasePrefab, skillContainer);

        skillObject.GetComponent<SkillBase>().SetData(skillData);
    }
}
