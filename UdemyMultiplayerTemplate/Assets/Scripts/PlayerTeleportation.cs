using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhotonPunVR.TeleportingSystem;
using Photon.Pun;
using Photon.Realtime;

public class PlayerTeleportation : MonoBehaviour
{

    [SerializeField]
    private TeleportingSystem teleportManager;
    [SerializeField]
    private GameObject cloneGeneralXRPrefabs;

    private void Awake()
    {

        teleportManager = GameObject.FindGameObjectWithTag("TeleportSystemManager").GetComponent<TeleportingSystem>();

    }

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("Something Touching player : " + other.tag);
        TargetTeleportScene(other.tag);

    }

    void TargetTeleportScene(string sceneTag)
    {

        switch (sceneTag)
        {
            case "schoolRoomScene":
                Debug.Log("Load School Scene");

                //teleportManager.OnEnterButtonClicked_School();
                teleportManager.LoadArena(teleportManager.sceneNames[1]);                
                
                break;
            case "outDoorScene":
                Debug.Log("Load OutDoor Scene");

                //teleportManager.OnEnterButtonClicked_Outdoor();
                teleportManager.LoadArena(teleportManager.sceneNames[0]);
                
                break;
        }

    }

}