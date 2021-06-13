using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupidonScript : MonoBehaviour
{

    public Animator anim;
    private AudioSource fleche;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        fleche = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("Cupidon");
            fleche.Play();
        }
    }
}
