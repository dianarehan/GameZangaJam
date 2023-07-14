using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityabillity : MonoBehaviour
{
    
    [SerializeField] float gravity;
    Rigidbody2D rb;

    public float Hp =25f;
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
    public void TakeDamage(float damage)
    {
        Hp -= damage; 
        if (Hp <= 0f)
        {
            Die(); 
        }
    }

    void Die()
    {
        //we might add some animation or we can respawn maslan mmkn 
        Destroy(gameObject); 
    }
}
