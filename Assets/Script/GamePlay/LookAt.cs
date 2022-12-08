//owen bernard
//savoir quel object la caméra regarde
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    //le parent
    public GameObject parent;

    //l'objet trouver
    public GameObject lookAt;
    //l'objet garder en memoire
    public GameObject colliderActif;


    public int vitesse = 50;
    public int distanceMax = 20;


    private void OnTriggerEnter(Collider other)
    {
        lookAt = other.gameObject;
    }

    // Update is called once per frame
    void Update()
    { 
        if (colliderActif != null)
        {
            //si l'objet trouver est différent que l'objet en mémoire
            if (lookAt.name != colliderActif.name)
            {
                if (colliderActif.GetComponent<Outline>() != null)
                {
                    colliderActif.GetComponent<Outline>().enabled = false;
                    colliderActif = lookAt;
                    if (colliderActif.GetComponent<Outline>() != null)
                    {
                        colliderActif.GetComponent<Outline>().enabled = true;
                    }
                }
                else
                {
                    colliderActif = lookAt;
                    if (colliderActif.GetComponent<Outline>() != null)
                    {
                        colliderActif.GetComponent<Outline>().enabled = true;
                    }
                }

                transform.position = parent.transform.position;
            }
        }
        else
        {
            if (lookAt != null)
            {
                if (lookAt.GetComponent<Outline>() != null)
                {
                    colliderActif = lookAt;
                    colliderActif.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    colliderActif = lookAt;
                }
                transform.position = parent.transform.position;
            }
        }



        //tant qu'aucun objet est trouver pour distance max atteinte aller plus loin
        GetComponent<Rigidbody>().velocity = transform.forward * (vitesse);
        if (Mathf.Sqrt(Mathf.Pow(transform.position.x-parent.transform.position.x, 2) + Mathf.Pow(transform.position.z - parent.transform.position.z, 2))>= distanceMax)
        {
            transform.position = parent.transform.position;
        }

    }
}
