using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: attatch this to the "LevelSpawner" prefab
public class LevelSpawn : MonoBehaviour
{
    public int levelRoll;
    public GameObject[] gameLevels;
    public Transform Spawner;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "leveladd")
        {
            RandomGenerate();
            Debug.Log("leveladded");
            SpawnLevel();
        }

    }

    public void SpawnLevel()
    {
        Instantiate(gameLevels[levelRoll], Spawner.position, Spawner.rotation);

    }

    public void RandomGenerate()
    {
        levelRoll = Random.Range(1, 6);
    }
}
