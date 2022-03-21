using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class LocalPlayerGameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject goHomeButton;
    [SerializeField]
    private VirtualWorldManager vWM;
    [SerializeField]
    private InputActionManager xRIM;

    public void Awake()
    {

        if (vWM == null)
        {

            vWM = GameObject.FindGameObjectWithTag("VirtualWorldManager").GetComponent<VirtualWorldManager>();
            goHomeButton.GetComponent<Button>().onClick.AddListener(vWM.LeaveRoomAndLoadScene);

        }

        xRIM = GameObject.FindGameObjectWithTag("InputActionManager").GetComponent<InputActionManager>();

    }

}
