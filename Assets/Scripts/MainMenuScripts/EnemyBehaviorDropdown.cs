using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class EnemyBehaviorDropdown : MonoBehaviour
{
    
    public static string enemyBehaviorSelected = "Neprijatelj statičan";

    [SerializeField] private TMP_Text numberText;
    public void DropownChoose(int index)
    {
        switch(index)
        {
            case 0: enemyBehaviorSelected = "Neprijatelj statičan"; break;
            case 1: enemyBehaviorSelected = "Neprijatelj dinamičan"; break;
            default: enemyBehaviorSelected = "Neprijatelj statičan"; break;
        }
    }

}
