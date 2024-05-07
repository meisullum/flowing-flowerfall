using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAIPatrol : AIStateMachine
{

    float patrolInterval = 1f;
    Vector3 moveValue;

    public CreatureAIPatrol(CreatureAI creatureAI) : base(creatureAI) {} 
   
   public override void BeginState() {
        creatureAI.SetColorNormal();
    }
    
    public override void UpdateState() {
        
        if (timer > patrolInterval) {
            timer = 0;
            GenerateRandVal();
        }

        creatureAI.creature.MoveCreature(moveValue); // create a move method

        if (creatureAI.GetTarget() != null) {
            creatureAI.ChangeState(creatureAI.chaseState);
        }

    }

    void GenerateRandVal() {
        moveValue = new Vector3(Random.Range(-patrolInterval,patrolInterval),Random.Range(-patrolInterval,patrolInterval));
    }

}
