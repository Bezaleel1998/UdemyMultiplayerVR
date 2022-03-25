using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoomManagerScenes;

public class TeleportingSystem : RoomManager
{
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            SwitchRoom(this.tag);

        }

    }

    void SwitchRoom(string switch_on_room)
    {

        switch (switch_on_room)
        {
            case "outDoor":
                OnEnterButtonClicked_Outdoor();
                break;

            case "schoolRoom":
                OnEnterButtonClicked_School();
                break;
        }

    }

}
