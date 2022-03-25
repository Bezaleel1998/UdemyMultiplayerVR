using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkItemGrabbing : MonoBehaviourPunCallbacks, IPunOwnershipCallbacks
{

    [SerializeField] private PhotonView m_photonView;

    private Rigidbody m_thisItemRigidBoddy;

    private bool _isBeingHeld = false;

    #region Unity Default Methods

    private void Awake()
    {

        m_photonView = this.GetComponent<PhotonView>();
        m_thisItemRigidBoddy = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        IsBeingGrabbed();

    }

    void IsBeingGrabbed()
    {

        if (_isBeingHeld)
        {
            //Object is being helded
            m_thisItemRigidBoddy.isKinematic = true;
            this.gameObject.layer = 11;
        
        }
        else
        {

            //Object has been released
            m_thisItemRigidBoddy.isKinematic = false;
            this.gameObject.layer = 9;

        }

    }

    #endregion


    #region Selected Object / Item

    public void OnSelectEntered()
    {

        Debug.Log("Grabbed");
        m_photonView.RPC("StartNetworkGrabbing", RpcTarget.AllBuffered);

        if (m_photonView.Owner == PhotonNetwork.LocalPlayer)
        {
            Debug.Log("<color=lime>We don't need to request ownership again. Already mine.</color>");
        }
        else
        {
            TransferOwnership();
        }
        
    }

    public void OnSelectedExited()
    {
        Debug.Log("Released");
        m_photonView.RPC("StopNetworkGrabbing", RpcTarget.AllBuffered);
    }

    private void TransferOwnership()
    {

        m_photonView.RequestOwnership();

    }

    #endregion

    #region Photon Request Ownership of the Item & Callback Methods

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {

        if (targetView != m_photonView)
        {
            return; // for differentiate beetween the object / item
        }

        Debug.Log("<color=magenta>Ownership for : " + targetView.name + " Requested From " + requestingPlayer.NickName);
        m_photonView.TransferOwnership(requestingPlayer);

    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {

        Debug.Log("<color=yellow>Ownership for : " + targetView.name + " Transfered From " + previousOwner.NickName);

    }

    public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
    {
        
    }

    [PunRPC] //put this attribute so this function can become RPC method
    public void StartNetworkGrabbing()
    {

        _isBeingHeld = true;

    }
    [PunRPC]
    public void StopNetworkGrabbing()
    {

        _isBeingHeld = false;

    }

    #endregion

}
