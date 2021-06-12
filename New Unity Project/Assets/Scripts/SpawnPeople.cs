using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnPeople : MonoBehaviour
{

    private float time = 0f;
    public float spawnFrequency = 1f;
    public GameObject canvasObject;
    public GameObject[] characters;
    public GameObject[] lifes;
    private int hearts = 3;

    public EventSystem mySystem;
    private GameObject lastSelectedObject;
    // Start is called before the first frame update
    void Start()
    {
    }


    public MovingCharacter SpawnCharacter(bool direction, int position)
    {
        int random = Random.Range(0, 8);
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
        c.transform.SetParent(canvasObject.transform, false);
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => {
            Debug.Log(c.name);
            CheckMatch();
        });
        c.GetComponent<EventTrigger>().triggers.Add(entry);
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


    public void CheckMatch()
    {
        if (lastSelectedObject == null)
            lastSelectedObject = mySystem.currentSelectedGameObject;
        Debug.Log("Select & Checking Match..");

        if (mySystem.currentSelectedGameObject != lastSelectedObject)
        {
            Debug.Log("Last Selected : " + lastSelectedObject);
            Debug.Log("Current Selected : " + mySystem.currentSelectedGameObject);
            if (mySystem.currentSelectedGameObject.name.Substring(0,4) == lastSelectedObject.name.Substring(0, 4))
            {
                Debug.Log("Image Match !");
                UpdateBoardAfterSuccess();
            }
            else
            {
                Debug.Log("Images Not Matching");
                Animator animator = lifes[hearts - 1].GetComponent<Animator>();
                ResetBuffers();
                animator.Play("Life_destroy");
                Destroy(lifes[hearts - 1], animator.GetCurrentAnimatorStateInfo(0).length);
                hearts--;
                if (hearts <= 0)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
                }
            }
        }
    }

    void UpdateBoardAfterSuccess()
    {
        // I brutaly set the whole gameObject to unActive but you could just disable the image component
        lastSelectedObject.SetActive(false);
        mySystem.currentSelectedGameObject.SetActive(false);
        ResetBuffers();
    }

    void ResetBuffers()
    {
        lastSelectedObject = null;
        mySystem.SetSelectedGameObject(null);

    }
}
