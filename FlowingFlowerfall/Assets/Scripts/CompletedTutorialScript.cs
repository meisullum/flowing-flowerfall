using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedTutorialScript : MonoBehaviour
{

    [SerializeField] Canvas canvas;
    [SerializeField] private ScoreScript scoreScriptController;


    // Start is called before the first frame update
    void Start()
    {
        CloseMenu();
    }

    // Update is called once per frame

    public void StartGame(){
        scoreScriptController.CanContinue(true);
        SceneManager.LoadScene("Level1");
    }

    public void GoBackToMenu(){

        SceneManager.LoadScene("MenuScreen");
    }

    public void CloseMenu() {

        canvas.enabled = false;
    }
}
