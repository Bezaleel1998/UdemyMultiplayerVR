using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoomManagerScenes;
using Photon.Pun;
using Photon.Realtime;

namespace PhotonPunVR.TeleportingSystem
{

    public class TeleportingSystem : MonoBehaviourPunCallbacks, IConnectionCallbacks
    {

        private string mapType;

        [SerializeField]
        internal string[] sceneNames;

        private bool isConnectedToMaster;


        #region UnityMethod(s)

        void Awake()
        {

            //synchronize the scenes for all player inside the same room
            PhotonNetwork.AutomaticallySyncScene = true;

            isConnectedToMaster = false;
            isConnectedToMaster = PhotonNetwork.ConnectUsingSettings();

        }

        /*public void PlayerReconnectToMaster()
        {
            PhotonNetwork.LeaveRoom();
        }*/

        public void LoadArena(string sceneName)
        {

            if (!PhotonNetwork.IsMasterClient)
            {
                return;
            }

            /*if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiplayerVRConstants.MAP_TYPE_KEY))
            {

                object mapType;
                if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue(MultiplayerVRConstants.MAP_TYPE_KEY, out mapType))
                {

                    Debug.Log("Joined room with map type = " + (string)mapType);

                    if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_OUTDOOR)
                    {

                        //load outdoor scene
                        PhotonNetwork.LoadLevel(sceneNames[0]);

                    }
                    else if ((string)mapType == MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL)
                    {

                        //load school scene
                        PhotonNetwork.LoadLevel(sceneNames[1]);

                    }

                }

            }*/

            PhotonNetwork.LoadLevel(sceneName);

        }

        #endregion

        /*
        #region UICallbackMethod(s)

        public void OnEnterButtonClicked_Outdoor()
        {

            mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_OUTDOOR;
            ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
            PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);

        }

        public void OnEnterButtonClicked_School()
        {

            mapType = MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL;
            ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };
            PhotonNetwork.JoinRandomRoom(expectedCustomRoomProperties, 0);

        }

        #endregion
        */

        /*
        #region Photon Callback Methods

        public override void OnJoinRandomFailed(short returnCode, string message)
        {

            Debug.Log(message);
            CreateAndJoinRoom();

        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("Connected to the server again.");
            //PhotonNetwork.JoinLobby();
            // #Critical: The first we try to do is to join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
            if (isConnectedToMaster)
            {

                PhotonNetwork.JoinRandomRoom();
                isConnectedToMaster = false;

            }
        }

        public override void OnCreatedRoom()
        {

            Debug.Log("<color=violet>A room was created with the name " + PhotonNetwork.CurrentRoom.Name + "!</color>");

        }

        public override void OnJoinedRoom()
        {

            Debug.Log("The local player : " + PhotonNetwork.NickName + " has been joined to " + PhotonNetwork.CurrentRoom.Name + " ! \n Total player in this area : " + PhotonNetwork.CurrentRoom.PlayerCount);

        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {

            Debug.Log(PhotonNetwork.NickName + " is joined to room " + "Player Count: " + PhotonNetwork.CurrentRoom.PlayerCount);

        }

        public override void OnJoinedLobby()
        {
            Debug.Log("Joined the lobby");
        }

        #endregion


        #region PrivateMethods

        private void CreateAndJoinRoom()
        {

            string randomRoomName = "Room No_" + mapType + Random.Range(0, 10000);
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 20;

            //setting room properties in lobby                
            string[] roomPropsInLobby = { MultiplayerVRConstants.MAP_TYPE_KEY };
            //we have 2 different map : 1. Outdoor = "outdoor" and 2. School = "School"

            //this using special hash code from photon
            ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable() { { MultiplayerVRConstants.MAP_TYPE_KEY, mapType } };

            roomOptions.CustomRoomPropertiesForLobby = roomPropsInLobby;
            roomOptions.CustomRoomProperties = customRoomProperties;

            //create new Room
            PhotonNetwork.CreateRoom(randomRoomName, roomOptions);

        }

        #endregion

        */

    }


}