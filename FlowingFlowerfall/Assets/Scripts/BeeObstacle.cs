using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeObstacle : MonoBehaviour
{
    
    [Header("Player Stats")]
    [SerializeField] public GameObject body;

    [SerializeField] int speed = 3;
    

    public CreatureAI myAI;

    [Header("Jump")]
    [SerializeField] LayerMask groundMask;
    Vector3 previousPosition;

    public CreatureAISting stingState;


    void Start()
    {
        if (stingState == null) {
            StartCoroutine(DelayPosStart());
        }
        else {
            stingState = myAI.GetStingState();
        }
    }


    IEnumerator DelayPosStart() {
        yield return new WaitForSeconds(.25f); // since the delay is not quick enough, we will need to add a scene effect lolz
        stingState = myAI.GetStingState();
    }


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

    void OnTriggerEnter2D(Collider2D other) { // bee removal

        if (other.GetComponent<Character>() != null && stingState != null) {
            // audionoise
            GetComponent<AudioSource>().Play();
            // also add a state changer to this
            myAI.ChangeState(stingState); // YAY this worked!
            // Destroy(this.gameObject);
        }
        else if (other.GetComponent<Character>() != null) {
            GetComponent<AudioSource>().Play();
            Destroy(this.gameObject); // this works !
            // maybe make these 'unlucky bees' and they poison you?
        }
    }
}
