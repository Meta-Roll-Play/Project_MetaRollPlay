//owen bernard
//a chaque fois qu'une variable MJ change elle passe dans ce code qui réactualise sur le mj
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System;

public class VariableMJChange : MonoBehaviourPunCallbacks, IPunObservable
{
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {

            //envoie de chaque var vers le mj
            stream.SendNext(GetComponent<GestionDeTour>().all);
            stream.SendNext(GetComponent<GestionDeTour>().selection);
            stream.SendNext(GetComponent<GestionDeTour>().step);
            stream.SendNext(GetComponent<GestionDeTour>().modeCombat);
            stream.SendNext(GetComponent<GestionDeTour>().acces);
            stream.SendNext(GetComponent<GestionDeTour>().send);
            stream.SendNext(GetComponent<GestionDeTour>().joueurActif);


            if (GetComponent<GestionDeTour>().send)
            {
                if (GetComponent<GestionDeTour>().listJoueur.Count != 0)
                {
                    GetComponent<GestionDeTour>().listJoueur[GetComponent<GestionDeTour>().selection].GetComponent<VariableJoueurchanger>().reciv = 1;
                    stream.SendNext(GetComponent<GestionDeTour>().listJoueur[GetComponent<GestionDeTour>().selection].GetComponent<VariableJoueurchanger>().reciv);
                }
            }
            else
            {
                if (GetComponent<GestionDeTour>().listJoueur.Count != 0)
                {
                    GetComponent<GestionDeTour>().listJoueur[GetComponent<GestionDeTour>().selection].GetComponent<VariableJoueurchanger>().reciv = 0;
                    stream.SendNext(GetComponent<GestionDeTour>().listJoueur[GetComponent<GestionDeTour>().selection].GetComponent<VariableJoueurchanger>().reciv);
                }
            }


        }
        else
        {
            //recup des var
            GetComponent<GestionDeTour>().all = (bool)stream.ReceiveNext();
            GetComponent<GestionDeTour>().selection = (int)stream.ReceiveNext();
            GetComponent<GestionDeTour>().step = (int)stream.ReceiveNext();
            GetComponent<GestionDeTour>().modeCombat = (bool)stream.ReceiveNext();
            GetComponent<GestionDeTour>().acces = (bool)stream.ReceiveNext();
            GetComponent<GestionDeTour>().send = (bool)stream.ReceiveNext();
            GetComponent<GestionDeTour>().joueurActif = (int)stream.ReceiveNext();
            if (GetComponent<GestionDeTour>().listJoueur.Count != 0 && stream.Count >10 )
            {
                GetComponent<GestionDeTour>().listJoueur[GetComponent<GestionDeTour>().selection].GetComponent<VariableJoueurchanger>().reciv = (int)stream.ReceiveNext();

                if (GetComponent<GestionDeTour>().listJoueur[GetComponent<GestionDeTour>().selection].GetComponent<VariableJoueurchanger>().reciv == 1)
                {
                    GetComponent<GestionDeTour>().listJoueur[GetComponent<GestionDeTour>().selection].GetComponent<VariableJoueurchanger>().reciv = 2;
                    GetComponent<GestionDeTour>().listJoueur[GetComponent<GestionDeTour>().selection].GetComponent<DeplacementJoueur>().step = GetComponent<GestionDeTour>().step;
                    GetComponent<GestionDeTour>().listJoueur[GetComponent<GestionDeTour>().selection].GetComponent<VariableDuJoueur>().modeCombat = GetComponent<GestionDeTour>().modeCombat;
                    GetComponent<GestionDeTour>().listJoueur[GetComponent<GestionDeTour>().selection].GetComponent<VariableDuJoueur>().acces = GetComponent<GestionDeTour>().acces;
                }
            }
        }
    }
}
