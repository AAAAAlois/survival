using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    Character character;

    [SerializeField] List<Items> items;
    [SerializeField] Items armorTest;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Start()
    {
        Equip(armorTest);
    }

    public void Equip(Items itemToEquip)
    {
        if (items == null)
        {
            items = new List<Items>();
        }
        items.Add(itemToEquip);
        itemToEquip.EquipItem(character);
    }
}
