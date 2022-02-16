using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //References
    private Rigidbody2D rb;
    private AudioManager audioManager;

    //Input
    private float xInput;
    private float yInput;

    //Movement
    public float moveSpeed;
    public float jumpForce;
    public float maxVel;
    public float ctrMovement;

    //Ground Check
    [SerializeField]
    private bool onGround;
    public LayerMask groundLayer;
    public Transform groundCheck;

    //Handles Input
    private void GetInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");     // Value either 0 or +-1
        yInput = Input.GetAxisRaw("Vertical");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        for(int i = 0; i < collision.contactCount; i++)
        {
            ContactPoint2D c = collision.GetContact(i);
            if(collision.collider.gameObject.layer == 6 && c.normal == Vector2.up)  //Check if collision object is horizontal
            {
                onGround = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.gameObject.layer == 6)
        {
            onGround = false;
        }
    }

    

    private void Movement()
    {
        if(Mathf.Abs(rb.velocity.x) < maxVel)
        {
            rb.AddForce(transform.right * moveSpeed * xInput * Time.smoothDeltaTime, ForceMode2D.Impulse);
        }

        if(yInput > 0 && onGround)
        {
            rb.velocity = new Vector3(rb.velocity.x,jumpForce,rb.velocity.y);
            audioManager.PlaySound("Jump");
            CameraShake.Instance.Shake(1f,0.1f);
        }

        //Counter Movement
        if((rb.velocity.x > 0.1f && xInput < -0.1f) || (rb.velocity.x < -0.1f && xInput > 0.1f) || (Mathf.Abs(rb.velocity.x) > 0.1f && Mathf.Abs(xInput) < 0.1f) || Mathf.Abs(rb.velocity.x) >= maxVel)
        {
            rb.AddForce(transform.right * -rb.velocity.x * ctrMovement * moveSpeed * Time.smoothDeltaTime);
        }

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        GetInput();
        // GroundCheck();
        Movement();
    }
}
