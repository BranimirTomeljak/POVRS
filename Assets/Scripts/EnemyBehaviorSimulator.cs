using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorSimulator : MonoBehaviour
{
    
    void Awake()
    {
        if(PlayerPrefs.GetString("enemyBehaviorSelected") == "Neprijatelj statičan"){
            transform.GetComponent<Wander>().enabled = false;
        }
    }
}
