//owen bernard
//tout les joueurs hors MJ sont inserer dans une liste
//le mj peut selectionner un ou plusieur joueur de la liste pour lui changer des variables comme la disponibilité de déplacement, le mode Combat etc...
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;


public class GestionDeTour : MonoBehaviourPunCallbacks
{

    //selection de Joueur
    [Header("Variable de joueur")]
    public List<GameObject> listJoueur;
    public bool all;
    public int selection;
    //changement des variables du joueur
    public int step;
    public bool modeCombat;
    public bool acces;
    //envoyer les variables selectionner
    public bool send;


    //trier les joueurs par initiative
    public int joueurActif;


    // Update is called once per frame
    void Update()
    {

        if (listJoueur.Count > 0)
        {
            //quand tout les joueurs on joué, joueurActif > GameObject.Find("PlayerManager").transform.childCount-1, trier chaque joueur par initiative
            if (joueurActif > listJoueur.Count - 1)
            {
                for (int i = 0; i < listJoueur.Count - 1; i++)
                {
                    if (listJoueur[i].GetComponent<VariableDuJoueur>().initiative < listJoueur[i + 1].GetComponent<VariableDuJoueur>().initiative)
                    {
                        GameObject tmp = listJoueur[i];
                        listJoueur[i] = listJoueur[i + 1];
                        listJoueur[i + 1] = tmp;
                    }
                }
                joueurActif = 0;
            }
            //mettre les accès au joueur actif, les enlever au autre
            for (int i = 0; i < listJoueur.Count; i++)
            {
                if (i != joueurActif)
                {
                    listJoueur[i].GetComponent<VariableDuJoueur>().acces = false;
                }
                else
                {
                    listJoueur[joueurActif].GetComponent<VariableDuJoueur>().acces = true;
                }
            }
        }

        //gestion des variables par le MJ
        //si tout les joueurs sont selectionner,
        if (all)
        {
            selection = -1;

        }//sinon le MJ choisi un joueur
        else
        {
            if (selection >= listJoueur.Count)
            {
                selection = 0;
            }
            if (selection < 0)
            {
                selection = listJoueur.Count;
            }
        }

        //si le mj valide
        if (send)
        {
            send = false;
            if (all)
            {
                //si tout les joueurs sont selectionner, leurs donner les valeurs écrite
                for (int j = 0; j < listJoueur.Count; j++)
                {
                    listJoueur[j].GetComponent<VariableDuJoueur>().acces = acces;
                    listJoueur[j].GetComponent<VariableDuJoueur>().modeCombat = modeCombat;
                    listJoueur[j].GetComponent<DeplacementJoueur>().step = step;
                }
            }
            else
            {
                listJoueur[selection].GetComponent<VariableDuJoueur>().acces = acces;
                listJoueur[selection].GetComponent<VariableDuJoueur>().modeCombat = modeCombat;
                listJoueur[selection].GetComponent<DeplacementJoueur>().step = step;
            }
            acces = false;
            modeCombat = false;
            step = 0;
        }
    }
}
