using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class gravityabillity : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI points;
    [SerializeField]  int score;
    [SerializeField] float gravity;
    Rigidbody2D rb;

    [SerializeField] int scoreValue = 1;

    [SerializeField] Animator animator;
    [SerializeField] bool isWalking = false;
    public float Hp =25f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        points.text = score + " "+"/10";
      
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
        isWalking = IsPlayerWalking();
        animator.SetBool("IsWalking", isWalking);
    }
    public void TakeDamage(float damage)
    {
        Hp -= damage; 
        if (Hp <= 0f)
        {
            Die(); 
        }
    }
    bool IsPlayerWalking()
    {
        float raycastDistance = 0.6f;
        Vector2 raycastDirection = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, raycastDirection, raycastDistance);

        if (hit.collider != null && hit.collider.CompareTag("ground"))
        {
            Debug.Log("Ground collider detected.");
            return true;
        }

        Debug.Log("No ground collider detected.");
        return false;
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
            points.text = score + " " + "/10";
            Destroy(collision.gameObject);
        }
    }
}
