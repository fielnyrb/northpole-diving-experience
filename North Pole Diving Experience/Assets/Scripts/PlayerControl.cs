using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    public float speed = 1f;
    public bool isBitten = false;
    public SpriteRenderer spriteRenderer;

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

    float zVelocity;
    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX, movementY);
        rigidBody.AddForce(movement * speed);

        //Vector2 norm = rigidBody.velocity.normalized;
        Vector2 norm = new Vector2(movementX,movementY);
        if(norm.magnitude > 0)
        {
            float zAxis = Mathf.SmoothDampAngle(transform.eulerAngles.z, Mathf.Atan2(norm.y, norm.x) * Mathf.Rad2Deg,ref zVelocity, 0.1f);
            transform.eulerAngles = new Vector3(0, 0, zAxis);
        }

        //if (norm.x < 0 && !isFlipped)
        //{
        //    flip();
        //}
        //if (norm.x > 0 && isFlipped)
        //{
        //    flip();
        //}

        if ((transform.eulerAngles.z < 90 || transform.eulerAngles.z > 270) && isFlipped)
        {
            flip();
        }
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270 && !isFlipped)
        {
            flip();
        }
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void flip()
    {
        //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        spriteRenderer.flipY = !spriteRenderer.flipY;
        isFlipped = !isFlipped;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shark")
        {
            isBitten = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Air")
        {
            print(StatusControl.Instance());
            StatusControl.Instance().AddOxygen(0.01f);
        }
    }
}
