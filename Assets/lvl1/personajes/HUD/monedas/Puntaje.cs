using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public GameObject decenas, unidades;
    public PlayerController heroe;
    private string[] estados = { "Estado_00", "Estado_01", "Estado_02", "Estado_03", "Estado_04", "Estado_05", "Estado_06", "Estado_07", "Estado_08", "Estado_09" };
    private Animator de;
    private Animator un;

    void Start ()
    { 
    de=decenas.GetComponent<Animator>();
    un = unidades.GetComponent<Animator>();

    ActualizarContador(heroe.Puntaje);
    }

    void Update()
    {

    }

    public void ActualizarContador(int numero)
    {

        int unidades = numero % 10;
        int decenas = numero % 100 - unidades;
        Debug.Log("Decenas" + decenas / 10 + "Unidades" + unidades);
        decenas = decenas / 10;

        if (numero > 9)
        {
            //Hay Decenas
            de.Play(estados[decenas]);
        }
        else
        {
            de.Play(estados[0]);

        }
        un.Play(estados[unidades]);
    }
}


