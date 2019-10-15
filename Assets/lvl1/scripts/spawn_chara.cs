using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_chara : MonoBehaviour
{
    public Transform sp;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()

    {
         sp.transform.position = new Vector2(rb.position.x, rb.position.y);
    
    }
}
