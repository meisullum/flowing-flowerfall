using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosePips : MonoBehaviour
{
    // Start is called before the first frame update
    public int valueRoses = -1;
    public GameObject roseUIPrefab;
    public List<GameObject> rosePips;

    public void AddRosePip() {
        if (valueRoses <= 4) {
            rosePips.Add(Instantiate(roseUIPrefab, transform)); // instantiating rose pip
            valueRoses++;
        }
    }

    public void RemoveRosePip() {
        if (rosePips.Count > -1) {
            Debug.Log("RemovePip");
            Destroy(rosePips[valueRoses]);
            rosePips.RemoveAt(valueRoses);
            valueRoses--;
        }
    }



}
