using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{

    // Start is called before the first frame update
    public void Play(){
        PlayerPrefs.SetInt("CurrentLevel", 0); // everytime play is pushed, then 
        SceneManager.LoadScene("Level1");
    }

    public void Tutorial() {
        PlayerPrefs.SetInt("CurrentLevel", 0); // everytime play is pushed, then 
        SceneManager.LoadScene("TutorialScene");
    }

    public void Quit(){
        Application.Quit();
    }

}
