using UnityEngine;

public class StartPositioning : MonoBehaviour
{
    public TextAsset txtFile;
    void Awake()
    {
        GameObject tank = GameObject.Find("Tank");
        GameObject POVRS = GameObject.Find("POVRS");

        int num = Random.Range(0,10);
        string [] positions = txtFile.text.Split('\n');
        string [] row = positions[num].Split(',');

        tank.transform.position = new Vector3(float.Parse(row[0]), float.Parse(row[1]), float.Parse(row[2]));
        
        if(num == 0)
            POVRS.transform.position = new Vector3(float.Parse(row[3]), 0.4f, float.Parse(row[5]));
        else
            POVRS.transform.position = new Vector3(float.Parse(row[3]), float.Parse(row[4]), float.Parse(row[5]));

        POVRS.transform.LookAt(tank.transform);
    }
}
