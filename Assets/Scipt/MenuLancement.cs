using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/*************************************************************************************
 *
 *  Hugo SIMON
 * 
 *  This script is for the UI of the lobby
 * 
 ************************************************************************************/

public class MenuLancement : MonoBehaviour
{
    [SerializeField] private GameObject MenuBase;
    [SerializeField] private GameObject MenuHost;
    [SerializeField] private GameObject MenuJoin;

    [SerializeField] private GameObject IP;

    private List<string> listeIP = new List<string>();
    
    private void Awake()
    {
        MenuBase.SetActive(true);
        MenuHost.SetActive(false);
        MenuJoin.SetActive(false);

        var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                listeIP.Add(ip.ToString());
            }
        }
        
        IP.GetComponent<TMP_Dropdown>().ClearOptions();
        IP.GetComponent<TMP_Dropdown>().AddOptions(options: listeIP);

    }

    public void HostBase()
    {
        MenuBase.gameObject.SetActive(false);
        MenuHost.gameObject.SetActive(true);
    }
    
    public void JoinBase()
    {
        MenuBase.gameObject.SetActive(false);
        MenuJoin.gameObject.SetActive(true);
    }
    
    public void LancementPartie()
    {
        MenuBase.gameObject.SetActive(false);
        MenuHost.gameObject.SetActive(false);
        MenuJoin.gameObject.SetActive(false);
    }
}
