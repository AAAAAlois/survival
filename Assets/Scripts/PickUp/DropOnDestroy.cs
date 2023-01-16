using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject dropPickup;
    [SerializeField] [Range(0f, 1f)] float dropChance = 1f;

    bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void CheckDrop()
    {
        if (isQuitting) return; 

        if(Random.value < dropChance)
        {
            GameObject dropObject = Instantiate(dropPickup, transform.position, Quaternion.identity);
        }
    }
}
