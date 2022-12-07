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
    public float mouseX;
    public float xRotation;
    public float sensi;

    [Header("Possession")]
    public bool acces;
    public bool modeCombat;

    private void Update()
    {


        //visibilité de la souris
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


        //rotation du personnage
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensi;
        xRotation += mouseX;
        transform.rotation = Quaternion.Euler(0, xRotation, 0);
    }


}
