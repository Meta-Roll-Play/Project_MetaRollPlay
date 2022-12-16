using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotate : MonoBehaviour
{
    [HideInInspector]
    public GameObject rotObject;
    public Vector2 turn ;
  
    public bool colliding;
  
    RaycastHit rayHit;
    void Start()
    {
        
    }
    private void OnMouseEnter()
    {

        if (Input.GetMouseButtonDown(0) )
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit) && rayHit.collider.gameObject.layer == 6)
            {        
                    colliding = true;
          
            }
                
        }
        
    }
    private void OnMouseExit()
    {
        if (Input.GetMouseButtonUp(0))
        {
            colliding = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        OnMouseEnter();
        OnMouseExit();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rotObject.transform.Translate(10f * Time.deltaTime * (-Vector3.forward));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rotObject.transform.Translate(10f * Time.deltaTime * (Vector3.forward));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotObject.transform.Translate(10f * Time.deltaTime * (Vector3.left));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotObject.transform.Translate(10f * Time.deltaTime * (Vector3.right));
        }
        if (Input.GetKey(KeyCode.G))
        {
            rotObject.transform.localScale = rotObject.transform.localScale + new Vector3(0.02f, 0.02f, 0.02f);
        }
        if (Input.GetKey(KeyCode.P))
        {
            rotObject.transform.localScale = rotObject.transform.localScale - new Vector3(0.02f, 0.02f, 0.02f);
        }
        if (colliding == true )
        {
            turn.x += Input.GetAxis("Mouse X");
            rotObject = rayHit.collider.gameObject;
            rotObject.transform.localEulerAngles = new Vector3(0, turn.x * 5, 0);
        }
    

    }



}
