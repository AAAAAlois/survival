using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    [SerializeField] List<SpawnObject> spawnObjects;
    Collider2D collider2d;

    private void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area")) return;

        //Debug.Log("reposition");

        Vector3 playerPos = GameManager.instance.playerMove.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.playerMove.movementVector;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        //Debug.Log(playerDir.x+","+playerDir.y);

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX *60);
                    SpawnList(spawnObjects);
                }
                else if(diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 60);
                    SpawnList(spawnObjects);
                }
                break;

            //case "Enemy":
                //if (collider2d.enabled)
                //{
                    //transform.Translate(playerDir * 30 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f),0f));
               // }
                //break;
        }

    }

    void SpawnList(List<SpawnObject> spawnObjects)
    {
        for (int i = 0; i < spawnObjects.Count; i++)
        {
            spawnObjects[i].spawn();
        }
    }
}
