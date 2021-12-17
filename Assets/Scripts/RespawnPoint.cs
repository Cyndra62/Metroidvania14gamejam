using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public static RespawnPoint instance;
    public Transform respawnPoint;

    private void Awake()
    {
        instance = this;
    }
}
