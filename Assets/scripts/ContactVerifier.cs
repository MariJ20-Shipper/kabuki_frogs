using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactVerifier : MonoBehaviour
{
    public PlayerController heroe;
    public ContactPoint2D contact_plat;
    private Vector2 eje_y;
    private Vector2 eje_y_positivo;
    private Vector2 angle;
    private Vector2 normal;
    private float eje_float;

    // Start is called before the first frame update
    void Start()
    {
       eje_y = new Vector2(-1f, 0f);
        eje_y_positivo = new Vector2(1f, 0f);
    
    }
    public void OnCollisionEnter2D(Collision2D coll)   // indica qué hará el personaje cuando empiece a tener una colision
    {
        //defino punto de contacto
       contact_plat = coll.GetContact(0);
        normal = contact_plat.normal;
        Debug.Log(normal);
    
       if (normal == eje_y)
        {
            heroe.eje_x = false;
        }
        else
        { if (normal == eje_y_positivo)
            {
                heroe.eje_x = false;
            }

            else
            {
                heroe.eje_x = true;
            }
        
        }
                          
        // Debug.Log(contact_plat.point.x); // lo usé para verificar que si lo tomara
    }
    public void OnCollisionStay2D(Collision coll)
    {
        if (normal == eje_y)
        {
            heroe.eje_x = false;
        }
        else
        {
            if (normal == eje_y_positivo)
            {
                heroe.eje_x = false;
            }

            else
            {
                heroe.eje_x = true;
            }

        }
    }
}
