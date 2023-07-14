using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmove : MonoBehaviour
{
    public float speed = 5;
    BoxCollider2D collider2d;
    // Start is called before the first frame update
    void Start()
    {
      float  collider2d = GetComponent<BoxCollider2D>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x = collider2d)
        {

        }
    }
}
