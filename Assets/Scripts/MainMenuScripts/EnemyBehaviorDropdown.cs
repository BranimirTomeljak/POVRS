using TMPro;
using UnityEngine;

public class EnemyBehaviorDropdown : MonoBehaviour
{

    [SerializeField] private TMP_Text numberText;
    public void DropownChoose(int index)
    {
        switch(index)
        {
            case 0: PlayerPrefs.SetString("enemyBehaviorSelected", "Neprijatelj statičan"); break;
            case 1: PlayerPrefs.SetString("enemyBehaviorSelected", "Neprijatelj dinamičan"); break;
            default: PlayerPrefs.SetString("enemyBehaviorSelected", "Neprijatelj statičan"); break;
        }
    }

}
