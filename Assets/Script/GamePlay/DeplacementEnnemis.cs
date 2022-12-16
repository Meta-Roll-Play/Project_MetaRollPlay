//owen bernard
//deplacement du joueur
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Unity.VisualScripting;

public class DeplacementEnnemis : MonoBehaviourPunCallbacks
{

    public CharacterController controller;
    [Header("Attribut")]
    public int Life;
    public float initiative;

    [Header("Movement")]
    public float speed;

    [Header("Camera du MJ")]
    public float rotationSpeed;
    public Transform camer;
    public Transform orientation;
    public float mouseX;
    public float mouseY;
    public float xRotation;
    public float yRotation;
    public float sensi;

    [Header("Possession")]
    public bool possession;
    public bool acces;
    public bool modeCombat;

    public bool canAttack;
    public bool isAttack;


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
        camer = MJcontroller.transform.GetChild(0).GetChild(2).transform;
    }


    // Update is called once per frame
    void Update()
    {

        if (Life <= 0)
        {
            if (possession)
            {
                MJcontroller.transform.GetChild(0).GetComponent<PossessionMJ>().possession = false;
            }
            Destroy(gameObject);
        }

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
            Vector3 viewDirection = orientation.position - new Vector3(camer.position.x, orientation.position.y, camer.position.z);
            orientation.forward = viewDirection.normalized;


            //set up en vector3
            Vector3 move = orientation.forward * z + orientation.right * x;

            //si pas immobile
            if (move != Vector3.zero)
            {
                //deplacement
                controller.Move(move * speed * Time.deltaTime);
                orientation.forward = Vector3.Lerp(orientation.forward, move.normalized, Time.deltaTime * rotationSpeed);
            }

        }
        else//si il est en mode combat
        {



            if (canAttack && anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && isAttack)
            {
                canAttack = false;
                anim.SetBool("IsAttack", false);
                isAttack = false;
            }


            if (Input.GetMouseButtonDown(0))
            {

                if (canAttack && !isAttack)
                {
                    isAttack = true;
                    anim.SetBool("IsAttack",true);
                }
            }




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
                Vector3 viewDirection = orientation.position - new Vector3(camer.position.x, orientation.position.y, camer.position.z);
                orientation.forward = viewDirection.normalized;


                //set up en vector3
                Vector3 move = orientation.forward * z + orientation.right * x;

                //si pas immobile
                if (move != Vector3.zero)
                {
                    //deplacement
                    controller.Move(move * speed * Time.deltaTime);
                    orientation.forward = Vector3.Lerp(orientation.forward, move.normalized, Time.deltaTime * rotationSpeed);
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
        transform.LookAt(orientation.transform.position);
        transform.rotation = Quaternion.Euler(transform.rotation.x,0,transform.rotation.z);

    }
}
