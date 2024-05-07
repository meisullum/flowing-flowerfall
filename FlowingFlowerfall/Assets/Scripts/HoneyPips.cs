using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPips : MonoBehaviour
{
    // Start is called before the first frame update
    public int valueHoney = -1;
    public GameObject honeyUIPrefab;
    public List<GameObject> honeyPips;

    public void AddHoneyPip() {
        if (valueHoney <= 4) {
            honeyPips.Add(Instantiate(honeyUIPrefab, transform)); // instantiating rose pip
            valueHoney++;
        }
    }

    public void RemoveHoneyPip() {
        if (honeyPips.Count > -1) {
            Destroy(honeyPips[valueHoney]);
            honeyPips.RemoveAt(valueHoney);
            valueHoney--;
        }
    }



}
