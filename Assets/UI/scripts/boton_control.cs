using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton_control : MonoBehaviour {

	// inicializacion
	public int indice;
	[SerializeField] bool abajo;
	[SerializeField] int max_indice;
	public AudioSource sonido;

	void Start () {
		sonido = GetComponent<AudioSource>();
	}
	
	void Update () {
		if(Input.GetAxis ("Vertical") != 0){
			if(!abajo){
				if (Input.GetAxis ("Vertical") < 0) {
					if(indice < max_indice){
						indice++;
					}else{
						indice = 0;
					}
				} else if(Input.GetAxis ("Vertical") > 0){
					if(indice > 0){
						indice --; 
					}else{
						indice = max_indice;
					}
				}
				abajo = true;
			}
		}else{
			abajo = false;
		}
	}

}
