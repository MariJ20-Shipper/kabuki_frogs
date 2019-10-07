using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float altura_salto;
    public float velocidad_mov;
    private Rigidbody2D rb;
    private Animator anim;
    private bool toco_piso;
    private bool toco_movil;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }


    void OnCollisionEnter2D(Collision2D collider)
    {
        toco_piso = collider.gameObject.tag.Equals("piso");
        toco_movil = collider.gameObject.tag.Equals("plataforma_movil");

        //if (toco_movil)

       // {
            transform.parent = collider.transform; //toma el movimiento de la plataforma.

        //}
        // else
        // xd{
        //  transform.parent = null; 
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("no estoy tocando nada jijiji");
        toco_movil = false;
        transform.parent = null;
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && toco_movil) //si presiono W y toco_movil es true
        {
            rb.velocity = new Vector2(rb.velocity.x, altura_salto); // se moverá hacia arriba
            anim.SetInteger("Estado", 2);                          // animación -> salto
            toco_movil = false;                                 // xd
        }

        if (Input.GetKey(KeyCode.W) && toco_piso) // o sea queria meter el toco piso y el toco movil en el mismo codigo, todo esto arriba también pero no supe como xd
        {
            rb.velocity = new Vector2(rb.velocity.x, altura_salto);
            anim.SetInteger("Estado", 2);
            toco_piso = false;
        }
        else

          if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(velocidad_mov, rb.velocity.y); //a qué velocidad y hacia donde se moverá
                rb.transform.localScale = new Vector2(1, 1); //cómo se ve el personaje
                anim.SetInteger("Estado", 1);                   // la animación que está corriendo -> caminar
               
            }

            else
            {

                if (Input.GetKey(KeyCode.A))
                {
                    rb.velocity = new Vector2(-velocidad_mov, rb.velocity.y);
                    rb.transform.localScale = new Vector2(-1, 1);
                    anim.SetInteger("Estado", 1);
                }
                else
                {
                  anim.SetInteger("Estado", 0);
                }
            }
        }
    }
