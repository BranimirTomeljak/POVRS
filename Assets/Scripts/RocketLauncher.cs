using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject spawnPosition;
    public GameObject target;
    public float speed = 20f;

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject rocket = Instantiate(rocketPrefab, spawnPosition.transform.position, rocketPrefab.transform.rotation);
            rocket.transform.LookAt(target.transform);
            StartCoroutine(SendHoming(rocket));
        }
    }

    public IEnumerator SendHoming(GameObject rocket)
    {
        //ako je GameObject.Find("Tank") == null onda je tenk unisten u skripti RocketCollision.cs
        while(GameObject.Find("Tank") != null && Vector3.Distance(target.transform.position, rocket.transform.position) > 0.3f)
        {
            rocket.transform.position += (target.transform.position - rocket.transform.position).normalized * speed * Time.deltaTime;
            rocket.transform.LookAt(target.transform);
            yield return null;
        }
        
        Destroy(rocket);
    }
}
