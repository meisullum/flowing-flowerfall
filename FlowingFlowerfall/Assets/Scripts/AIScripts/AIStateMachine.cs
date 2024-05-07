using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIStateMachine
{

    protected CreatureAI creatureAI; // AI bee creature
    protected float timer = 0;

    public AIStateMachine(CreatureAI myAI) {
        creatureAI = myAI; // attaching creatureAI to the specific creatureAI we have
        timer = 0;
    }

    // update the AIs state
    public void UpdateStateBase(){
        timer+=Time.fixedDeltaTime;
        UpdateState();
    }

    //When we start the state up
    public abstract void UpdateState();
    public abstract void BeginState();
  
}
