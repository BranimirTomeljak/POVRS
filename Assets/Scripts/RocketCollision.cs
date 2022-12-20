using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RocketCollision : MonoBehaviour
{
    public GameObject target;
    public GameObject launcher;
    public AudioClip explosionSound;
    public bool hit = false;
    
    void Awake()
    {
        target = GameObject.Find("Tank");
        launcher = GameObject.Find("RocketSpawnPoint");
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.transform);

        if(collisionInfo.collider.tag == "Target" && hit == false){
            //var soundPosition = new Vector3(target.transform.position.x + 15f, target.transform.position.y + 15f, target.transform.position.z + 15f);
            AudioSource.PlayClipAtPoint(explosionSound, launcher.transform.position);
            Debug.Log("pogodio tenk!");
            hit = true;
            Destroy(target);
        }
        else{
            AudioSource.PlayClipAtPoint(explosionSound, launcher.transform.position);
            Destroy(GameObject.Find("missile(Clone)"));
        }
    }
}
