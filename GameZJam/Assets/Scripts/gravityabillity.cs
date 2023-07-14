using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityabillity : MonoBehaviour
{
    
    [SerializeField] float gravity;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        rb.gravityScale = gravity;
        if (Input.GetKey(KeyCode.Q))
        {
            gravity = -1;
        }


        if (Input.GetKey(KeyCode.E))
        {
            gravity = 1;
        }
    }
}
