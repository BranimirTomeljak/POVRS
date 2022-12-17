using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollision : MonoBehaviour
{
    public GameObject target;
    void Awake()
    {
        target = GameObject.Find("Tank");
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.transform);
        if(collisionInfo.collider.tag == "Target"){
            Debug.Log("pogodio tenk!");

            Destroy(target);
        }
    }
}
