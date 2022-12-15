//owen bernard
//deplacement du joueur
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class DeplacementEnnemis : MonoBehaviourPunCallbacks
{

    public CharacterController controller;
    [Header("Attribut")]
    public int Life;
    public float initiative;

    [Header("Movement")]
    public float speed;

    [Header("Camera du MJ")]
    public Transform orientation;
    public float rotationSpeed;
    public Transform camer;
    public float mouseX;
    public float mouseY;
    public float xRotation;
    public float yRotation;
    public float sensi;

    [Header("Possession")]
    public bool possession;
    public bool acces;
    public bool modeCombat;

    [Header("Animation")]
    public Animator anim;
    public string animationIsPlaying;

    public float step;
    public float x;
    public float z;
    Vector3 velocity;

    public GameObject MJcontroller;

    void Start()
    {
        MJcontroller = GameObject.Find("MJController(Clone)");
        camer = MJcontroller.transform.GetChild(0).GetChild(1).transform;
        orientation = MJcontroller.transform.GetChild(2).transform;
    }


    // Update is called once per frame
    void Update()
    {

        if (!possession || !acces)
            return;

        //si le mj à accès à ses déplacement et qu'il n'est pas en combat

        if (!modeCombat)
        {


            if (velocity.y < 0)
            {
                velocity.y = -2f;
            }
            //input ZQSD
            x = Input.GetAxis("Horizontal") * -1;
            z = Input.GetAxis("Vertical") * -1;

            //rotate
            Vector3 viewDirection = transform.position - new Vector3(GetComponent<DeplacementEnnemis>().camer.position.x, transform.position.y, GetComponent<DeplacementEnnemis>().camer.position.z);
            GetComponent<DeplacementEnnemis>().orientation.forward = viewDirection.normalized;


            //set up en vector3
            Vector3 move = GetComponent<DeplacementEnnemis>().orientation.forward * z + GetComponent<DeplacementEnnemis>().orientation.right * x;

            //si pas immobile
            if (move != Vector3.zero)
            {
                //deplacement
                GetComponent<DeplacementEnnemis>().controller.Move(move * GetComponent<DeplacementEnnemis>().speed * Time.deltaTime);
                transform.forward = Vector3.Lerp(transform.forward, move.normalized, Time.deltaTime * GetComponent<DeplacementEnnemis>().rotationSpeed);
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
                Vector3 viewDirection = transform.position - new Vector3(GetComponent<DeplacementEnnemis>().camer.position.x, transform.position.y, GetComponent<DeplacementEnnemis>().camer.position.z);
                GetComponent<DeplacementEnnemis>().orientation.forward = viewDirection.normalized;


                //set up en vector3
                Vector3 move = GetComponent<DeplacementEnnemis>().orientation.forward * z + GetComponent<DeplacementEnnemis>().orientation.right * x;

                //si pas immobile
                if (move != Vector3.zero)
                {
                    //deplacement
                    GetComponent<DeplacementEnnemis>().controller.Move(move * GetComponent<DeplacementEnnemis>().speed * Time.deltaTime);
                    transform.forward = Vector3.Lerp(transform.forward, move.normalized, Time.deltaTime * GetComponent<DeplacementEnnemis>().rotationSpeed);
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
