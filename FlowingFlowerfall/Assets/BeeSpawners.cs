using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeSpawners : MonoBehaviour
{
    [SerializeField] private GameObject beePrefab;
    [SerializeField] private float spawnRange = 10;
    [SerializeField] private float spawnRangeY = 0;

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
                yield return new WaitForSeconds(5);
                SpawnBeesRandom();
            }
        }
    }

    void SpawnBeesRandom() {

        float randomX = Random.Range(-spawnRange,spawnRange);
        float randomY = Random.Range(-6,-2);

        GameObject newBee = Instantiate(beePrefab,new Vector3(randomX,randomY,0),Quaternion.identity); // spawns in new bees
        Destroy(newBee,30);
        //hello
    }
}
