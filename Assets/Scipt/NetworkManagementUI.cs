using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagementUI : MonoBehaviour
{
    [SerializeField] private Button BTNHost;
    [SerializeField] private Button BTNClient;

    private void Awake()
    {
        BTNHost.onClick.AddListener(() => {NetworkManager.Singleton.StartHost();});
        BTNClient.onClick.AddListener(() => {NetworkManager.Singleton.StartClient();});
    }
}
