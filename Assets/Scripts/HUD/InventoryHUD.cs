using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHUD : MonoBehaviour
{
    HUD hud;

    public Transform skillsParent;

    SkillSlot[] skillSlots;

    // Start is called before the first frame update
    void Start()
    {
        hud = FindObjectOfType<HUD>();


        skillSlots = skillsParent.GetComponentsInChildren<SkillSlot>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInventory();
    }

    public void UpdateInventory()
    {
        for(int i = 0; i < skillSlots.Length; i++)
        {
            if (i < hud.acquiredSkills.Count)
            {
                skillSlots[i].AddSkillToInventory(hud.acquiredSkills[i]);
                //Debug.Log("add skill slot");
            }
            else
            {
                //skillSlots[i].ClearSkill();
            }
        }
    }


}
