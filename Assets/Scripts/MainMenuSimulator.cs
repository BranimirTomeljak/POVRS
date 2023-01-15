using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuSimulator : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Simulator"){
            SceneManager.LoadScene(0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
