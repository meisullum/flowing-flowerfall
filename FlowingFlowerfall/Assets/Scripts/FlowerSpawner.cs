using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] noiseScript myNoiseScript;
    [SerializeField] GameObject flowerPrefab;
    [SerializeField] private int numOfTotalFlowers = 0;
    [SerializeField] private int numOfExistingFlowers = 0;
    [SerializeField] int minFlowers = 3;
    [SerializeField] int maxFlowers = 10;
    // [SerializeField] int waterGrowth = 0;
    public List<GameObject> currentFlowers = new List<GameObject>();

    void Start()
    {
        Debug.Log("Hello from FlowerSpawner");
        numOfTotalFlowers = Random.Range(minFlowers, maxFlowers);
        StartCoroutine(OptimizationPoolCreator());
    }

    IEnumerator OptimizationPoolCreator() {

        yield return new WaitForSeconds(.0002f);
        while (numOfExistingFlowers < numOfTotalFlowers) {
            SpawnRandomFlowers();
            Debug.Log("Flower Created");
        }
    }

    public void OptimizationPoolSpawner(GameObject myFlowerObject) { // optimization pattern
        
        List<Vector2Int> myCluster = myNoiseScript.getCluster();
        int myRange = Random.Range(0, myCluster.Count);
        Vector2Int spawnPosFlower = myCluster[myRange]; // right now, flowers can spawn on one another. Look to change it.

        myFlowerObject.transform.position = new Vector3(spawnPosFlower.x, spawnPosFlower.y, 0); // moving the flower to a new place
    }

    void SpawnRandomFlowers () {

        List<Vector2Int> myCluster = myNoiseScript.getCluster();
        int myRange = Random.Range(0, myCluster.Count);
        Vector2Int spawnPosFlower = myCluster[myRange]; // right now, flowers can spawn on one another. Look to change it.
        
        Debug.Log("Spawned in Flower");
        GameObject newFlower = Instantiate(flowerPrefab,new Vector3(spawnPosFlower.x,spawnPosFlower.y,0),Quaternion.identity);
        currentFlowers.Add(newFlower); // every flower will be a gameobject and will have a position
        numOfExistingFlowers++;
    }

}
