using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;


public class LoginManager : MonoBehaviourPunCallbacks
{

    [Header("UISystem")]
    public TMP_InputField playerInputName;

    private TouchScreenKeyboard keyboard;

    #region Unity Methods

    void Awake()
    {

        //starting the connection
        //PhotonNetwork.ConnectUsingSettings();

    }

    void Update()
    {



    }

    #endregion

    #region UI Callback Method

    public void ConnectAnonymously()
    {

        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.NickName = "AnonymousPlayer_" + Random.Range(0, 10000);

    }

    public void ConnectToPhotonServer()
    {

        if (playerInputName != null)
        {

            PhotonNetwork.NickName = playerInputName.text;
            PhotonNetwork.ConnectUsingSettings();

        }

    }

    #endregion

    #region Photon Methods

    //checking when raw connection was established
    public override void OnConnected()
    {

        Debug.Log("<color=blue> Photon Pun Connection Established, Server is available ! </color>");
    
    }

    //called if user/client was successfully connected to the server
    public override void OnConnectedToMaster()
    {

        Debug.Log("<color=yellow> Connected to the Master Server ! With player name : " + PhotonNetwork.NickName + "</color>");
        PhotonNetwork.LoadLevel("HomeScene");

    }

    #endregion

}
