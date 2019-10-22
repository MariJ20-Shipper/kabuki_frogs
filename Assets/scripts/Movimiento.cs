using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public GameObject plataforma;        // plataforma que se moverá
    public Transform posicion_inicial;
    public Transform posicion_final;
    private Transform posicion_siguiente;   // el que hará de esto un loop
    public float velocidad;                 // ¿a qué velocidad de moverá la plataforma?

    // Start is called before the first frame update
    void Start()    {

        posicion_siguiente = posicion_inicial;    //siempre volverá
    }

    // Update is called once per frame
    void Update()
    {
        plataforma.transform.position = Vector2.MoveTowards(plataforma.transform.position, posicion_siguiente.position, Time.deltaTime * velocidad); //se moverá desde la posición que tiene actualmente hasta la posición siguiente a una velocidad establecida.

        if (plataforma.transform.position == posicion_siguiente.position)
        {
            posicion_siguiente = posicion_siguiente == posicion_final ? posicion_inicial : posicion_final; //la posición siguiente seguirá siendo igual a la inicial si esta es igual a la posición final, sino será igual a la final...
        }
    }
}
        