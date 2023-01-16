using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperiencePickUp : MonoBehaviour,IPickUpObject
{
    [SerializeField] int experience = 100;

    public void OnPickUp(Character character)
    {
        character.AddExperience(experience);
    }
}
