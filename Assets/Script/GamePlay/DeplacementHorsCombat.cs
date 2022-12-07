//owen bernard
//deplacement du joueur lorsqu'il n'est pas en combat
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DeplacementHorsCombat : MonoBehaviour
{

    public CharacterController controller;
    [Header("Attribut")]
    public int Life;

    [Header("Movement")]
    private float flatSpeed = 5f;
    public float speed = 0f;

    [Header("Camera")]
    public Transform orientation;
    public float rotationSpeed;
    public Transform camer;


    Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        /*lock du curseur
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        */
    }

    // Update is called once per frame
    void Update()
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


        if (velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //input ZQSD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //rotate
        Vector3 viewDirection = transform.position - new Vector3(camer.position.x, transform.position.y, camer.position.z);
        orientation.forward = viewDirection.normalized;


        //set up en vector3
        Vector3 move = orientation.forward * z + orientation.right * x;

        //si pas immobile
        if (move != Vector3.zero)
        {
            //deplacement
            controller.Move(move * speed * Time.deltaTime);
            transform.forward = Vector3.Lerp(transform.forward, move.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}
