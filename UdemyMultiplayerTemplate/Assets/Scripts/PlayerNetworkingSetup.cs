using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerNetworkingSetup : MonoBehaviourPunCallbacks
{

    public GameObject localXROrigin;
    public GameObject AvatarHeadGameObject;
    public GameObject AvatarBodyGameObject;

    #region UnityMethods

    private void Awake()
    {

        AwakeCaller();

    }

    private void Update()
    {

    }

    void AwakeCaller()
    {

        //will tell us if this instantiate player is us or not
        if (photonView.IsMine)
        {

            //this is the local player
            localXROrigin.SetActive(true);
            SetLayerRecursively(AvatarHeadGameObject, 6);
            SetLayerRecursively(AvatarBodyGameObject, 7);

            TeleportationArea[] teleportationAreas = GameObject.FindObjectsOfType<TeleportationArea>();
            if (teleportationAreas.Length > 0)
            {

                Debug.Log("Found " + teleportationAreas.Length + " teleportation area");
                foreach (var item in teleportationAreas)
                {

                    item.teleportationProvider = localXROrigin.GetComponent<TeleportationProvider>();

                }

            }

        }
        else
        {

            //this player is remote player
            localXROrigin.SetActive(false);
            SetLayerRecursively(AvatarHeadGameObject, 0);
            SetLayerRecursively(AvatarBodyGameObject, 0);

        }

    }

    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }

    #endregion

    #region Photon Pun Callback Methods



    #endregion

}
