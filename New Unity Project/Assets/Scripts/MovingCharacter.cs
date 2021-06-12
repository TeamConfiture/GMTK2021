using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCharacter : MonoBehaviour
{

    public float speed = 2f;
    public bool direction = true;


    private SpriteRenderer spriteRenderer ;


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();


        if (!direction)
        {
            spriteRenderer.flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime * (direction ? 1f : -1f)), transform.position.y, transform.position.z);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
