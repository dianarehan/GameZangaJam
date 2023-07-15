using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] float damageAmount = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gravityabillity player = collision.gameObject.GetComponent<gravityabillity>();
            if (player != null)
            {
                player.TakeDamage(damageAmount);
            }
        }
    }
}
