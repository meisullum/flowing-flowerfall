using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{

    [SerializeField] Character myCharacter;
    // Start is called before the first frame update

    void Update() {
        
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.A)) {
            input.x += -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            input.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myCharacter.Jump();
            Debug.Log("Jump");
        }

        myCharacter.MoveCreature(input);

    }

}
