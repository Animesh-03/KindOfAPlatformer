using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public float bufferSize;

    private Rect viewport;
    private float zIndex;

    void Start()
    {
        zIndex = transform.position.z;
        //Initialise the viewport co-ordinates
        viewport.x = (Screen.width/2) - (bufferSize/2);
        viewport.y = (Screen.height/2) - (bufferSize/2);
        viewport.width = bufferSize;
        viewport.height = bufferSize;
    }


    void Update()
    {
        Vector3 newPos = new Vector3(player.position.x,player.position.y, zIndex);

        if(!viewport.Contains(Camera.main.WorldToScreenPoint(newPos)))  // Check if player is not inside the buffer zone
        {
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * moveSpeed);  // Move the camera inside the buffer zone
        } 
    }
}
