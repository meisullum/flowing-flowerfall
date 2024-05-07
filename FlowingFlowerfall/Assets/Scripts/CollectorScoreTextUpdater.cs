using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectorScoreTextUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI collectorText;

    public void UpdateText(int givenFlowers, int randomNumberFlowers, int givenHoneyCombs, int randomNumberHoney) {
        collectorText.text = givenFlowers + " / " + randomNumberFlowers + "\n" + givenHoneyCombs + " / " + randomNumberHoney;
    }



}
