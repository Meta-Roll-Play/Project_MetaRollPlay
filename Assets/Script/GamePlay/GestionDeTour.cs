//owen bernard
//tout les joueurs hors MJ sont inserer dans une liste
//le mj peut selectionner un ou plusieur joueur de la liste pour lui changer des variables comme la disponibilité de déplacement, le mode Combat etc...
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionDeTour : MonoBehaviour
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

    private void Start()
    {
        for(int i = 0; i < GameObject.Find("PlayerManager").transform.childCount ; i++)
        {
            listJoueur.Add(GameObject.Find("PlayerManager").transform.GetChild(i).gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

        //si tout les joueurs sont selectionner,
        if (all)
        {
            selection = -1;

        }//sinon le MJ choisi un joueur
        else
        {
            if (selection > GameObject.Find("PlayerManager").transform.childCount)
            {
                selection = 0;
            }
            if (selection < 0)
            {
                selection = GameObject.Find("PlayerManager").transform.childCount;
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
