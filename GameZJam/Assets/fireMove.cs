using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireMove : MonoBehaviour
{
    public float moveSpeed = 10;
    public float deadZone = -28;
    public float dmg = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gravityabillity playerScript = collision.gameObject.GetComponent<gravityabillity>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(dmg);
            }

            Destroy(gameObject);
        }
    }
}
