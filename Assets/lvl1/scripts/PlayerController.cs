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
    private Vector2 pos_o;
    public int vidas = 3;


    // Start is called before the first frame update
    void Start()
    {
        pos_o = this.transform.position;
        rb = GetComponent<Rigidbody2D>();                    // le indico al prograba que el personaje trabajará con las propiedades que tiene un rigidbody normalmente
        anim = GetComponent<Animator>();          // indico que el animator que afecta el rigidbody será utilizado en este script
    }

    private void OnCollisionEnter2D(Collision2D collider)   // indica qué hará el personaje cuando empiece a tener una colision
    {
        toco_piso = collider.gameObject.tag.Equals("piso");   //definimos cuándo son true los bool, dice que cuando está chocando con algo cuya etiqueta es piso.
        toco_movil = collider.gameObject.tag.Equals("plataforma_movil"); // true cuando está chocando con algo cuya etiqueta es plataforma_movil.

        if (toco_movil)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);   //la velocidad del personaje será 0 juuusto en el momento en que tocó la plataforma, sirve para la vertical pero está fallando en la horizontal.
            rb.transform.parent = collider.transform; //toma el movimiento de la plataforma
            Debug.Log(collider.transform);
        }
        if (collider.transform.tag.Equals("muerte"))
        {
            if (--vidas > 0)
            {
                this.transform.position = pos_o;
            }
            else
            {
                Debug.Log("ay me morí xd");
            }

        }
    }

    private void OnCollisionStay2D(Collision2D collider)
    {
        toco_piso = collider.gameObject.tag.Equals("piso");
        toco_movil = collider.gameObject.tag.Equals("plataforma_movil");

        if (toco_movil)
        {

            Debug.Log("Estoy en una plataforma móvil jijiji");  // imprimirá esto en la consola y me permite saber si esta función está ejecutandose correctamente.
            rb.transform.parent = collider.transform; //toma el movimiento de la plataforma.
        }

        if (toco_piso)
        {
            Debug.Log("Estoy tocando el piso -.-");
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("no estoy tocando nada jijiji");
        rb.transform.parent = null;

        if (toco_piso)
        {
            toco_piso = false;
        }

        if (toco_movil)
        {
            toco_movil = false;
        }
    }

    // Update is called once per frame

    void Update()

    {
       Vector2 FixedVelocity = rb.velocity;  //defino un vector igual al de la velocidad del rigidbody que es el héroe
        FixedVelocity.x *= 0.75f;   //  reasigno el valor en X, que al ser menor a 1 irá reduciendo la velocidad hasta llegar a 0

        if (toco_piso || toco_movil)
        {
            rb.velocity = FixedVelocity;
        }

        if (Input.GetKey(KeyCode.Space) && toco_movil) //si presiono W y toco_movil es true
        {
            rb.velocity = new Vector2(rb.velocity.x, altura_salto); // se moverá hacia arriba
            anim.SetInteger("Estado", 2);                          // animación -> salto                               // xd
        }

        else
        {
            if (Input.GetKey(KeyCode.W) && toco_movil) //si presiono W y toco_movil es true
            {
                rb.velocity = new Vector2(rb.velocity.x, altura_salto); // se moverá hacia arriba
                anim.SetInteger("Estado", 2);                          // animación -> salto                               // xd
            }
        }



        if (Input.GetKey(KeyCode.Space) && toco_piso) // hace lo mismo que el de arriba xd
        {
            rb.velocity = new Vector2(rb.velocity.x, altura_salto);
            anim.SetInteger("Estado", 2);
        }
        else
        {
            if (Input.GetKey(KeyCode.W) && toco_piso) // hace lo mismo que el de arriba xd
            {
                rb.velocity = new Vector2(rb.velocity.x, altura_salto);
                anim.SetInteger("Estado", 2);
            }
            else
            {

                if (Input.GetKey(KeyCode.D))
                {
                    rb.velocity = new Vector2(velocidad_mov, rb.velocity.y); //a qué velocidad se moverá (dirección y rapidez)
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
                        if (Input.GetKey(KeyCode.UpArrow) && toco_movil) //si presiono W y toco_movil es true
                        {
                            rb.velocity = new Vector2(rb.velocity.x, altura_salto); // se moverá hacia arriba
                            anim.SetInteger("Estado", 2);                          // animación -> salto                               // xd
                        }

                        if (Input.GetKey(KeyCode.UpArrow) && toco_piso) // hace lo mismo que el de arriba xd
                        {
                            rb.velocity = new Vector2(rb.velocity.x, altura_salto);
                            anim.SetInteger("Estado", 2);
                        }
                        else
                        {

                            if (Input.GetKey(KeyCode.RightArrow))
                            {
                                rb.velocity = new Vector2(velocidad_mov, rb.velocity.y); //a qué velocidad se moverá (dirección y rapidez)
                                rb.transform.localScale = new Vector2(1, 1); //cómo se ve el personaje
                                anim.SetInteger("Estado", 1);                   // la animación que está corriendo -> caminar

                            }

                            else
                            {

                                if (Input.GetKey(KeyCode.LeftArrow))
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
                }
            }

        }
    }
}