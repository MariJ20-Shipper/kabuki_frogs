using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{

    public PlayerController heroe;          //para poder acceder al entero vidas
    public GameObject barra_de_vida;        // para definir a quien animará
    private Animator anim;                  // para extraer el animator
    public const string ESTADO_VIDAS = "vidas";     //para no equivocarse escribiendo xd

    // Start is called before the first frame update
    void Start()
    {
        anim = barra_de_vida.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger(ESTADO_VIDAS, heroe.vidas);   //en el int llamado "vidas" del animator pondré el mismo valor que contenga el int vidas del personaje ;)
    }
}
