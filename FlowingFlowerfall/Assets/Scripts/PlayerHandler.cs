using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PlayerHandler : MonoBehaviour
{

    [SerializeField] Character myCharacter;
    [SerializeField] Tilemap tilemap;
    [SerializeField] TileBase water;
    WaterProjectiles waterBalls;

    
    // Start is called before the first frame update
    void Start() {

        waterBalls = myCharacter.GetComponent<WaterProjectiles>();

    }
    
    
    void Update() {
        
        Vector3 input = Vector3.zero;

        if (Input.GetKey(KeyCode.A)) {
            input.x += -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            input.x += 1;
        }
        if (Input.GetKey(KeyCode.W)) {
            input.y += 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            input.y -= 1;
        }

        if (Input.GetKeyDown(KeyCode.E)) {

            Debug.Log("Throw");
            // Camera.main.ScreenToWorldPoint launches projectiles at your mouse
            waterBalls.Launch(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        }
    
        myCharacter.MoveCreature(input);  // this aint working breh

    }

}
