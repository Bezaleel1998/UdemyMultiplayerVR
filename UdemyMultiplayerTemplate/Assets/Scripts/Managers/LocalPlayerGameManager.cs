using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit;

public class LocalPlayerGameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject goHomeButton;
    [SerializeField]
    private VirtualWorldManager vWM;
    [SerializeField]
    private InputActionManager iAM;
    [SerializeField]
    private XRInteractionManager xRIM;

    [SerializeField]
    private XRDirectInteractor[] baseHandDirInteractor;
    [SerializeField]
    private XRRayInteractor[] rayHandInteractor;

    public void Awake()
    {

        if (vWM == null)
        {

            vWM = GameObject.FindGameObjectWithTag("VirtualWorldManager").GetComponent<VirtualWorldManager>();
            goHomeButton.GetComponent<Button>().onClick.AddListener(() => vWM.LeaveRoomAndLoadScene(true));

        }

        iAM = GameObject.FindGameObjectWithTag("InputActionManager").GetComponent<InputActionManager>();

        xRIM = GameObject.FindGameObjectWithTag("XRInteractionManager").GetComponent<XRInteractionManager>();

        for (int i = 0; i < baseHandDirInteractor.Length; i++)
        {

            baseHandDirInteractor[i].interactionManager = xRIM;
            rayHandInteractor[i].interactionManager = xRIM;

        }

    }

}
