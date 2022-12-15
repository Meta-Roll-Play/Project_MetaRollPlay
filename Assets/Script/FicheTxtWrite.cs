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
    public GameObject Name;
    public GameObject Titre;
    public GameObject RaceDropdown;
    public GameObject Description;
    //STATS
    public GameObject CanvasPV;
    public GameObject Force;
    public GameObject Intelligence;
    public GameObject Perception;
    public GameObject Dexterite;
    public GameObject Endurance;
    public GameObject Charisme;

    private void CreateTxtFile(string name)
    {
        path = Application.persistentDataPath + "/" + name + ".txt";
        Debug.Log(Application.persistentDataPath);
        File.WriteAllText(path, "Fiche personnage de : " + name + "\n\n");
        File.AppendAllText(path, "name " + name + "\n");
    }

    public void Personnage()
    {
        CreateTxtFile(Name.GetComponent<TMP_InputField>().text);
        
        // Race et Titre
        File.AppendAllText(path, 
            "race " + RaceDropdown.GetComponent<TMP_Dropdown>().options[RaceDropdown.GetComponent<TMP_Dropdown>().value].text + "\n"
            + "titre " + Titre.GetComponent<TMP_InputField>().text + "\n"
            + "description " + Description.GetComponent<TMP_InputField>().text + "\n\n");
        
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
