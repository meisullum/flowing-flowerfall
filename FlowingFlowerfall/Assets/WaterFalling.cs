using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFalling : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject parentWater;
    [SerializeField] GameObject spawnedWater;

    // Update is called once per frame
    void Start()
    {
        WaterFall();
    }

    void WaterFall() {
        StartCoroutine(SpawnWaterRoutine());

        IEnumerator SpawnWaterRoutine() {
            while (true) {
                yield return new WaitForSeconds(.02f);
                SpawnWater();
            }
        }
    }

    void SpawnWater() {
        GameObject myWater = Instantiate(spawnedWater); // spawns in new water
        myWater.transform.position = parentWater.transform.position;
        Destroy(myWater,1);
    }


}
