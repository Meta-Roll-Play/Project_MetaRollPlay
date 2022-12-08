using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class ListeJoueur : MonoBehaviour
{
    [SerializeField] private GameObject texte1;
    
    public void Update()
    {
        Debug.Log(NetworkManager.ServerClientId);
    }
}
