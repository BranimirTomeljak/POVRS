using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorSimulator : MonoBehaviour
{
    public GameObject launcher;
    public ParticleSystem explosionElse;
    public AudioClip explosionSound;
    public float randomTime = 2.0f;
    public float elapsedTime = 0.0f;

    void Awake()
    {
        launcher = GameObject.Find("RocketSpawnPoint");

        if(PlayerPrefs.GetString("enemyBehaviorSelected") == "Neprijatelj statičan"){
            transform.GetComponent<Wander>().enabled = false;
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > randomTime && PlayerPrefs.GetString("enemyBehaviorSelected") == "Neprijatelj dinamičan"){
            randomTime = Random.Range(1.0f, 4.0f);
            Debug.Log("!!!!: " + randomTime);
            elapsedTime = 0;

            Vector3 randomSpawnPosition = launcher.transform.position;
            while(Vector3.Distance(randomSpawnPosition, launcher.transform.position) < 5.0f){
                randomSpawnPosition = new Vector3(Random.Range(launcher.transform.position.x - 30, launcher.transform.position.x + 30), 20, Random.Range(launcher.transform.position.z - 30, launcher.transform.position.z + 30));
            }            

            RaycastHit hit;
            if(Physics.Raycast(randomSpawnPosition, Vector3.down, out hit)){
                Debug.Log(hit.point);
                AudioSource.PlayClipAtPoint(explosionSound, hit.point);
                Instantiate(explosionElse, hit.point, Quaternion.identity);
            }
        }
    }
}
