using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAISting : AIStateMachine
{
    public CreatureAISting(CreatureAI creatureAI) : base(creatureAI) {} 

        public override void UpdateState() {}
        public override void BeginState() {
            creatureAI.AttemptSteal();
            creatureAI.SetGravity();
            creatureAI.Remove2DColliders(); // see if this works
            creatureAI.DisappearBee();
        }

}
