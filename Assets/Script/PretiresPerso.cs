using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/************************************************************************************
 * 
 *  Hugo Simon
 * 
 ************************************************************************************/

public class PretiresPerso : MonoBehaviour
{
    [SerializeField] private GameObject texte;
    [SerializeField] private GameObject windowsManager;
    public struct Prefab
    {
        public string nom, titre, description, competence, equipement;
        public int force, intelligence, perception, dexterite, endurance, charisme, race;
    }
    public Prefab[] listePrefab = new Prefab[7];

    public void SavePretir(int index)
    {
        texte.GetComponent<FicheTxtWrite>().Name.GetComponent<TMP_InputField>().text = listePrefab[index].nom;
        texte.GetComponent<FicheTxtWrite>().Titre.GetComponent<TMP_InputField>().text = listePrefab[index].titre;
        texte.GetComponent<FicheTxtWrite>().Description.GetComponent<TMP_InputField>().text = listePrefab[index].description;
        texte.GetComponent<FicheTxtWrite>().Comp.GetComponent<TMP_InputField>().text = listePrefab[index].competence;
        texte.GetComponent<FicheTxtWrite>().Equipment.GetComponent<TMP_InputField>().text = listePrefab[index].equipement;

        /*texte.AddComponent<FicheTxtWrite>().RaceDropdown.GetComponent<TMP_Dropdown>().value = listePrefab[index].race;
        
        texte.AddComponent<FicheTxtWrite>().Force.GetComponent<Slider>().value = listePrefab[index].force;
        texte.AddComponent<FicheTxtWrite>().Intelligence.GetComponent<Slider>().value = listePrefab[index].intelligence;
        texte.AddComponent<FicheTxtWrite>().Perception.GetComponent<Slider>().value = listePrefab[index].perception;
        texte.AddComponent<FicheTxtWrite>().Dexterite.GetComponent<Slider>().value = listePrefab[index].dexterite;
        texte.AddComponent<FicheTxtWrite>().Endurance.GetComponent<Slider>().value = listePrefab[index].endurance;
        texte.AddComponent<FicheTxtWrite>().Charisme.GetComponent<Slider>().value = listePrefab[index].charisme;*/
    }

    public void Awake()
    {
        //Medda
        listePrefab[0].nom = "Medda";
        listePrefab[0].titre = "Chevali??re";
        listePrefab[0].race = 0;
        listePrefab[0].description =
            "Originaire de Daenasythe, elle reste fid??le ?? ses valeurs et combat pour son peuple";
        listePrefab[0].force = 2;
        listePrefab[0].intelligence = 1;
        listePrefab[0].perception = 1;
        listePrefab[0].dexterite = 1;
        listePrefab[0].endurance = 2;
        listePrefab[0].charisme = 1;
        listePrefab[0].competence = "Ep??e [Niv 2], Equitation [Niv 2], Orientation [Niv 2]";
        listePrefab[0].equipement = "Ep??e ?? deux mains (Dgts 8)/Armure de chevalier (Protecc 7, ESQ-1)/40 Pi??ces d'or";
        
        //Karaboh
        listePrefab[1].nom = "Karaboh";
        listePrefab[1].titre = "Lutteur";
        listePrefab[1].race = 1;
        listePrefab[1].description =
            "Grand champion des trois derniers tournois de lutte krobhs, sa force n'est plus ?? d??montrer";
        listePrefab[1].force = 6;
        listePrefab[1].intelligence = -4;
        listePrefab[1].perception = 0;
        listePrefab[1].dexterite = -3;
        listePrefab[1].endurance = 4;
        listePrefab[1].charisme = 3;
        listePrefab[1].competence = "Social - Intimidation [Niv 1], Social - Sens du spectable [Niv 1], Lutte [Niv 3]";
        listePrefab[1].equipement =
            "Parure de pince honorifique (D??g??ts +3 ?? la pince, CHA+2)/Ceinture de champion (CHA+1)/Slip de lutteur Gokrobh (Protection 0)/30 Pi??ces d'or";
        
        //Jade 
        listePrefab[2].nom = "Jade";
        listePrefab[2].titre = "B??tisseuse";
        listePrefab[2].race = 2;
        listePrefab[2].description =
            "Originaire des ??les C??lestes, sa connaissance des mat??riaux et sa force physique en font une b??tisseuse hors paire";
        listePrefab[2].force = 2;
        listePrefab[2].intelligence = 0;
        listePrefab[2].perception = -2;
        listePrefab[2].dexterite = 1;
        listePrefab[2].endurance = 6;
        listePrefab[2].charisme = -1;
        listePrefab[2].competence = "Ma??onnerie [Niv 3], Pugilat [Niv 1], Connaissance - m??t??orologie [Niv 2]";
        listePrefab[2].equipement =
            "Pic de sculpture (D??g??ts 2, ATK-1)/Tunique Min??leste (Protection 1)/Sac de gravier (Nourriture & Artisanat, Permet de r??cup??rer 5 PV chaque jour)/40 Pi??ces d'or";
        
    }
}
