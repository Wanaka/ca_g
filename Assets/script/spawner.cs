using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject asteroidMedium;
    public GameObject asteroidSmall;

    // Start is called before the first frame update
    void Start()
    {
        // print ("randomrange: " + Random.Range(0, 3));
        
        switch (Random.Range(0, 3))
        {
        case 0:
            GameObject b = Instantiate(asteroid) as GameObject;
            b.transform.position =  new Vector2(Random.Range(-2, 2), 6);
            break;
            
        case 1:       
            GameObject c = Instantiate(asteroidMedium) as GameObject;
            c.transform.position =  new Vector2(Random.Range(-2, 2), 6);
            break;

        case 2:
            GameObject d = Instantiate(asteroidSmall) as GameObject;
            d.transform.position =  new Vector2(Random.Range(-2, 2), 6);
            break;
        }

        // GameObject b = Instantiate(asteroid) as GameObject;
        // b.transform.position =  new Vector2(Random.Range(-2, 2), 6);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
