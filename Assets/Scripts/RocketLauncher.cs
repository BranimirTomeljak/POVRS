using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public Camera cameraPOVRS;
    public Camera cameraEnd;
    public GameObject rocketPrefab;
    public RaycastHit target;
    public float speed = 50f;

    private void Start(){
        cameraPOVRS.enabled = true;
        cameraEnd.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            target = new RaycastHit();
         
            if( Physics.Raycast( ray, out target, 3000 ) )
            {
                GameObject rocket = Instantiate(rocketPrefab, cameraPOVRS.transform.position, rocketPrefab.transform.rotation);
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
                cameraEnd.transform.position = new Vector3(target.transform.position.x + 25, target.transform.position.y + 25, target.transform.position.z + 25);
                cameraEnd.transform.LookAt(target.point);
                cameraEnd.enabled = true;
                cameraPOVRS.enabled = false;
            }

            if(target.transform.gameObject.tag == "Target" && PlayerPrefs.GetString("enemyBehaviorSelected") == "Neprijatelj dinamičan")
                rocket.transform.position += (target.transform.position - rocket.transform.position).normalized * speed * Time.deltaTime;
            else
                rocket.transform.position += (target.point - rocket.transform.position).normalized * speed * Time.deltaTime;
            rocket.transform.LookAt(target.point);
            yield return null;
        }
        
        Destroy(rocket);
    }
}
