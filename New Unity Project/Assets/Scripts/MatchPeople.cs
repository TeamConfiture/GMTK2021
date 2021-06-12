using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class MatchPeople : MonoBehaviour
{
    public EventSystem mySystem;
    public Selectable[] selectables;
    private GameObject lastSelectedObject;

    void Start()
    {
        selectables = Selectable.allSelectablesArray;
    }

    public void CheckMatch()
    {
        if (lastSelectedObject == null)
            lastSelectedObject = mySystem.currentSelectedGameObject;
        Debug.Log("Select & Checking Match..");

        if (mySystem.currentSelectedGameObject != lastSelectedObject)
        {
            Debug.Log ("Last Selected : " + lastSelectedObject);
            Debug.Log("Current Selected : " + mySystem.currentSelectedGameObject);
            if (mySystem.currentSelectedGameObject.name == lastSelectedObject.name)
            {
                Debug.Log("Image Match !");
                UpdateBoardAfterSuccess();
            }
            else
            {
                Debug.Log("Images Not Matching");
                ResetBuffers();
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