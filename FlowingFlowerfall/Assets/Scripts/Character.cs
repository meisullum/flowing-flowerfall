using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aoiti.Pathfinding; //import the pathfinding library
using UnityEngine.Tilemaps;



public class Character : MonoBehaviour
{

    [Header("Player Stats")]
    [SerializeField] private GameObject body;
    [SerializeField] private List<CharAnimationStateChanger> animationStateChangers;

    // [SerializeField] float health = 10.0f;
    [SerializeField] int speed = 3;

    [SerializeField] noiseScript myNoiseScript; // using noise script methods


    Vector3 previousPosition;

    Rigidbody2D rb;


    // Start is called before the first frame update

    void Awake() {

        // spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        StartCoroutine(DelayPosStart());
    }


    IEnumerator DelayPosStart() {
        yield return new WaitForSeconds(.1f); // since the delay is not quick enough, we will need to add a scene effect lolz
        SpawnPlayer();
    }

    void SpawnPlayer() {

        if (myNoiseScript != null) {
            List<Vector2Int> myCluster = myNoiseScript.getCluster();

        // Debug.Log("Hello");

        Debug.Log("Cluster count: " + myCluster.Count);

            if (myCluster.Count > 0) {
                int randomTile = Random.Range(0,myCluster.Count);
                Vector2Int spawnPosTile = myCluster[randomTile];
                Debug.Log("Spawn point: " + myCluster[randomTile]);
                Vector3 spawnPosition = new Vector3(spawnPosTile.x,spawnPosTile.y,0);
                transform.position = spawnPosition;
            }
        }        
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveCreature(Vector3 input) {

        // transform.position += input * Time.deltaTime * speed;
        
        rb.velocity = input * speed; // don't need time.deltatime
        if (input.x < 0) { // flips if going other way
            body.transform.localScale = new Vector3(-1,1,1); // local scale allows you to keep body scale as 1 regardless of parent
        }
        
        else if (input.x > 0) {
            body.transform.localScale = new Vector3(1,1,1);
        }

        previousPosition = transform.position;

        // animation
        if (input.x != 0 || input.y !=0 ) {
            foreach (CharAnimationStateChanger asc in animationStateChangers) {
                asc.ChangeAnimationState("Walking");
            }
        }
        else {
            foreach (CharAnimationStateChanger asc in animationStateChangers) {
                asc.ChangeAnimationState("Still");
            }
        }

    }

    public void MoveCreatureToward(Vector3 target){
        Vector3 direction = target - transform.position;
        MoveCreature(direction.normalized);
    }

}
