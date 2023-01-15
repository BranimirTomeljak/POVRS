using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorSimulator : MonoBehaviour
{
    public GameObject launcher;
    public ParticleSystem explosion;
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
            randomTime = Random.Range(1.0f, 3.0f);
            elapsedTime = 0;

            Vector3 randomSpawnPosition = launcher.transform.position;
            while(Vector3.Distance(randomSpawnPosition, launcher.transform.position) < 7.0f){
                randomSpawnPosition = new Vector3(Random.Range(launcher.transform.position.x - 60, launcher.transform.position.x + 60), 60, Random.Range(launcher.transform.position.z - 60, launcher.transform.position.z + 60));
            }            

            RaycastHit hit;
            if(Physics.Raycast(randomSpawnPosition, Vector3.down, out hit)){
                AudioSource.PlayClipAtPoint(explosionSound, hit.point);
                Instantiate(explosion, hit.point, Quaternion.identity);
            }
        }
    }
}
