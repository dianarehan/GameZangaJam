using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class gravityabillity : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI points;
    [SerializeField] int score;
    [SerializeField] float gravity;
    Rigidbody2D rb;

    [SerializeField] int scoreValue = 1;

    [SerializeField] Animator animator;
    [SerializeField] bool isWalking = false;
    public float Hp = 25f;
    public float gravAcc;
    private Color defaultColor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        points.text = score + " " + "/10";
        defaultColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        //gravAcc += 0.1f * gravity;
        rb.gravityScale = gravity;
        if (Input.GetKey(KeyCode.Q))
        {
            gravity = -1;
        }


        if (Input.GetKey(KeyCode.E))
        {
            gravity = 1;
        }
        
        animator.SetBool("IsWalking", isWalking);
    }
    public void TakeDamage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0f)
        {
            Die();
        }
        else
        {
            StartCoroutine(ShowVulnerableEffect());
        }
    }

    private IEnumerator ShowVulnerableEffect()
    {
        // Change the sprite color to red
        GetComponent<SpriteRenderer>().color = Color.red;

        // Wait for a short duration
        yield return new WaitForSeconds(0.2f);

        // Change the sprite color back to the default color
        GetComponent<SpriteRenderer>().color = defaultColor;
    }





    void Die()
    {
        animator.SetBool("IsDead", true);
        StartCoroutine(DestroyAfterDelay(0.4f));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isWalking = true;
        }
        else if (collision.gameObject.CompareTag("ceiling"))
        {
            isWalking = true;
            FlipPlayer();
        }
    }

    private void FlipPlayer()
    {
        // Flip the player on the y-axis
        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);

        // Play the walking animation
        animator.SetBool("IsWalking", isWalking);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isWalking = false;
        }
        else
        {
            if (collision.gameObject.CompareTag("ceiling"))
            {
                FlipPlayerBack();
            }
        }
    }
   

    private void FlipPlayerBack()
    {
       
        transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y), transform.localScale.z);

        isWalking = false;
    }


}