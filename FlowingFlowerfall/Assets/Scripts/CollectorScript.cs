using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectorScript : MonoBehaviour
{
    
    void OnMouseDown() {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked af");
            GameObject.Find("Scoreboard").GetComponent<ScoreScript>().RegisterCollector();
        }   
    }


}
