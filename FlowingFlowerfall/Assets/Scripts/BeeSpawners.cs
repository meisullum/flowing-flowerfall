using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawners : MonoBehaviour
{
    [SerializeField] private GameObject beePrefab;
    // [SerializeField] private float spawnRange = 10;
    // [SerializeField] private float spawnRangeY = 0;
    [SerializeField] public noiseScript myNoiseScript;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBees();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnBees() {

        StartCoroutine(SpawnBeesRoutine());
        IEnumerator SpawnBeesRoutine() {

            while(true) {
                yield return new WaitForSeconds(Random.Range(5,10));
                SpawnBeesRandom();
            }
        }
    }

    void SpawnBeesRandom() {

        List<Vector2Int> myCluster = myNoiseScript.getCluster();
        int myRange = Random.Range(0, myCluster.Count);
        Vector2Int spawnBeePos = myCluster[myRange]; // right now, flowers can spawn on one another

        GameObject newBee = Instantiate(beePrefab,new Vector3(spawnBeePos.x,spawnBeePos.y,0),Quaternion.identity); // spawns in new bees
        Destroy(newBee,30);
        //hello
    }
}
