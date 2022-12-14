using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

/*************************************************************************************
 *
 *  This script is just for the Button UI to create/join a room
 *
 *  Hugo Simon
 * 
 *************************************************************************************/

public class ButtonJoinCreate : MonoBehaviour
{
    [SerializeField] private GameObject Button;

    private void Awake()
    {
        Button.GetComponent<UnityEngine.UI.Button>().interactable = false;
    }

    public void OnInputFieldChanged()
    {
        if (gameObject.GetComponent<TMP_InputField>().text == "")
        {
            Button.GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        else
        {
            Button.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
    }
}