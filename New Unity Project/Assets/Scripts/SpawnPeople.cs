using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeople : MonoBehaviour
{

    private float time = 0f;
    public float spawnFrequency = 1f;

    public GameObject myPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }


    public MovingCharacter SpawnCharacter(bool direction, int position)
    {
        GameObject newChar = Instantiate(this.myPrefab) as GameObject;
        MovingCharacter c = newChar.GetComponent<MovingCharacter>();
        c.direction = direction;

        Vector3 pos = new Vector3(10 * (direction ? -1 : 1), 0, 0);

      

        switch (position)
        {
            case 0:
                pos.y = -2.6f;
                pos.z = -3f;
                break;
            case 1:
                pos.y = 0.3f;
                pos.z = -2f;
                break;
            case 2:
                pos.y = 2.3f;
                pos.z = -1f;
                break;
        }

        c.transform.position = pos;

        return c;
    }

    // Update is called once per frame
    void Update()
    {
        if(time > spawnFrequency)
        {
            // spawn people
            bool direction = Random.Range(0f, 1f) > 0.5f;
            int position = (int)Random.Range(0f, 2.9999f);
            
            SpawnCharacter(direction, position);
            
            time = 0;
        }
        time += Time.deltaTime;
    }
}
