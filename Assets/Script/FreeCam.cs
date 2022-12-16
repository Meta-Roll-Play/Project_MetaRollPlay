using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//Fait par Callaghan

public class FreeCam : MonoBehaviourPunCallbacks
{
    // Script that enable to move camera freely
    
    public KeyCode speedup1 = KeyCode.LeftShift;
    public KeyCode speedup2 = KeyCode.RightShift;
    public KeyCode speeddown1 = KeyCode.LeftControl;
    public KeyCode speeddown2 = KeyCode.RightControl;
    public KeyCode climb = KeyCode.Space;
    public KeyCode descend = KeyCode.LeftAlt;
    public KeyCode unlock = KeyCode.Escape;
    
    public float cameraSensitivity = 90;
    public float climbSpeed = 4;
    public float normalMoveSpeed = 10;
    public float slowMoveFactor = 0.25f;
    public float fastMoveFactor = 3;
        
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {

        if (!photonView.IsMine)
        {
            transform.parent.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (!photonView.IsMine)
            return;


        // Rotation

        rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90, 90);
        
        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
        
        // Movement
        
        // Speed modifier up
        if (Input.GetKey(speedup1) || Input.GetKey(speedup2))
        {
            transform.position += transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
            transform.position += transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        // Speed modifier down
        else if (Input.GetKey(speeddown1) || Input.GetKey(speeddown2))
        {
            transform.position += transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
            transform.position += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        else
        //speed modifier none
        {
            transform.position += transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            transform.position += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        
        // Climb
        if (Input.GetKey(climb))
        {
            transform.position += transform.up * climbSpeed * Time.deltaTime;
        }
        // Descend
        else if (Input.GetKey(descend))
        {
            transform.position -= transform.up * climbSpeed * Time.deltaTime;
        }
        
        // Unlock cursor
        if (Input.GetKeyDown(unlock))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}