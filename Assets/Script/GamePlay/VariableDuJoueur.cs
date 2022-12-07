//Owen bernard
//variable de base du joueur
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableDuJoueur : MonoBehaviour
{
    public CharacterController controller;
    [Header("Attribut")]
    public int Life;

    [Header("Movement")]
    public float speed;

    [Header("Camera")]
    public Transform orientation;
    public float rotationSpeed;
    public Transform camer;

    [Header("Possession")]
    public bool acces;
    public bool modeCombat;


}
