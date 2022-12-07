using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : NetworkBehaviour
{
    private void Update()
    {
        if (!IsOwner) return;
        
        Vector3 MoveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Z))
        {
            MoveDir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveDir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            MoveDir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveDir += Vector3.right;
        }

        transform.position += MoveDir * (Time.deltaTime * 5f);
        
        Debug.Log(IPManager.GetLocalIPAddress());
    }
    
    public static class IPManager
    {
        public static string GetLocalIPAddress()
        {
            string localIP = "";
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP += ip.ToString() + "\n";
                }
            }

            return localIP;

            throw new System.Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
