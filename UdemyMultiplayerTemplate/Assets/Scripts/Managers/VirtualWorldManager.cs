using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VirtualWorldManager : MonoBehaviourPunCallbacks
{

    public static VirtualWorldManager instance;

    #region UnityMethods

    private void Awake()
    {
        //singleton implementation = allows us to access method and classes from outside the scripts.
        if (instance != null && instance != this)
        {

            Destroy(this.gameObject);

        }
        instance = this;

    }

    public void LeaveRoomAndLoadScene()
    {

        PhotonNetwork.LeaveRoom();

    }

    #endregion

    #region Photon Callback Methods

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

        Debug.Log(PhotonNetwork.NickName + " is joined to room " + "Player Count: " + PhotonNetwork.CurrentRoom.PlayerCount);

    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.LoadLevel("HomeScene");
    }

    #endregion

}
