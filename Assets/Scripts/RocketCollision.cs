using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RocketCollision : MonoBehaviour
{
    public Camera cameraPOVRS;
    public Camera cameraEnd;
    public GameObject target;
    public GameObject launcher;
    public AudioClip explosionSound;
    public AudioClip explosionSoundQuiet;
    public ParticleSystem explosionTank;
    public ParticleSystem explosionElse;
    public bool hit = false;
    
    void Awake()
    {
        cameraPOVRS = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        cameraEnd = GameObject.Find("Camera1").GetComponent<Camera>();
        target = GameObject.Find("Tank");
        launcher = GameObject.Find("RocketSpawnPoint");
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo.collider.transform);

        if(collisionInfo.collider.tag == "Target" && hit == false){
            AudioSource.PlayClipAtPoint(explosionSound, launcher.transform.position);
            Debug.Log("pogodio tenk!");
            hit = true;

            Instantiate(explosionTank, target.transform.position, Quaternion.identity);
            Destroy(target, 0.7f);
        }
        else{
            if(cameraEnd.enabled && collisionInfo.collider.tag != "Target"){    //u slucaju da se kamera pomakne, a ipak ne pogodi metu
                cameraPOVRS.enabled = true;
                cameraEnd.enabled = false;
            }
            
            if(collisionInfo.collider.name.StartsWith("Rock"))
                AudioSource.PlayClipAtPoint(explosionSound, launcher.transform.position);
            else
                AudioSource.PlayClipAtPoint(explosionSoundQuiet, launcher.transform.position);
            Instantiate(explosionElse, GameObject.Find("missile(Clone)").transform.position, Quaternion.identity);
            Destroy(GameObject.Find("missile(Clone)"));

            if(!collisionInfo.collider.name.StartsWith("Ground") && !collisionInfo.collider.name.StartsWith("Rock")){
                Destroy(collisionInfo.collider.gameObject);
            }
        }
    }
}
