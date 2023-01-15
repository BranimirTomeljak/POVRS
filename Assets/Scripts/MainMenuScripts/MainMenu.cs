using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    void Awake(){
        PlayerPrefs.SetFloat("fogDensityValue", 0f);
        PlayerPrefs.SetString("enemyBehaviorSelected", "Neprijatelj statičan");
    }

    public void PlayGame(){
        SceneManager.LoadScene(1);        
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ReturnToMainMenu(){
        SceneManager.LoadScene(0);
    }
}
