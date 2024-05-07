using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("bee")) {
            GameObject.Find("Scoreboard").GetComponent<ScoreScript>().RegisterHoneyComb();
            // this.gameObject.GetComponent<AudioSource>().enabled = true;
            // this.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}
