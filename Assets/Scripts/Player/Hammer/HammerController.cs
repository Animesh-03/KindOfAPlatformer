using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    //References
    private Rigidbody2D rb;
    public Transform player;

    //Vectors
    private Vector2 relMousePosition;

    //Angles
    private float targetAngle;

    //----------Follow  Mouse----------
    //1. Get the mouse position relative to the player.
    //2. Calculate target Angle by measuring the slope of the mousePosition.
    //3. Move the rigidbody to the required rotation.
    //----------------------------------
    void FollowMouse()
    {
        relMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position;
        targetAngle = Mathf.Atan2(relMousePosition.y,relMousePosition.x) * Mathf.Rad2Deg;
        rb.MoveRotation(targetAngle);
    }

    void ResetHammer()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 90f);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            ResetHammer();
        }
    }

    void FixedUpdate()
    {
        
        FollowMouse();


    }
}
