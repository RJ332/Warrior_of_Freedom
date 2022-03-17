using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
     public GameObject[] followers; // A group of followers defined in the prefab editor
     public float spawnRate = 1.0f; //The frequency at which followers spawn.
     private float nextSpawn = 0.0f; //used to trigger the next spawn

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Make followers spawn on a countdown timer
        if (Time.time > nextSpawn) {
          nextSpawn = Time.time + spawnRate; // Trigger next spawn
          Debug.Log ("***next follower is ready!***");
          //Spawn the follower in the same place as the spawner
          GameObject piClone = Instantiate(followers[Random.Range(0, followers.Length)], transform.position, transform.rotation) as GameObject;
        }
    }
}
