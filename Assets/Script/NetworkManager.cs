//owen bernard
//network manager
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public GameObject player;
    public GameObject MJ;
    public Transform startPoint;


    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion("eu");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("je suis connecter");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("j'ai rejoins le lobby");
        CreateRoom();
    }


    void CreateRoom()
    {
        RoomOptions option = new RoomOptions();
        option.IsOpen = true;
        option.IsVisible = true;
        PhotonNetwork.JoinOrCreateRoom("HUB", option, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("j'ai rejoint la salle :" + PhotonNetwork.CurrentRoom.Name);
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(MJ.name, startPoint.position, Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate(player.name, startPoint.position, Quaternion.identity);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
