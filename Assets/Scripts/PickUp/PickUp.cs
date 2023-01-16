using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character player = collision.gameObject.GetComponent<Character>();
        if (player != null)
        {
            GetComponent<IPickUpObject>().OnPickUp(player);
            Destroy(gameObject);
        }

    }
}
