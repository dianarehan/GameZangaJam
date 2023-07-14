using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveleft : MonoBehaviour
{
    float xposlimit = -21.59f;
    float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < xposlimit)
        {
            Destroy(gameObject);
        }
    }
}
