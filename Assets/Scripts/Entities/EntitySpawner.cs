using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour {

    [SerializeField]
    float timer = 5.0f;

    [SerializeField]
    List<GameObject> pool = new List<GameObject>();

    [SerializeField]
    int maxPoolSize = 5;

    [SerializeField]
    Transform spawnpointContainer;

    [SerializeField]
    Transform[] spawnpoints;

    [SerializeField]
    GameObject entity;

    [SerializeField]
    Transform goal;

    void Start() {
        Transform [] tempSpawnpointsArray = spawnpointContainer.GetComponentsInChildren<Transform>();
        spawnpoints = new Transform[tempSpawnpointsArray.Length - 1];
        for(int i = 0; i < tempSpawnpointsArray.Length; i++) {
            Transform spawnpoint = tempSpawnpointsArray[i];
            if (spawnpoint.gameObject != gameObject) {
                spawnpoints[i-1] = spawnpoint;
            }
        }

        StartCoroutine("SpawnTicker");
    }

    IEnumerator SpawnTicker() {
        while (enabled) {
            yield return new WaitForSeconds(timer);
            pool.RemoveAll(item => item == null);
            if(pool.Count < maxPoolSize) {
                Spawn();
            }
        }
    }

    void Spawn() {
        Transform spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Length)];

        GameObject newEnt = Instantiate<GameObject>(entity);

        Transform newEntTransform = newEnt.GetComponent<Transform>();

        newEntTransform.position = spawnpoint.position;
        newEntTransform.rotation = spawnpoint.rotation;

        newEntTransform.position += spawnpoint.up * 3;

        MoveTo moveTo = newEnt.GetComponent<MoveTo>();

        pool.Add(newEnt);

        if (moveTo != null) {
            moveTo.goal = goal;
        }
    }

}
