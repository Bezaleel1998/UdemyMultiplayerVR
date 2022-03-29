using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerTeleportation : MonoBehaviour
{

    [SerializeField]
    private GameObject cloneGeneralXRPrefabs;

    private int thisPlayerID;
    [SerializeField]
    private PhotonView photonPunView;

    [SerializeField]
    internal string[] sceneNames;

    private void Awake()
    {

        thisPlayerID = photonPunView.ViewID;

    }

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("Something Touching player : " + other.tag);
        if (thisPlayerID == photonPunView.ViewID)
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

    }

}