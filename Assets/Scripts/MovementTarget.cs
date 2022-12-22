using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementTarget : MonoBehaviour
{
    /* public float minX;
    public float maxX;
    public float minY;
    public float maxY; */
  
   /*  Vector2 targetPosition;
    public float speed; */

    /* [SerializeField]
    private LayerMask WhatIsGround; */

    public static int movespeed = 1;
    public Vector3 userDirection = Vector3.back;
    // Start is called before the first frame update

    void Awake(){
        //transform.rotation = new Vector3(0,0,0);
    }
    void Start()
    {
        //targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        /* SurfaceAlignment();
        if((Vector2)transform.position != targetPosition) {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed = Time.deltaTime);
        } else {
            targetPosition = GetRandomPosition();
        } */

        transform.Translate(userDirection * movespeed * Time.deltaTime); 
    }

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
