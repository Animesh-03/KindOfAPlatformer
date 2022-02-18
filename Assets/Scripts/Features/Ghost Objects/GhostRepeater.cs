using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRepeater : MonoBehaviour
{
    public GhostRecorder ghost;
    public bool repeat;
    public bool loop;
    private float timer;
    private Rigidbody2D rb;
    public int startFrame = 0;
    public int index = 0;

    private Vector2 targetPos;
    private Vector2 currentPos;
    private float targetRot;
    private float currentRot;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPos = ghost.position[0];
        targetRot = ghost.rotation[0];
        index = startFrame;
    }

    void Update()
    {
        if(repeat)
        {
            timer += Time.unscaledDeltaTime;
            //Set the new target position and rotation every timeStep seconds
            if(timer >= ghost.timeStep)
            {
                if(index <= ghost.position.Count)
                    targetPos = ghost.position[index];
                currentPos = transform.position;

                if(index <= ghost.position.Count)
                    targetRot = ghost.rotation[index];
                currentRot = transform.eulerAngles.z;

                index++;
                if(loop && index >= ghost.position.Count) RestartGhost();

                timer = 0;
            }
            //Lerp the tansform values
            rb.MovePosition(Vector2.Lerp(currentPos,targetPos,timer/ghost.timeStep));
            rb.MoveRotation(Mathf.Lerp(currentRot,targetRot,timer/ghost.timeStep));
        }
    }

    public void RestartGhost()
    {
        index = startFrame;
    }
}
