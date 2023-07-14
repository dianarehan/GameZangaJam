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
    // Start is called before the first frame update
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
