/*
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f,1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;  
    }

 
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
*/
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float initialScrollSpeed = 0.5f;
    public float scrollAcceleration = 0.1f;
    public float accelerationInterval = 30f;

    private float currentScrollSpeed;
    private float offset;
    private Material mat;
    private float timer;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        currentScrollSpeed = initialScrollSpeed;
        timer = 0f;
    }

    private void Update()
    {
        offset += (Time.deltaTime * currentScrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));

        timer += Time.deltaTime;
        if (timer >= accelerationInterval)
        {
            timer = 0f;
            currentScrollSpeed += scrollAcceleration;
        }
    }
}


