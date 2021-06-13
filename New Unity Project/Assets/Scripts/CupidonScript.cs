using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupidonScript : MonoBehaviour
{

    public Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("Cupidon");
        }
    }
}
