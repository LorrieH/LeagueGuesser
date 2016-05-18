using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CustomEditor : EditorWindow
{

    [MenuItem("Window/Delete File")]
    static void Init()
    {
        CustomEditor window = (CustomEditor)EditorWindow.GetWindow(typeof(CustomEditor));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("File Deleter");


        if (GUILayout.Button("Delete Data File"))
        {
            DeleteFile();
        }
    }

    public void DeleteFile()
    {
        File.Delete(Application.persistentDataPath + "/SaveData.elohell");
    }

}

