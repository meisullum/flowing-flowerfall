using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aoiti.Pathfinding; //import the pathfinding library

public class CreatureAI : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Config")]
    [SerializeField] private ScoreScript flowerStealerScoreScriptCtrl;
    
    public BeeObstacle creature; // AI bee creature
    public string targetTag; // target creature
    private Character realTarget;
    
    public LayerMask obstacles;
    public float sightDistance = 6;
    public Color birthColor;

    [Header("Pathfinding")]
    Pathfinder<Vector2> pathfinder;
    [SerializeField] float gridSize = 1f;

    // AI State Machine Info.
    public CreatureAIChase chaseState{get; private set;} // chasing state
    public CreatureAIPatrol patrolState{get; private set;} // randomly flying around
    public CreatureAISting stingState{get; private set;} // sting state - when bee collides
    // starts our different AI states    
    AIStateMachine currState; // state machine

    void Start()
    {

        birthColor = creature.body.GetComponent<SpriteRenderer>().color;
        realTarget = GameObject.FindWithTag("Player").GetComponent<Character>(); // gets the target
        
        chaseState = new CreatureAIChase(this); // instantiating creature AI
        patrolState = new CreatureAIPatrol(this);
        stingState = new CreatureAISting(this);

        // currState = chaseState; // turn it into chase state
        pathfinder = new Pathfinder<Vector2>(GetDistance,GetNeighbourNodes,2000); // Max number of iterations
        
        ChangeState(patrolState); // each one should start off patroling 
    }

    public CreatureAISting GetStingState() {
        return stingState;
    }


    // * updates frame by frame
    void FixedUpdate()
    {
        if (currState != null) {
            currState.UpdateStateBase(); //work the current state
        }        
    }

    public void ChangeState(AIStateMachine newState) { // we first start with our patrol state
        currState = newState; // just changed your state
        newState.BeginState();
    }

    public Character GetTarget(){ // Get my Creature Target

        //are we close enough?
        if(Vector3.Distance(creature.transform.position,realTarget.transform.position) > sightDistance){
            return null;
        }

        return realTarget;
        //is vision blocked by a wall?
        // RaycastHit2D hit = Physics2D.Linecast(creature.transform.position, realTarget.transform.position,obstacles);
        // if(hit.collider != null){
        //     return null;
        // }
    }

    public void SetColorAttack() {
        creature.body.GetComponent<SpriteRenderer>().color = new Color(255f / 255f, 73f / 255f, 73f / 255f);
    }

    public void SetColorNormal() {
        creature.body.GetComponent<SpriteRenderer>().color = birthColor;
    }

    public void AttemptSteal() {

        GameObject.Find("Scoreboard").GetComponent<ScoreScript>().BeeStealingFlower();
    }

    public void SetGravity() {
        
        Rigidbody2D rb = creature.GetComponent<Rigidbody2D>();
        rb.gravityScale = .5f; // changing the gravity of it :D 
    }

    public void Remove2DColliders() {
        Collider2D[] myColliders = creature.GetComponents<Collider2D>(); // colliders == gone
        foreach (Collider2D collider in myColliders) {
            collider.enabled = false; // disables all the colliders found on object!
        }

    }

    public void DisappearBee() {
        StartCoroutine(BeePerish());
    }

    IEnumerator BeePerish() {
        yield return new WaitForSeconds(1);
        Destroy(creature.body);
    }

    // Pathfinding
    public float GetDistance(Vector2 A, Vector2 B)
    {
        return (A - B).sqrMagnitude; //Uses square magnitude to lessen the CPU time.
    }

    Dictionary<Vector2,float> GetNeighbourNodes(Vector2 pos)
    {
        Dictionary<Vector2, float> neighbours = new Dictionary<Vector2, float>();
        for (int i=-1;i<2;i++)
        {
            for (int j=-1;j<2;j++)
            {
                if (i == 0 && j == 0) continue;

                Vector2 dir = new Vector2(i, j)*gridSize;
                if (!Physics2D.Linecast(pos,pos+dir, obstacles))
                {
                    neighbours.Add(GetClosestNode( pos + dir), dir.magnitude);
                }
            }

        }
        return neighbours;
    }

    //find the closest spot on the grid to begin our pathfinding adventure
    Vector2 GetClosestNode(Vector2 target){
        return new Vector2(Mathf.Round(target.x/gridSize)*gridSize, Mathf.Round(target.y / gridSize) * gridSize);
    }

    public void GetMoveCommand(Vector2 target, ref List<Vector2> path) //passing path with ref argument so original path is changed
    {
        path.Clear();
        Vector2 closestNode = GetClosestNode(creature.transform.position);
        if (pathfinder.GenerateAstarPath(closestNode, GetClosestNode(target), out path)) //Generate path between two points on grid that are close to the transform position and the assigned target.
        {
            path.Add(target); //add the final position as our last stop
        }



    }

    //simple wrapper to pathfind to our target
    public void GetTargetMoveCommand(ref List<Vector2> path){
        GetMoveCommand(realTarget.transform.position, ref path);

    }

}
