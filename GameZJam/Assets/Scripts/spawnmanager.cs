using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float repeatrate;
    [SerializeField] GameObject moving_platformprefab;
    [SerializeField] GameObject projectilesprefab;
    [SerializeField] GameObject applesprefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnplatforms", time, repeatrate);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void spawnplatforms()
    {
        float yposlimit = 3.24f; 
        float yposlimitt = -4.92f;
        float randomypos = (Random.Range(yposlimit, yposlimitt));
        Instantiate(moving_platformprefab, new Vector2(14.63f, randomypos), transform.rotation);
    }
    void spawnprojectiles()
    {
        float yposlimit = 3.24f;
        float yposlimitt = -4.92f;
        float randomypos = (Random.Range(yposlimit, yposlimitt));
        Instantiate(projectilesprefab, new Vector2(14.63f, randomypos), transform.rotation);
    }

    void spawnapples()
    {
        float yposlimit = 3.24f;
        float yposlimitt = -4.92f;
        float randomypos = (Random.Range(yposlimit, yposlimitt));
        Instantiate(applesprefab, new Vector2(14.63f, randomypos), transform.rotation);
    }
}
    