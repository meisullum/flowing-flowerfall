using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tree;
    public GameObject plant;
    [SerializeField] int particleCounter = 0;

    void Start() {
        plant.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("balls") ) {
            particleCounter++;
            if (particleCounter == 2000) {
                growTree();
            }
        }
    }

    void growTree() {
        plant.SetActive(true);
    }

}
