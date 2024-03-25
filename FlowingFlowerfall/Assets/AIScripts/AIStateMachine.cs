using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIStateMachine
{

    protected CreatureAI creatureAI; // AI creature
    protected float timer = 0;

    public AIStateMachine(CreatureAI myAI) {
        creatureAI = myAI;
    }

    // update the AIs state
    public void UpdateStateBase(){
        timer+=Time.fixedDeltaTime;
        UpdateState();
    }

    //When we start the state up
    public abstract void UpdateState();
  
}
