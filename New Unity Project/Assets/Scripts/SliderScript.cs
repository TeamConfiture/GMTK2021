using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    public void OnPointerDown(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                slider.value += 0.1f;
                break;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire1"))
        {
            slider.value += 0.1f;
        }


    }
}
