using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginUIManager : MonoBehaviour
{

    [Header("UIGameObject")]
    public GameObject connectOptionsPanelGameObject;
    public GameObject connectWithNamePanelGameObject;

    #region Unity Methods

    private void Awake()
    {

        connectOptionsPanelGameObject.SetActive(true);
        connectWithNamePanelGameObject.SetActive(false);

    }

    #endregion

}
