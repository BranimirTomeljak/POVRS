using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementTarget : MonoBehaviour
{
    bool direct = false;
    Vector3 myVector;
    Vector3 myVector1;
    public float count = 0f;
    public float brojac = 0f;
    private bool nerotirano;

    public Transform target;
    public Camera cameraPOVRS;
    public Camera cameraEnd;
    
    public static int movespeed = 1;
    public Vector3 userDirection = Vector3.forward;

    void Awake(){
        //transform.rotation = new Vector3(0,0,0);
    }
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
        if(count < 700) {

                 myVector = new Vector3(0, 0, 2); 
                 count = count + 1f; 
                 Debug.Log(count);
                 brojac = 0f;
                 nerotirano = true;
            
        } else if (count >= 700 && count < 1400 ){
             
            count = count + 1f;
            Debug.Log(count);
            if (nerotirano) {
                
                Vector3 rotationToAdd = new Vector3(0, 90, 0);
                /* Quaternion objectRotation = target.transform.rotation;
                transform.rotation = objectRotation; */
                nerotirano = false;
            }
            myVector = new Vector3(1, 0, 0);
            
            //count = 0f;
        } else if (count >= 1400){
            brojac = brojac + 1f;
            myVector = new Vector3(0, 0, -2);
            if (brojac > 700) {
                count = 0f;
;           }
        }
        
                transform.Translate(myVector * movespeed * Time.deltaTime);
                //StartCoroutine( Order() );
                //transform.RotateAround (myVector, Vector3.up, 90);
    
    }

/*     IEnumerator Order()
{
   yield return new WaitForSeconds (2.0f);
   
}  */



    /* void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        
        //transform.LookAt(target, Vector3.left);
        naprijed();
        StartCoroutine( Order() );
        nazad();
        myVector1 = new Vector3(0, 0, -1);
        transform.Translate(myVector1 * movespeed * Time.deltaTime);
        //transform.LookAt(target);

        // Same as above, but setting the worldUp parameter to Vector3.left in this example turns the camera on its side
    }

    IEnumerator Order() {
        myVector1 = new Vector3(0, 0, -1);
        transform.Translate(myVector1 * movespeed * Time.deltaTime);
        yield return new WaitForSeconds (3.0f);
        
    }

    public void nazad() {
        myVector1 = new Vector3(0, 0, -1);
        transform.Translate(myVector1 * movespeed * Time.deltaTime);
    }

    public void naprijed() {
        myVector = new Vector3(0, 0, 1);
        transform.Translate(myVector * movespeed * Time.deltaTime);
    } */

    /* Vector2 GetRandomPosition() {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    } */

    /* private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Tank") {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void SurfaceAlignment() {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit info = new RaycastHit();
        if(Physics.Raycast(ray, out info, WhatIsGround)) {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, info.normal);
        }
    }  */
}
