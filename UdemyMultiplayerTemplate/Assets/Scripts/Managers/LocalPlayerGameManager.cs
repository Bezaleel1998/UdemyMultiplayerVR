using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalPlayerGameManager : MonoBehaviour
{

    [SerializeField]
    GameObject goHomeButton;

    private void Awake()
    {

        goHomeButton.GetComponent<Button>().onClick.AddListener(VirtualWorldManager.Instance.LeaveRoomAndLoadScene);

    }

}
