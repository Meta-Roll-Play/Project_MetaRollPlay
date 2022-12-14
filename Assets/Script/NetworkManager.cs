//owen bernard
//network manager
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    public GameObject player;
    public GameObject MJ;
    public Transform startPoint;
    
    [SerializeField] private GameObject InputRoomName;
    private string roomName;


    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion("eu");

        roomName = InputRoomName.GetComponent<TMP_InputField>().text;
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
        PhotonNetwork.JoinOrCreateRoom(roomName, option, null);
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
}
