using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPopScript : MonoBehaviour
{
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && anim != null)
        {
            anim.SetBool("Active", true);
        }
    }
}
