using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aoiti.Pathfinding; //import the pathfinding library


public class Character : MonoBehaviour
{

    [Header("Player Stats")]
    [SerializeField] float health = 10.0f;
    [SerializeField] int speed = 3;

    [Header("Jump")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float jumpOffset = -.5f;
    [SerializeField] float jumpRadius = .25f;
    Rigidbody2D rb;


    // Start is called before the first frame update

    void Awake() {

        rb = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MoveCreature(Vector3 input) {
        transform.position += input * Time.deltaTime * speed;
    }

    public void Jump()
    {
        if(Physics2D.OverlapCircleAll(transform.position + new Vector3(0,jumpOffset,0),1f,groundMask).Length > 0){
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    public void MoveCreatureToward(Vector3 target){
        Vector3 direction = target - transform.position;
        MoveCreature(direction.normalized);
    }

}
