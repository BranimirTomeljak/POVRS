using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TankAlive : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Tank") == null)
            StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene() {
		while (true) {
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene(2);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
		}
	}
}
