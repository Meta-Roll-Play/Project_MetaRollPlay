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
    public float mouseY;
    public float xRotation;
    public float yRotation;
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
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensi;
        

        xRotation += mouseX;
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(0, xRotation, 0);
        orientation.rotation = Quaternion.Euler(yRotation,xRotation, 0);
    }


}
