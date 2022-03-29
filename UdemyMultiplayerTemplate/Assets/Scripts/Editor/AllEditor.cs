using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RoomManagerScenes;

#region LOGIN_MANAGER_EDITOR

[CustomEditor(typeof(LoginManager))]
public class LoginManagerEditor : Editor
{

    //this method is called everytime the method is drawn inside unity 
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This Script is responsible for connecting to photon servers.", MessageType.Info);

        LoginManager loginManager = (LoginManager)target;

        if (GUILayout.Button("Connect Anonymously"))
        {
            loginManager.ConnectAnonymously();
        }

    }

}

#endregion


#region ROOM_MANAGER_EDITOR

[CustomEditor(typeof(RoomManager))]
public class RoomManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This script is responsible for making random room (Random Room Generator).", MessageType.Info);

        RoomManager rM = (RoomManager)target;

        if (GUILayout.Button("Join Outdoor Room"))
        {

            rM.OnEnterButtonClicked_Outdoor();

        }

        if (GUILayout.Button("Join School Room"))
        {

            rM.OnEnterButtonClicked_School();

        }

    }

}

#endregion


#region ButtonBackToHome

[CustomEditor(typeof(LocalPlayerGameManager))]
public class LocalPlayerGameManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.HelpBox("This Script is responsible for button back action to home menu.", MessageType.Info);

        LocalPlayerGameManager lPGM = (LocalPlayerGameManager)target;

        if (GUILayout.Button("Back to Home Scene"))
        {

            lPGM.Awake();

        }

    }

}

#endregion
