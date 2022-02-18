using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
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
    [HideInInspector]
    public List<float> newTimeValue;
    [HideInInspector]
    public List<Vector2> newPosition;
    [HideInInspector]
    public List<float> newRotation;

    public TextAsset recordPosFile;
    public TextAsset recordRotFile;


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

        string posString = JsonUtility.ToJson(new SerializableList<Vector2>(position));
        string rotString = JsonUtility.ToJson(new SerializableList<float>(rotation));
        
        File.WriteAllText("./Assets/Misc/" + transform.name +"Pos.txt",posString);
        File.WriteAllText("./Assets/Misc/" + transform.name +"Rot.txt",rotString);

        ResetGhost();
    }
}


[Serializable]
public class SerializableList<T>
{
    public List<T> list;
    public SerializableList(List<T> list) => this.list = list;
}
