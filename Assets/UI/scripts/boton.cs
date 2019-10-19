using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton : MonoBehaviour
{
	[SerializeField] boton_control boton_control;
	[SerializeField] Animator animator;
	[SerializeField] int boton_indice;

    // Update is called once per frame
    void Update()
    {
		if(boton_control.indice == boton_indice)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
			}
		}else{
			animator.SetBool ("selected", false);
		}
    }
}
