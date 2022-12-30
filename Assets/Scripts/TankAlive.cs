using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TankAlive : MonoBehaviour
{

    public GameObject target;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.Find("Tank");
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Tank") == null)
            StartCoroutine(Wait2seconds());
    }

    IEnumerator Wait2seconds () {
		while (true) {
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene(2);
		}
	}
}
