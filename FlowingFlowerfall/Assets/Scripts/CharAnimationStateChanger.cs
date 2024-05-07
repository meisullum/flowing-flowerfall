using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimationStateChanger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;
    [SerializeField] private string currentState = "Still";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAnimationState(string newState) {
        
        if (currentState == newState) {
            return;
        }
        currentState = newState;
        animator.Play(currentState);
    }
}
