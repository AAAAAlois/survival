using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHp : SkillBase
{
    SkillManager skillManager;
    Character character;

    private void Awake()
    {
        skillManager = FindObjectOfType<SkillManager>();
        character = FindObjectOfType<Character>();
    }

    private void Start()
    {
        skillManager.addHpAmount++;
        character.maxHp += 100 * skillManager.addHpAmount;
        character.hpBar.SetState(character.currentHp, character.maxHp);
    }

    private void OnDestroy()
    {
        skillManager.addHpAmount--;
        character.maxHp += 100 * skillManager.addHpAmount;
        character.hpBar.SetState(character.currentHp, character.maxHp);
    }


}
