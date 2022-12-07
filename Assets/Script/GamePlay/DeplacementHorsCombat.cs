//owen bernard
//deplacement du joueur lorsqu'il n'est pas en combat
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeplacementHorsCombat : MonoBehaviour
{

    [Header("Rotation du personnage")]
    public Transform orientation;
    public float rotationSpeed;


    // Update is called once per frame
    void Update()
    {
        //bloquage du curseur
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

        /*
        if (GetComponent<VariableDuJoueur>().velocity.y < 0)
        {
            GetComponent<VariableDuJoueur>().velocity.y = -2f;
        }

        //si le joueur à acces et qu'il n'est pas en combat
        if (GetComponent<VariableDuJoueur>().acces)
        {
            if (!GetComponent<VariableDuJoueur>().modeCombat)
            {

                //input ZQSD
                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");

                //orientation en fonction de la souris
                Vector3 viewDirection = transform.position - new Vector3(MouseCursor.position.x, transform.position.y, MouseCursor.position.z);
                orientation.forward = viewDirection.normalized;

                Vector3 move = orientation.forward * z + orientation.right * x;

                //mouvement du personnage
                if (move != Vector3.zero)
                {
                    //deplacement
                    GetComponent<VariableDuJoueur>().controllePlayer.Move(move * GetComponent<VariableDuJoueur>().speed * Time.deltaTime);
                    transform.forward = Vector3.Lerp(transform.forward, move.normalized, Time.deltaTime * rotationSpeed);
                }
            }
        }*/
    }
}
