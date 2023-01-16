using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMove playerMove;
    public static GameManager instance;

    public Transform playerTransform;

    void Awake()
    {
        instance = this;
    }


}
