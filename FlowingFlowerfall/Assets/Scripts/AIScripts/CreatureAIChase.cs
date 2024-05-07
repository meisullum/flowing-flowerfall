using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAIChase : AIStateMachine
{
    
    public CreatureAIChase(CreatureAI creatureAI) : base(creatureAI) {} // using abstract classes
    
    public override void BeginState() {
        creatureAI.SetColorAttack();
    }
    public override void UpdateState() {

        if (creatureAI.GetTarget() != null) {
            creatureAI.creature.MoveCreatureToward(creatureAI.GetTarget().transform.position);
        }
        else {
            creatureAI.ChangeState(creatureAI.patrolState);
        }
    }
}
