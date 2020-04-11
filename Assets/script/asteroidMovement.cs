using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMovement : MonoBehaviour
{
    private float speed = 0.3f; // this increases when player levels up
    private float rotationSpeed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private float randomRange;
    private int asteroidLife; // ändra sen när det ska bli random
    public GameObject nextAsteroid;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, -speed);
        rb.gravityScale = 0.0f;
        
        //Random rotation
        randomRange = Random.Range(0, 2);

        setLife();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < (screenBounds.y * -1.4) ){
            Destroy(this.gameObject);
        }

        rotate(); //Rotation and speed should play together
    }

    public void rotate(){
        if(randomRange == 0){
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        } else {
            transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
        }
    }

    public void setLife(){
        int rand = Random.Range(1, 6);

        switch (this.gameObject.tag)
        {
        case "Asteroid":
            print ("Big");
            asteroidLife = rand;
            break;
            
        case "AsteroidMedium":
            print ("medium");
            asteroidLife = rand;        
            break;

        case "AsteroidSmall":
            print ("small");
            asteroidLife = rand;
            break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Score.scoreValue++;
        Destroy(col.gameObject);
        asteroidLife--;
        Debug.Log("Hit " + this.gameObject.tag);
        Debug.Log("Life remaining " + asteroidLife);

        switch (asteroidLife)
        {
        case 0:
            createCoin();
            print ("dead");
            Destroy(this.gameObject);

            if(this.gameObject.tag == "Asteroid"){
                createMediumAsteroidLeft();
                createMediumAsteroidRight();
            } else if(this.gameObject.tag == "AsteroidMedium") {
                createSmallAsteroidLeft();
                createSmallAsteroidRight();
            }
            break;
        }
    }

    public void createCoin(){
        GameObject b = Instantiate(coin) as GameObject;
        b.transform.position =  new Vector2((transform.position.x), transform.position.y);
    }

    public void createMediumAsteroidLeft(){
        GameObject b = Instantiate(nextAsteroid) as GameObject;
        b.transform.position =  new Vector2((transform.position.x - 1.0f), transform.position.y);
    }

    public void createMediumAsteroidRight(){
        GameObject b = Instantiate(nextAsteroid) as GameObject;
        b.transform.position =  new Vector2((transform.position.x + 1.0f), transform.position.y);
    }

    public void createSmallAsteroidLeft(){
        GameObject b = Instantiate(nextAsteroid) as GameObject;
        b.transform.position =  new Vector2((transform.position.x - 0.5f), transform.position.y);
    }

    public void createSmallAsteroidRight(){
        GameObject b = Instantiate(nextAsteroid) as GameObject;
        b.transform.position =  new Vector2((transform.position.x + 0.5f), transform.position.y);
    }
}
