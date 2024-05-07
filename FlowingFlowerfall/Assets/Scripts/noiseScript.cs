using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; //remember to include this when working with tilemaps!

public class noiseScript : MonoBehaviour
{

    [Header("Config")]
    public float noiseScale = .1f;
    [SerializeField] public static int areaSize = 15; // og wa 25 
    private int[][] matrix = new int[areaSize][];

    List<Vector2Int> largestCluster;
    public Tilemap tilemap;
    public TileBase tile;


    public List<Vector2Int> getCluster() { // getter
        return largestCluster;
    }

    void Start(){
        ApplyNoise();
    }

    void ApplyNoise(){

        for (int i = 0; i < areaSize; i++)
        {
            matrix[i] = new int[areaSize];
            for (int j = 0; j < areaSize; j++)
            {
                matrix[i][j] = 0; // Initialize each element to 0
            }
        }

        int seed = Random.Range(0,10000); // adding random seed for different noise variation
        for(int x = 0; x<areaSize; x++){
            for(int y = 0; y<areaSize; y++){
                
                float perlinValue = Mathf.PerlinNoise((float)x*noiseScale + seed,(float)y*noiseScale + seed); //keep coordinates between 0 and 1
                
                if(perlinValue > .5f){
                    matrix[x][y] = 1;
                }
            }
        }

        FindLargestCluster(); // finding the largest cluster from the procedurally generated terrain
    }


    void FindLargestCluster()
    {
        int maxClusterSize = 0;
        largestCluster = new List<Vector2Int>();

        for (int x = 0; x < areaSize; x++) {
            
            for (int y = 0; y < areaSize; y++) {
                if (matrix[x][y] == 1) {
                    List<Vector2Int> currentCluster = new List<Vector2Int>();
                    int currentClusterSize = ExploreCluster(x, y, currentCluster);
                    
                    if (currentClusterSize > maxClusterSize) {
                        maxClusterSize = currentClusterSize;
                        largestCluster = currentCluster;
                    }
                }
            }
        }

        Debug.Log("Largest cluster: " + maxClusterSize); 
        foreach (Vector2Int point in largestCluster) // all the different points
        {
            tilemap.SetTile(new Vector3Int(point.x, point.y), tile); // set it on tile map
        }
    }

    int ExploreCluster(int x, int y, List<Vector2Int> currentCluster)
    {
        if (x < 0 || x >= areaSize || y < 0 || y >= areaSize || matrix[x][y] != 1)
        {
            return 0;
        }

        matrix[x][y] = -1; // mark as visited

        currentCluster.Add(new Vector2Int(x, y));

        int clusterSize = 1;
        clusterSize += ExploreCluster(x + 1, y, currentCluster);
        clusterSize += ExploreCluster(x - 1, y, currentCluster);
        clusterSize += ExploreCluster(x, y + 1, currentCluster);
        clusterSize += ExploreCluster(x, y - 1, currentCluster);

        return clusterSize;
    }
}
