using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {

    float spawnTime = 2f;
    public GameObject enemy1;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        Invoke("Spawn", spawnTime);
	}
	
    void Spawn()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemy1, spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }

}
