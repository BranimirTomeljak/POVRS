using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    void Awake(){
        PlayerPrefs.SetFloat("fogDensityValue", 0f);
        PlayerPrefs.SetString("enemyBehaviorSelected", "Neprijatelj statičan");
    }

    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
