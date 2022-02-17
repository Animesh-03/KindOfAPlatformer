using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRecorder : MonoBehaviour
{
    //Record every timeStep seconds
    public float timeStep; 
    public bool record;
    private float time;
    private float timer;
    public List<float> timeValue;
    public List<Vector2> position;
    public List<float> rotation;

    public List<float> newTimeValue;
    public List<Vector2> newPosition;
    public List<float> newRotation;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.unscaledDeltaTime;
        timer+= Time.unscaledDeltaTime;

        if(record && timer >= timeStep)
        {
            newTimeValue.Add(time);
            newPosition.Add(transform.position);
            newRotation.Add(transform.eulerAngles.z);

            timer = 0;
        }
    }


    public void ResetGhost()
    {
        newTimeValue.Clear();
        newPosition.Clear();
        newRotation.Clear();
    }

    public void ReplaceWithNewGhost()
    {
        timeValue = new List<float>(newTimeValue);
        position = new List<Vector2>(newPosition);
        rotation = new List<float>(newRotation);

        ResetGhost();
    }
}
