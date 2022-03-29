using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VirtualWorldManager : MonoBehaviourPunCallbacks
{

    //private static VirtualWorldManager _instance;

    //public static VirtualWorldManager Instance { get { return _instance; } }

    bool isLeavingRoom = false;

    #region UnityMethods

    private void Awake()
    {

        //VirtualWorldManagerInstance();
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("You're status of leaving the room is : " + isLeavingRoom);

    }

    public void LeaveRoomAndLoadScene(bool backToMenu)
    {

        isLeavingRoom = backToMenu;
        Debug.Log("You're status of leaving the room is : " + isLeavingRoom);

        if (backToMenu)
        {
            PhotonNetwork.LeaveRoom();
        }

    }

    #endregion

    #region Singleton Implementation (Unused)

    /*void VirtualWorldManagerInstance()
    {
        //singleton implementation = allows us to access method and classes from outside the scripts.
        if (_instance != null && _instance != this)
        {

            Destroy(this.gameObject);
            //return;

        }
        else
        {

            _instance = this;

        }
    }*/

    #endregion

    #region Photon Callback Methods

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {

        Debug.Log(PhotonNetwork.NickName + " is joined to room " + "Player Count: " + PhotonNetwork.CurrentRoom.PlayerCount);

    }

    public override void OnLeftRoom()
    {

        if (isLeavingRoom)
        {
            PhotonNetwork.Disconnect();
        }

    }

    public override void OnDisconnected(DisconnectCause cause)
    {

        if (isLeavingRoom)
        {
            PhotonNetwork.LoadLevel("HomeScene");
        }

    }

    #endregion
    
}
