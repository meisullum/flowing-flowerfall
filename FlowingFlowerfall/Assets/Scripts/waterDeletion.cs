using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class waterDeletion : MonoBehaviour
{
    [SerializeField] noiseScript myNoiseScript;
    [Header("Tile + Map assets")]
    public Tilemap tilemap;

    void Start()
    {
        StartCoroutine(deleteWater());    
    }

    IEnumerator deleteWater() {

        yield return new WaitForSeconds(.02f);
        waterDeleteOfficial();       
    }

    void waterDeleteOfficial() {
        
        List<Vector2Int> myCluster = myNoiseScript.getCluster();

        foreach (Vector2Int cluster in myCluster) {
            tilemap.SetTile(new Vector3Int(cluster.x, cluster.y), null);
        }
    }
}
