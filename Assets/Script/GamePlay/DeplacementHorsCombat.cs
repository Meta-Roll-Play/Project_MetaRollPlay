//owen bernard
//deplacement du joueur lorsqu'il n'est pas en combat
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DeplacementHorsCombat : MonoBehaviour
{

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
        
        //si le joueur à accès à ses déplacement et qu'il n'est pas en combat

        if (GetComponent<VariableDuJoueur>().acces && !GetComponent<VariableDuJoueur>().modeCombat)
        {

            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }



            //input ZQSD
            float x = Input.GetAxis("Horizontal")*-1;
            float z = Input.GetAxis("Vertical")*-1;

            //rotate
            Vector3 viewDirection = transform.position - new Vector3(GetComponent<VariableDuJoueur>().camer.position.x, transform.position.y, GetComponent<VariableDuJoueur>().camer.position.z);
            GetComponent<VariableDuJoueur>().orientation.forward = viewDirection.normalized;


            //set up en vector3
            Vector3 move = GetComponent<VariableDuJoueur>().orientation.forward * z + GetComponent<VariableDuJoueur>().orientation.right * x;

            //si pas immobile
            if (move != Vector3.zero)
            {
                //deplacement
                GetComponent<VariableDuJoueur>().controller.Move(move * GetComponent<VariableDuJoueur>().speed * Time.deltaTime);
                transform.forward = Vector3.Lerp(transform.forward, move.normalized, Time.deltaTime * GetComponent<VariableDuJoueur>().rotationSpeed);
            }
        }

    }
}
