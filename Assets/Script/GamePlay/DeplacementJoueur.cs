//owen bernard
//deplacement du joueur
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class DeplacementJoueur : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI txtStep;

    public float step;
    public float x;
    public float z;
    Vector3 velocity;

    public GameObject MJcontroller;

    void Start()
    {
        MJcontroller = GameObject.Find("Plane");
    }



    //si le joueur a fini de joué, et qu'il appuis sur le bouton
    public void TaskOnClick()
    {
        if (GetComponent<VariableDuJoueur>().acces)
        {
            MJcontroller.GetComponent<GestionDeTour>().joueurActif +=1;
            GetComponent<VariableDuJoueur>().acces = false;
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (!photonView.IsMine)
            return;

        //si le joueur à accès à ses déplacement et qu'il n'est pas en combat
        if (GetComponent<VariableDuJoueur>().acces)
        {

            //affichage texte
            txtStep.text = string.Concat("Pas restant : ", Mathf.RoundToInt(step + 0.5f));



            if (!GetComponent<VariableDuJoueur>().modeCombat)
            {


                if (velocity.y < 0)
                {
                    velocity.y = -2f;
                }
                //input ZQSD
                x = Input.GetAxis("Horizontal") * -1;
                z = Input.GetAxis("Vertical") * -1;

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
            else//si il est en mode combat
            {
                //si il reste au joueur des pas il peut bouger 

                if (step > 0)
                {

                    if (velocity.y < 0)
                    {
                        velocity.y = -2f;
                    }
                    //input ZQSD
                    x = Input.GetAxis("Horizontal") * -1;
                    z = Input.GetAxis("Vertical") * -1;

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
                        step -= Time.deltaTime;
                    }


                }
                else
                {
                    //reset du mouvement
                    x = 0;
                    z = 0;
                    GetComponent<VariableDuJoueur>().controller.Move(new Vector3(0f, 0f, 0f));

                }
            }

        }
    }
}
