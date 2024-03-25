using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aoiti.Pathfinding; //import the pathfinding library

public class CreatureAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Character creature; // AI creature
    public Character targetCharacter; // target creature

    [Header("Config")]
    public LayerMask obstacles;
    public float sightDistance = 5;

    [Header("Pathfinding")]
    Pathfinder<Vector2> pathfinder;
    [SerializeField] float gridSize = 1f;

    AIStateMachine currState; // state machine

    public CreatureAIChase chaseState{get; private set;} // chasing state
    // public CreatureAIWander wanderState{get; private set;} // wander state

    // starts our different AI states
    void Start()
    {
        chaseState = new CreatureAIChase(this); // instantiating creature AI
        // wanderState = new CreatureAIWander(this);
        currState = chaseState; // turn it into chase state

        pathfinder = new Pathfinder<Vector2>(GetDistance,GetNeighbourNodes,2000); // Max number of iterations
    }

    // * updates frame by frame
    void FixedUpdate()
    {
        currState.UpdateStateBase(); //work the current state
        
    }

    // public void ChangeState(AIStateMachine newState) {
    //     currState = newState;
    //     currState.UpdateState;
    // }



    // Get my Creature Target
    public Character GetTarget(){
        //are we close enough?
        if(Vector3.Distance(creature.transform.position,targetCharacter.transform.position) > sightDistance){
            return null;
        }

        //is vision blocked by a wall?
        // RaycastHit2D hit = Physics2D.Linecast(creature.transform.position, targetCharacter.transform.position,obstacles);
        // if(hit.collider != null){
        //     return null;
        // }

        return targetCharacter;

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
        GetMoveCommand(targetCharacter.transform.position, ref path);

    }

}
