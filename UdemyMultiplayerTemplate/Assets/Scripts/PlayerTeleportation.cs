using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PlayerTeleportation : MonoBehaviour
{

    [SerializeField]
    private GameObject cloneGeneralXRPrefabs;

    private string thisPlayerID;
    [SerializeField]
    private PhotonView photonPunView;

    [SerializeField]
    internal string[] sceneNames;

    private void Awake()
    {

        //thisPlayerID = (string)photonPunView.ViewID;
        thisPlayerID = PhotonNetwork.LocalPlayer.UserId;
        Debug.Log("<color=magenta>Local Player ID : " + thisPlayerID + "</color>");

    }

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("Something Touching player : " + other.tag);
        if (photonPunView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            TargetTeleportScene(other.tag);
        }

    }

    void TargetTeleportScene(string sceneTag)
    {

        switch (sceneTag)
        {
            case "schoolRoomScene":
                Debug.Log("Load School Scene, player id : " + thisPlayerID + " has change scene");

                LoadArena(sceneNames[1]);                
                
                break;
            case "outDoorScene":
                Debug.Log("Load OutDoor Scene, player id : " + thisPlayerID + " has change scene");

                LoadArena(sceneNames[0]);
                
                break;
        }

    }

    public void LoadArena(string sceneName)
    {

        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        PhotonNetwork.LoadLevel(sceneName);
        PhotonNetwork.Destroy(this.cloneGeneralXRPrefabs);
    }

}