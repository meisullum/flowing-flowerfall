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

    public void RegisterFlower() {
        
        if (currentNumberFlowers < 5) {
            currentNumberFlowers += 1;
            UpdateText();
        } // make the text highlight in bold for a couple seconds
    }

    public void RegisterCollector() {

        if (givenFlowers < randomNumberFlowers) {
            while (currentNumberFlowers > 0) {
                givenFlowers++;
                currentNumberFlowers--;
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
        }
        UpdateText();
    }

    void UpdateText() {
        flowerCounterText.text = "Flowers: " + currentNumberFlowers + " / 5\nHoney Combs: " + currentHoneyCombs + " / " + 5 +  "\nCollector: " + givenFlowers + " / " + randomNumberFlowers + "\n                " + givenHoneyCombs + " / " + randomNumberHoney;
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
