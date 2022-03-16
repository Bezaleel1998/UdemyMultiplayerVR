using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject genericVRPlayerPrefab;
    [SerializeField]
    private GameObject spawnPosition;

    private void Awake()
    {
        
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.Instantiate(genericVRPlayerPrefab.name, spawnPosition.transform.position, Quaternion.identity);
        }

    }

}
