using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barracksSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPoint;

    public void spawn()
    {
        Debug.Log("Spawn Unit");
    }
}
