using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    public float speed = 0.001f;
    public bool isBitten = false;

    private Rigidbody2D rigidBody;
    private float movementX, movementY;
    private bool isFlipped = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX, movementY);
        rigidBody.AddForce(movement * speed);

        Vector2 norm = rigidBody.velocity.normalized;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(norm.y, norm.x) * Mathf.Rad2Deg);

        //if(norm.x < 0 && !isFlipped)
        //{
        //    flip();
        //}
        //if (norm.x > 0 && isFlipped)
        //{
        //    flip();
        //}


    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFlipped = !isFlipped;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shark")
        {
            isBitten = true;
        }
    }
}
