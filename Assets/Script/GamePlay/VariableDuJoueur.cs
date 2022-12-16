//Owen bernard
//variable de base du joueur
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class VariableDuJoueur : MonoBehaviourPunCallbacks
{
    public CharacterController controller;
    [Header("Attribut")]
    public int Life;
    public float initiative;


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

    [Header("Animation")]
    public Animator anim;
    public string animationIsPlaying;


    public void Start()
    {
        this.gameObject.transform.parent = GameObject.Find("PlayerManager").transform;
        if (!photonView.IsMine)
        {
            transform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(10).gameObject.SetActive(false);
        }
        GameObject.Find("GestionMJManager").GetComponent<GestionDeTour>().listJoueur.Add(transform.gameObject);
    }


    private void Update()
    {

        if (!photonView.IsMine)
            return;

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


        //animation de déplacement du personnage
        //animation
        if ((GetComponent<DeplacementJoueur>().x != 0 || GetComponent<DeplacementJoueur>().z != 0))
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }




        //rotation du personnage
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensi;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensi;


        xRotation += mouseX;
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(0, xRotation, 0);
        orientation.rotation = Quaternion.Euler(yRotation, xRotation, 0);



        //l'animation qui est entrain d'etre joué
        animationIsPlaying = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
    }


}
