using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Items : ScriptableObject
{
    public string Name;
    public int armor;

    public void EquipItem(Character character)
    {
        character.armor += armor;
    }

    public void UnEquipItem(Character character)
    {
        character.armor -= armor;
    }
}
