using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas canvas;
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private FlowerGrowth flowerPrefabController;
    [SerializeField] private ScoreScript scoreScriptController;
    [SerializeField] public GameObject flowerPrefab;
    [SerializeField] public GameObject tutorialBeeObject;

    public int textCount = 0;
    void Start()
    {
        scoreScriptController.CanContinue(false);
        flowerPrefab.SetActive(false);
        tutorialBeeObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            UpdateText();
        }
        if (flowerPrefabController.isHarvestable() == true && textCount == 6) {
            UpdateText();
        }
        if (textCount == 7 && scoreScriptController.GetCurrentFlowers() == 1) {
            UpdateText();
        }
        if (textCount == 8 && scoreScriptController.GetGivenFlowers() == 1) {
            UpdateText();
        }
        // if (textCount == 11 && scoreScriptController.GetCurrentHoney() > 0) {
        //     //return
        //     return;
        // }
        if (scoreScriptController.GetGivenHoney() == 1) {
            UpdateText();
        }

        if (scoreScriptController.GetGivenHoney() == 1 && scoreScriptController.GetGivenFlowers() == 1) {
            canvas.enabled = true; // enable canvas!
        }
    }

    void UpdateText() {
        if (textCount == 6 && flowerPrefabController.isHarvestable() == false) {
            return;            
        }
        if (textCount == 7 && scoreScriptController.GetCurrentFlowers() == 0) {
            return;
        }
        if (textCount == 8 && scoreScriptController.GetGivenFlowers() == 0) {
            return;
        }
        if (textCount == 11 && scoreScriptController.GetCurrentHoney() == 0) {
            return;
        }
        if (textCount == 12 && scoreScriptController.GetGivenHoney() == 0) {
            return;
        }
        textCount++;
        switch(textCount) {
            case 1: tutorialText.text = "Amazing! Let's get started with controls. You will use your a,w,s,d keys to move";
                break;
            case 2: tutorialText.text = "Nice job! The goal of the game is to grab items the collector on the top left requests..";
                break;
            case 3: tutorialText.text = "The scoreboard on the left will show you the number of flowers you can hold at a time and the number of items the collector wants";
                break;
            case 4: tutorialText.text = "main items include flowers and honey combs that you receive";
                break;
            case 5: tutorialText.text  = "To collect flowers, you must first water them to grow them!";
                break;
            case 6: tutorialText.text = "Walk over to the right hand side bud and start watering it. Make sure your water is hitting the bud";
                flowerPrefab.SetActive(true);
                break;
            case 7: tutorialText.text = "Fantastic! Now left click the flower and bring it to the collector.";
                // detect when player actually collects flower
                break;
            case 8: tutorialText.text = "Now, left click on the collector to give it the flower!";
                break;
            case 9: tutorialText.text = "Around your island, bees will spawn, such as the one on the left!";
                // activate bee here
                tutorialBeeObject.SetActive(true);
                break;
            case 10: tutorialText.text = "Bees will try to take your flowers and turn red when they become hostile and chase you!";
                if (tutorialBeeObject != null) {
                    tutorialBeeObject.GetComponent<SpriteRenderer>().color =  new Color(255f / 255f, 73f / 255f, 73f / 255f);
                }
                break;
            case 11: tutorialText.text = "To heal the bees' hostility, you must show them love. Press \"E\" and aim your mouse at the bee to shoot a heart at them!";
                break;
            case 12: tutorialText.text = "Great job! Bees drop a random number of honey combs. Now bring the honey comb to the collector!";
                break;
            case 13: tutorialText.text = "You have completed the tutorial! Are you ready to play?";
                break;// pop up another canvas that gives them option to go to main memory or start the game
        }
    }

}
