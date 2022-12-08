using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

/************************************************************************************
 *
 *  Hugo SIMON
 * 
 *  This script is attached to the NetworkManager object in the scene.
 *  It is responsible for setting up the network and connecting to the server.
 * 
 ************************************************************************************/

public class NetworkManagementUI : MonoBehaviour
{
    [SerializeField] private Button BTNHost;
    [SerializeField] private Button BTNClient;
    
    [SerializeField] private GameObject IPChoiceHost;
    [SerializeField] private GameObject PortInputHost;
    
    [SerializeField] private GameObject IPInputClient;
    [SerializeField] private GameObject PortInputClient;

    private void Awake()
    {
        BTNHost.onClick.AddListener(() => 
        {
            if (NetworkManager.Singleton.IsListening)
            {
                NetworkManager.Singleton.Shutdown();
            }

            var LeIp = IPChoiceHost.GetComponent<TMP_Dropdown>().options[IPChoiceHost.GetComponent<TMP_Dropdown>().value].text;
            var LePort = PortInputHost.GetComponent<TMP_InputField>().text;
            
            gameObject.GetComponent<UnityTransport>().ConnectionData.Address = LeIp;
            gameObject.GetComponent<UnityTransport>().ConnectionData.Port = ushort.Parse(LePort);
            
            NetworkManager.Singleton.StartHost();
        });
        BTNClient.onClick.AddListener(() =>
        {
            var LeIp = IPInputClient.GetComponent<TMP_InputField>().text;
            var LePort = PortInputClient.GetComponent<TMP_InputField>().text;
            
            gameObject.GetComponent<UnityTransport>().ConnectionData.Address = LeIp;
            gameObject.GetComponent<UnityTransport>().ConnectionData.Port = ushort.Parse(LePort);
            
            NetworkManager.Singleton.StartClient();
        });
    }
}
