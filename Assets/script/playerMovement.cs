using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float moveSpeed = 10f;
    Vector3 touchPosition, whereToMove;
    bool isMoving;
    float previousDistanceToTouchPos, currentDistanceToTouchPos;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    private float shootTimer = 0;

    // Start is called before the first frame update
    void Start()
    { 
        rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }

        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);


        if (shootTimer < Time.time) {
            shootBullet();
            shootTimer = Time.time + 1;
        }

            switch (touch.phase){
                case TouchPhase.Began:
                    previousDistanceToTouchPos = 0;
                    currentDistanceToTouchPos = 0;
                    isMoving = true;
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0;
                    whereToMove = (touchPosition - transform.position).normalized;
                    rb.velocity = new Vector2(whereToMove.x * moveSpeed, 0);

                    break;

                case TouchPhase.Moved:
                    previousDistanceToTouchPos = 0;
                    currentDistanceToTouchPos = 0;
                    isMoving = true;
                    touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                    touchPosition.z = 0;
                    whereToMove = (touchPosition - transform.position).normalized;
                    rb.velocity = new Vector2(whereToMove.x * (moveSpeed + 30f), 0);
                    break;

                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;
            }
        }

        if(currentDistanceToTouchPos > previousDistanceToTouchPos){
            isMoving = false;
            rb.velocity = Vector2.zero;
        }

        if(isMoving){
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }
    }

    public void shootBullet(){
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bullet" || col.gameObject.tag == "Coin"){ return; } 
        else {
            Destroy(this.gameObject);
            Debug.Log("Catstronaut died");
        }
    }
}
