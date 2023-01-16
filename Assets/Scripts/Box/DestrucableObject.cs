using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrucableObject : MonoBehaviour, IDamageable
{
    public void GetHit(int damage)
    {
        GetComponent<DropOnDestroy>().CheckDrop();
        Destroy(gameObject);
    }


}
