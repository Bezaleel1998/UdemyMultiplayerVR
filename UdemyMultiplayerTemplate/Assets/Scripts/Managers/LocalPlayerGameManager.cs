using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalPlayerGameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject goHomeButton;
    [SerializeField]
    private VirtualWorldManager vWM;

    private void Awake()
    {

        if (vWM == null)
        {

            vWM = GameObject.FindGameObjectWithTag("VirtualWorldManager").GetComponent<VirtualWorldManager>();
            ButtonAction();

        }

    }


    public void ButtonAction()
    {

        goHomeButton.GetComponent<Button>().onClick.AddListener(vWM.LeaveRoomAndLoadScene);

    }

}
