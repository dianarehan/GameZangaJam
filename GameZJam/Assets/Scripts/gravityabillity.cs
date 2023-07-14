using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gravityabillity : MonoBehaviour
{
    [SerializeField] Text points;
    [SerializeField]  int score;
    [SerializeField] float gravity;
    Rigidbody2D rb;

    public float Hp =25f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        points.text = points.text + score;
      
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "collectable")
        {
            score++;
            points.text = points.text + score;
            Destroy(collision.gameObject);
        }
    }
}
