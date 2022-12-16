//owen bernard
//a chaque fois qu'une variable joueur change elle passe dans ce code qui réactualise sur le joueur
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class VariableJoueurchanger : MonoBehaviourPunCallbacks, IPunObservable
{

    public int reciv;

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

            //envoie de chaque var vers le mj
            stream.SendNext(GetComponent<VariableDuJoueur>().speed);
            stream.SendNext(GetComponent<VariableDuJoueur>().Life);
            stream.SendNext(GetComponent<VariableDuJoueur>().initiative);
            stream.SendNext(GetComponent<VariableDuJoueur>().acces);
            stream.SendNext(GetComponent<VariableDuJoueur>().modeCombat);
            stream.SendNext(GetComponent<DeplacementJoueur>().step);
        }
        else
        {
            //recup des var
            GetComponent<VariableDuJoueur>().speed = (float)stream.ReceiveNext();
            GetComponent<VariableDuJoueur>().Life = (int)stream.ReceiveNext();
            GetComponent<VariableDuJoueur>().initiative = (float)stream.ReceiveNext();
            GetComponent<VariableDuJoueur>().acces = (bool)stream.ReceiveNext();
            GetComponent<VariableDuJoueur>().modeCombat = (bool)stream.ReceiveNext();
            GetComponent<DeplacementJoueur>().step = (float)stream.ReceiveNext();

            //acces = (bool)stream.ReceiveNext();
            
        }
    }

}
