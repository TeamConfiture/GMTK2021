using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPeople : MonoBehaviour
{

    private float time = 0f;
    public float spawnFrequency = 1f;

    public GameObject[] characters;

    // Start is called before the first frame update
    void Start()
    {
    }


    public MovingCharacter SpawnCharacter(bool direction, int position)
    {
        int random = Random.Range(0, 4);
        GameObject newChar = Instantiate(this.characters[random]) as GameObject;
        MovingCharacter c = newChar.GetComponent<MovingCharacter>();
        c.direction = direction;

        Vector3 pos = new Vector3(10 * (direction ? -1 : 1), 0, 0);

      

        switch (position)
        {
            case 0: // Bas
                pos.y = -3.3f;
                pos.z = -3f;
                break;
            case 1: // Milieu
                pos.y = -0.75f;
                pos.z = -2f;
                break;
            case 2: // Haut
                pos.y = 1.3f;
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
