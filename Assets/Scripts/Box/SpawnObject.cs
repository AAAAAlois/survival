using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
    [SerializeField] [Range(0f, 1f)] float probability;

    public void spawn()
    {
        if (Random.value < probability)
        {
            GameObject spawn = Instantiate(toSpawn, transform.position, Quaternion.identity);
            //spawn.transform.parent = transform;
        }
    }
}
