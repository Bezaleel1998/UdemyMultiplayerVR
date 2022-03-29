using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

namespace RoomManagerScenes
{


    public class RoomManager : MonoBehaviourPunCallbacks
    {

        private string mapType;

        [SerializeField]
        private string[] sceneNames;

        public TextMeshProUGUI IOccupancyRateText_ForSchool;
        public TextMeshProUGUI IOccupancyRateText_ForOutDoor;


        #region UnityMethod(s)

        void Awake()
        {

            //synchronize the scenes for all player inside the same room
            PhotonNetwork.AutomaticallySyncScene = true;

            //This is how we can check if we're connected to the servers or not
            if (!PhotonNetwork.IsConnectedAndReady)
            {
                PhotonNetwork.ConnectUsingSettings();
            }
            else
            {
                PhotonNetwork.JoinLobby();
            }

        }

        void Update()
        {

        }

        #endregion

        #region UICallbackMethod(s)

        public void JoinRandomRoom()
        {

            //random match making.
            PhotonNetwork.JoinRandomRoom();

        }

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

        #region Photon Callback Methods

        public override void OnJoinRandomFailed(short returnCode, string message)
        {

            Debug.Log(message);
            CreateAndJoinRoom();

        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("<color=lime>Connected to the Master server again.</color>");
            Debug.Log("Server IP: " + PhotonNetwork.ServerAddress);
            PhotonNetwork.JoinLobby();
        }

        public override void OnCreatedRoom()
        {

            Debug.Log("<color=violet>A room was created with the name " + PhotonNetwork.CurrentRoom.Name + "!</color>");

        }

        public override void OnJoinedRoom()
        {

            Debug.Log("The local player : " + PhotonNetwork.NickName + " has been joined to " + PhotonNetwork.CurrentRoom.Name + " ! \n Total player in this area : " + PhotonNetwork.CurrentRoom.PlayerCount);

            if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(MultiplayerVRConstants.MAP_TYPE_KEY))
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

            }

        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {

            Debug.Log(newPlayer.NickName + " is joined to room " + "Player Count: " + PhotonNetwork.CurrentRoom.PlayerCount);

        }

        //update occupancy rate in the rooms
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {

            if (roomList.Count == 0)
            {
                //no room at all
                IOccupancyRateText_ForOutDoor.text = 0 + "/" + 20;
                IOccupancyRateText_ForSchool.text = 0 + "/" + 20;
            }
            //this room class contains a lot of data about the room
            foreach (RoomInfo room in roomList)
            {

                Debug.Log(room.Name);

                if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_OUTDOOR))
                {
                    //update the outdoor room occupancy field
                    Debug.Log("<color=magenta>This is Outdoor map, Player count is : " + room.PlayerCount);
                    IOccupancyRateText_ForOutDoor.text = room.PlayerCount + "/" + 20;
                }
                else if (room.Name.Contains(MultiplayerVRConstants.MAP_TYPE_VALUE_SCHOOL))
                {
                    //update the school room occupancy field
                    Debug.Log("<color=magenta>This is School map, Player count is : " + room.PlayerCount);
                    IOccupancyRateText_ForSchool.text = room.PlayerCount + "/" + 20;
                }

            }

        }

        public override void OnJoinedLobby()
        {
            Debug.Log("Joined the lobby");
        }

        public override void OnDisconnected(DisconnectCause cause)
        {

            Debug.LogWarningFormat("<color=#FFA500>OnDisconnected() was called by PUN with reason {0}</color>", cause);

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

    }


}