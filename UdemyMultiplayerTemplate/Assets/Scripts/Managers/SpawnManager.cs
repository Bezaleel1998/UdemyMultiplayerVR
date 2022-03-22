using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;


public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject genericVRPlayerPrefab;
    [SerializeField]
    private GameObject spawnPosition;
    [SerializeField]
    private TeleportationArea areaTeleportation;


    private void Awake()
    {
        
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(genericVRPlayerPrefab.name, spawnPosition.transform.position, Quaternion.identity);
            areaTeleportation.teleportationProvider = GameObject.FindGameObjectWithTag("Player").GetComponent<TeleportationProvider>();
        }

    }

}
