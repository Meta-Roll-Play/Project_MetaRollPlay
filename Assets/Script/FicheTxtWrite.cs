using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class FicheTxtWrite : MonoBehaviour
{
    private string path;
    
    [SerializeField] private GameObject RaceDropdown;

    private void CreateTxtFile(string name)
    {
        path = Application.dataPath + "/Fiches/" + name + ".txt";
        File.WriteAllText(path, "Fiche personnage de : " + name + "\n\n");
        File.AppendAllText(path, "name : " + name + "\n");
    }

    public void Personnage()
    {
        CreateTxtFile("Hugo");
        
        // Race et Titre
        File.AppendAllText(path, 
            "race : " + RaceDropdown.GetComponent<TMP_Dropdown>().options[RaceDropdown.GetComponent<TMP_Dropdown>().value].text + "\n"
            + "titre : " + "Chevalier" + "\n\n");
        
        // Stats
        File.AppendAllText(path,
            "HP : " + 100  + "\n"
            + "HP Max : " + 100 + "\n"
            + "Force : " + 0 + "\n"
            + "Intelligence : " + 0 + "\n"
            + "Perception : " + 0 + "\n"
            + "Dexterite : " + 0 + "\n"
            + "Endurance : " + 0 + "\n"
            + "Charisme : " + 0 + "\n\n");
    }
}
