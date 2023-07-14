using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float repeatrate;
    [SerializeField] GameObject moving_platformprefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnobject", time, repeatrate);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void spawnobject()
    {
        Instantiate(moving_platformprefab, new Vector2(14.63f, Random.Range(0.46f, -1.64f)), transform.rotation);
    }

}
    