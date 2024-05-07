using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBeeObstacle : MonoBehaviour
{
    
    [Header("Player Stats")]
    [SerializeField] public GameObject body;

    [SerializeField] int speed = 3;


    public CreatureAI myAI;

    [Header("Jump")]
    [SerializeField] LayerMask groundMask;
    Vector3 previousPosition;

    public void MoveCreature(Vector3 input) {

        transform.position += input * Time.deltaTime * speed;
        
        if (transform.position.x < previousPosition.x) { // flips if going other way
            body.transform.localScale = new Vector3(-1,1,1); // local scale allows you to keep body scale as 1 regardless of parent
        }
        
        else if (transform.position.x > previousPosition.x) {
            body.transform.localScale = new Vector3(1,1,1);
        }

        previousPosition = transform.position;

    }
    public void MoveCreatureToward(Vector3 target){
        Vector3 direction = target - transform.position;
        MoveCreature(direction.normalized);
    }
}
