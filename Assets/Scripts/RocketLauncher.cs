using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject cameraPosition;
    public GameObject rocketPrefab;
    public GameObject spawnPosition;
    public RaycastHit target;
    public float speed = 20f;

    private void Start(){
        cameraPosition.transform.position = spawnPosition.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            target = new RaycastHit();
         
            if( Physics.Raycast( ray, out target, 999999 ) )
            {
                GameObject rocket = Instantiate(rocketPrefab, spawnPosition.transform.position, rocketPrefab.transform.rotation);
                rocket.transform.LookAt(target.point);
                StartCoroutine(SendHoming(rocket));
            }
        }
    }

    public IEnumerator SendHoming(GameObject rocket)
    {
        //ako je GameObject.Find("Tank") == null onda je tenk unisten u skripti RocketCollision.cs
        while(GameObject.Find("Tank") != null && Vector3.Distance(target.point, rocket.transform.position) > 0.3f)
        {
            if(target.transform.gameObject.tag == "Target" && Vector3.Distance(target.point, rocket.transform.position) < 25f){
                cameraPosition.transform.position = new Vector3(target.point.x + 15f, target.point.y + 15f, target.point.z + 15f);
                cameraPosition.transform.LookAt(target.point);
            }

            rocket.transform.position += (target.point - rocket.transform.position).normalized * speed * Time.deltaTime;
            rocket.transform.LookAt(target.point);
            yield return null;
        }
        
        Destroy(rocket);
    }
}
