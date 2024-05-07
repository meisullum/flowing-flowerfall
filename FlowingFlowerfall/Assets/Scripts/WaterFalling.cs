using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFalling : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject parentWater;
    [SerializeField] GameObject spawnedWater;
    [SerializeField] public List<GameObject> numOfWater = new List<GameObject>();
    // private List<GameObject> newWater = new List<GameObject>();

    // Update is called once per frame
    void Start()
    {
        WaterFall();
    }

    void WaterFall() {
        StartCoroutine(SpawnWaterRoutine());

        IEnumerator SpawnWaterRoutine() {
            while (true) {
                yield return new WaitForSeconds(.08f); // .02 works perfectly
                    SpawnWater();
            }
        }
    }

    void SpawnWater() {

        GameObject myWater = Instantiate(spawnedWater); // spawns in new water
        myWater.transform.position = parentWater.transform.position;
        // numOfWater.Add(myWater);
        Destroy(myWater,.12f); // .12 works perfectly
    }


}
