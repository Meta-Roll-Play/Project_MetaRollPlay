using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*************************************************************************************
 * 
 *  Permet de créer un fichier txt contenant les stats du joueurs, le nom du fichier est [nom du joueur].txt
 *
 * Hugo Simon
 * 
 ************************************************************************************/

public class FicheTxtWrite : MonoBehaviour
{
    private string path;

    //NOM
    [SerializeField] private GameObject Name;
    [SerializeField] private GameObject Titre;
    [SerializeField] private GameObject RaceDropdown;
    [SerializeField] private GameObject Description;
    //STATS
    [SerializeField] private GameObject CanvasPV;
    [SerializeField] private GameObject Force;
    [SerializeField] private GameObject Intelligence;
    [SerializeField] private GameObject Perception;
    [SerializeField] private GameObject Dexterite;
    [SerializeField] private GameObject Endurance;
    [SerializeField] private GameObject Charisme;

    private void CreateTxtFile(string name)
    {
        path = Application.dataPath + "/Fiches/" + name + ".txt";
        File.WriteAllText(path, "Fiche personnage de : " + name + "\n\n");
        File.AppendAllText(path, "name " + name + "\n");
    }

    public void Personnage()
    {
        CreateTxtFile(Name.GetComponent<TMP_InputField>().text);
        
        // Race et Titre
        File.AppendAllText(path, 
            "race " + RaceDropdown.GetComponent<TMP_Dropdown>().options[RaceDropdown.GetComponent<TMP_Dropdown>().value].text + "\n"
            + "titre " + Titre.GetComponent<TMP_InputField>().text + "\n\n");
        
        // Stats
        File.AppendAllText(path,
            "HP " + CanvasPV.GetComponent<FicheUI>().RaceStructs[RaceDropdown.GetComponent<TMP_Dropdown>().value].HpMax + "\n"
            + "HPMax " + CanvasPV.GetComponent<FicheUI>().RaceStructs[RaceDropdown.GetComponent<TMP_Dropdown>().value].HpMax + "\n"
            + "Force " + Force.GetComponent<Slider>().value + "\n"
            + "Intelligence " + Intelligence.GetComponent<Slider>().value + "\n"
            + "Perception " + Perception.GetComponent<Slider>().value + "\n"
            + "Dexterite " + Dexterite.GetComponent<Slider>().value + "\n"
            + "Endurance " + Endurance.GetComponent<Slider>().value + "\n"
            + "Charisme " + Charisme.GetComponent<Slider>().value + "\n\n");
    }
}
