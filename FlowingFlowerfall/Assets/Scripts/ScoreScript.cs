using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI flowerCounterText;
    [SerializeField] private CongratulationsScript congratulationsScript;
    [SerializeField] private CollectorScoreTextUpdater collectorTextUpdaterController;
    [SerializeField] private RosePips rosePipController;
    [SerializeField] private HoneyPips honeyPipController;
    public int currentNumberFlowers = 0;
    public double currentHoneyCombs = 0f;
    public int givenFlowers = 0;
    public int givenHoneyCombs = 0;
    public int randomNumberHoney = 0;
    public int randomNumberFlowers = 0;
    [SerializeField] public int level = 1;
    [SerializeField] public int minFlowerRange = 5;
    [SerializeField] public int maxFlowerRange = 10;
    [SerializeField] public int minHoneyRange = 7;
    [SerializeField] public int maxHoneyRange = 14;
    [SerializeField] public int test;
    public bool cont = true;


    // flowerCounterText.text = "text";
    void Start()
    {
        test = PlayerPrefs.GetInt("CurrentLevel");
        Debug.Log("Current level: " + test);
        randomNumberFlowers = Random.Range(minFlowerRange,maxFlowerRange);
        randomNumberHoney = Random.Range(minHoneyRange,maxHoneyRange);
        UpdateText();

    }

    // can only steal 1 flower at a time
    public void BeeStealingFlower() {
        if (currentNumberFlowers > 0) {
            currentNumberFlowers--;
            rosePipController.RemoveRosePip(); // remove rose pip
        }
    }

    public void RegisterFlower() {
        
        if (currentNumberFlowers < 5) {
            currentNumberFlowers += 1;
            rosePipController.AddRosePip(); // add rose pip
            UpdateText();
        } // make the text highlight in bold for a couple seconds
    }

    public void RegisterCollector() {

        if (givenFlowers < randomNumberFlowers) {
            while (currentNumberFlowers > 0) {
                givenFlowers++;
                currentNumberFlowers--;
                rosePipController.RemoveRosePip(); // remove rose pip
                if (givenFlowers >= randomNumberFlowers) {
                    break;
                }
            }
        }

        if (givenHoneyCombs < randomNumberHoney) {
            Debug.Log("HONEY");
            while (currentHoneyCombs > 0 ) {
                givenHoneyCombs++;
                currentHoneyCombs--;
                honeyPipController.RemoveHoneyPip();
                if (givenHoneyCombs >= randomNumberHoney) {
                    break;
                }    
            }
        }
        // now, if the collector maxes out, go to the next level!
        // pretty sure there is way better logic for this ^
        UpdateText();

    }

    public void RegisterHoneyComb() {
        if (currentHoneyCombs < 5) {
            currentHoneyCombs += 1f;
            honeyPipController.AddHoneyPip();
        }
        UpdateText();
    }

    void UpdateText() {

        collectorTextUpdaterController.UpdateText(givenFlowers,randomNumberFlowers,givenHoneyCombs,randomNumberHoney);
        //flowerCounterText.text = "Flowers: " + currentNumberFlowers + " / 5\nHoney Combs: " + currentHoneyCombs + " / " + 5 +  "\nCollector: " + givenFlowers + " / " + randomNumberFlowers + "\n                " + givenHoneyCombs + " / " + randomNumberHoney;
        // add the update screenloader here i think
        if (randomNumberFlowers == givenFlowers && randomNumberHoney == givenHoneyCombs && cont) {
            level = PlayerPrefs.GetInt("CurrentLevel");
            level++; // Adding to the current level ++
            PlayerPrefs.SetInt("CurrentLevel", level); // Setting it to the current level
            if (level == 3) {
                // Have a pop up and end game
                PlayerPrefs.SetInt("CurrentLevel", 0);
                congratulationsScript.OpenMenu();
                // SceneManager.LoadScene("MenuScreen"); // end game at level 3
            }
            else {
                SceneManager.LoadScene("Level1"); // this does not work because it constantly attempts to do something
            }
        }

    }

    public void CanContinue(bool value) {
        cont = value;
    }

    public int GetMinFlowerRange() {
        return minFlowerRange;
    }

    public int GetGivenFlowers() {
        return givenFlowers;
    }
    public int GetGivenHoney() {
        return givenHoneyCombs;
    }

    public int GetCurrentFlowers() {
        return currentNumberFlowers;
    }

    public double GetCurrentHoney() {
        return currentHoneyCombs;
    }

}
