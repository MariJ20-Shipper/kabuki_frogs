using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
 
    public float velocidad=1f;
    public float velocidad_maxima=1f;
    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector2.right * velocidad);
        float limitedSpeed = Mathf.Clamp(rb.velocity.x, -velocidad_maxima, velocidad_maxima);
        rb.velocity = new Vector2(limitedSpeed, rb.velocity.y);

        if (rb.velocity.x>-0.01f && rb.velocity.x < 0.01f)
        {
            velocidad = -velocidad;
            rb.velocity = new Vector2(velocidad, rb.velocity.y);
        }
        if (velocidad<0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

        }
        else if (velocidad>0)
        {
            transform.localScale = new Vector3(-1f, 1f, -1f);
        }
    }
}
