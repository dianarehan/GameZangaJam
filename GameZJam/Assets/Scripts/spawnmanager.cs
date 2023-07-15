/*using System.Collections;
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
        float xposlimit = 3.44f; ;
        float xposlimitt = -3.26f;
        float randomxpos = (Random.Range(xposlimit, xposlimitt));
        Instantiate(moving_platformprefab, new Vector2(14.63f, randomxpos), transform.rotation);
    }
    void spawnprojectiles()
    {
        float xposlimit = 3.44f;
        float xposlimitt = 3.26f;
        float randomxpos = (Random.Range(xposlimit, xposlimitt));
        Instantiate(projectilesprefab, new Vector2(14.63f, randomxpos), transform.rotation);
    }

    void spawnapples()
    {
        float xposlimit = 3.44f;
        float xposlimitt = 3.26f;
        float randomxpos = (Random.Range(xposlimit, xposlimitt));
        Instantiate(applesprefab, new Vector2(14.63f, randomxpos), transform.rotation);
    }
}
    */
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
    [SerializeField] int platformCountForApple = 5; // Number of platforms to spawn between each apple

    private int platformCount = 0; // Counter for spawned platforms

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnplatforms", time, repeatrate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /* void spawnplatforms()
     {
         float xposlimit = 3.44f;
         float xposlimitt = -3.26f;
         float randomxpos = Random.Range(xposlimit, xposlimitt);
         Instantiate(moving_platformprefab, new Vector2(14.63f, randomxpos), Quaternion.identity);

         platformCount++; // Increase the platform counter

         // Check if the platform count reaches the desired number for spawning an apple
         if (platformCount % platformCountForApple == 0)
         {
             // Spawn an apple on the platform
             Instantiate(applesprefab, new Vector2(14.63f, randomxpos + 1.0f), Quaternion.identity);
         }
     }*/
    void spawnplatforms()
    {
        float xposlimit = 3.44f;
        float xposlimitt = -3.26f;
        float randomxpos = Random.Range(xposlimit, xposlimitt);
        GameObject platform = Instantiate(moving_platformprefab, new Vector2(14.63f, randomxpos), Quaternion.identity);

        platformCount++; // Increase the platform counter

        // Check if the platform count reaches the desired number for spawning an apple
        if (platformCount % platformCountForApple == 0)
        {
            // Spawn an apple on the platform
            GameObject apple = Instantiate(applesprefab, platform.transform.position + new Vector3(0f, 1.0f, 0f), Quaternion.identity);
            apple.transform.SetParent(platform.transform);
        }
    }

}
