using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CollisionArme : MonoBehaviourPunCallbacks
{
    public GameObject parent;

    private void OnTriggerEnter(Collider other)
    {
        //si le parent n'est pas l'objet qui controlle l'arme
        if (other.name != parent.name)
        {

            //si le parent est un joueur et que l'autre n'en est pas un
            if (parent.GetComponent<VariableDuJoueur>() != null && other.GetComponent<DeplacementEnnemis>() != null)
            {

                //alors si le joueur est en train d'attaquer enlever de la vie a l'ennemis
                if (parent.GetComponent<VariableDuJoueur>().isAttack)
                {
                    other.GetComponent<DeplacementEnnemis>().Life -= 5;
                }


            }else
            {

                //si le parent est un ennemis
                if (parent.GetComponent<DeplacementEnnemis>() != null && other.GetComponent<VariableDuJoueur>() != null)
                {
                    if (parent.GetComponent<DeplacementEnnemis>().isAttack)
                    {
                        other.GetComponent<VariableDuJoueur>().Life -= 5;
                    }
                }
            }
        }
    }
}
