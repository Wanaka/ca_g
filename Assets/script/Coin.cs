using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 3.0f;
    private float rotationSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, -speed);
        rb.gravityScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player"){
            Destroy(this.gameObject);
            CoinScore.coinValue++;
            Debug.Log("Coin collected");
        }
    }
}
