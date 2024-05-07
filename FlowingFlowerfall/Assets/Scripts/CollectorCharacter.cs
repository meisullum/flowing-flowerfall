using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public noiseScript myNoiseScript;
    [SerializeField] private GameObject pieceCollectorPrefab;
    void Start()
    {

        StartCoroutine(SpawnCollectorRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCollectorRoutine() {
        yield return new WaitForSeconds(.0002f);
        SpawnCollector();
    }

    void SpawnCollector() {
        List<Vector2Int> myCluster = myNoiseScript.getCluster();
        Vector2Int collectorSpawnPos = myCluster[1];
        GameObject pieceCollector = Instantiate(pieceCollectorPrefab, new Vector3(collectorSpawnPos.x, collectorSpawnPos.y, 0), Quaternion.identity);
    }
}
