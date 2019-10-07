using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
    
{
    public Transform heroe;
    public Vector3 desplazamiento;
    public float limit_abajo = -3;
    public float limit_arriba = -1;
    public float limit_izq = -10;
    public float limit_der = 500;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp (heroe.position.x + desplazamiento.x, limit_izq, limit_der),
            Mathf.Clamp(heroe.position.y + desplazamiento.y, limit_abajo, limit_arriba),
            desplazamiento.z);
    }
}
