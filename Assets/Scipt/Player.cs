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
    }
}
