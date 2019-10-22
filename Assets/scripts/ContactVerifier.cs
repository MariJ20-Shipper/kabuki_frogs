using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactVerifier : MonoBehaviour
{
    public PlayerController heroe;                     // lo hago para poder acceder al bool eje_x
    public ContactPoint2D contact_plat;                // lo hago para poder definir el Vector normal mas adelante
    private Vector2 eje_y;                             // vector normal al eje Y, con dirección negativa
    private Vector2 eje_y_positivo;                    
    private Vector2 eje_x_positivo;                    // vector normal al eje X, con dirección positiva
    private Vector2 normal;                            

    // Start is called before the first frame update
    void Start()
    {
        // doy valor a los vectores xd
       eje_y = new Vector2(-1f, 0f);
        eje_y_positivo = new Vector2(1f, 0f);
        eje_x_positivo = new Vector2(0f, 1f);
    
    }
    public void OnCollisionEnter2D(Collision2D coll)   // indica qué hará el personaje cuando empiece a tener una colision
    {
        //defino el punto de contacto y el vector normal
       contact_plat = coll.GetContact(0);
        normal = contact_plat.normal;
        Debug.Log(normal);     //verificador
    
       if (normal == eje_y)
        {
            heroe.eje_x = false;
        }
        else
        { if (normal == eje_y_positivo || normal == eje_x_positivo)
            {
                heroe.eje_x = false;
            }

            else
            {
                if (normal != eje_y || normal != eje_y_positivo || normal != eje_x_positivo)
                    heroe.eje_x = true;
            }
        
        }
                          
        // Debug.Log(contact_plat.point.x); // lo usé para verificar que si lo tomara
    }
    public void OnCollisionStay2D(Collision2D coll) // Indica que continuará haciendo el personaje
    {
        contact_plat = coll.GetContact(0);
        normal = contact_plat.normal;

        if (normal == eje_y)
        {
            heroe.eje_x = false;
        }
        else
        {
            if (normal == eje_y_positivo || normal == eje_x_positivo)
            {
                heroe.eje_x = false;
            }

            else
            {
                if (normal != eje_y || normal != eje_y_positivo || normal != eje_x_positivo)
                {
                    heroe.eje_x = true;
                }
            }

        }
    }
}
