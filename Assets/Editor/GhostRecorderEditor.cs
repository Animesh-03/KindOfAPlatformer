using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GhostRecorder))]
public class GhostRecorderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GhostRecorder ghostRecorder = (GhostRecorder)target;

        if(GUILayout.Button("Load Stuff"))
        {
            SerializableList<Vector2> list = JsonUtility.FromJson<SerializableList<Vector2>>(ghostRecorder.recordPosFile.text);
            ghostRecorder.position = new List<Vector2>(list.list);
            SerializableList<float> list1 = JsonUtility.FromJson<SerializableList<float>>(ghostRecorder.recordRotFile.text);
            ghostRecorder.rotation = new List<float>(list1.list);
        }
    }
}
