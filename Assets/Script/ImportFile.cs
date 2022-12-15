using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImportFile : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private Button button;
    [SerializeField] private GameObject leTexte;
    
    public string path;
    
    private List<TMP_Dropdown.OptionData> listeFichier = new List<TMP_Dropdown.OptionData>();
    
    // Liste tout les fichiers dans le dossier "Assets/Fiches" finissant par ".txt"
    private void Start()
    {
        dropdown.ClearOptions();
        string[] fichiers = System.IO.Directory.GetFiles(Application.dataPath + "/Fiches", "*.txt");
        foreach (string fichier in fichiers)
        {
            listeFichier.Add(new TMP_Dropdown.OptionData(System.IO.Path.GetFileNameWithoutExtension(fichier)));
        }
        dropdown.AddOptions(listeFichier);
    }

    public void Import()
    {
        path = "/Fiches/" + dropdown.options[dropdown.value].text + ".txt";
        string[] lines = System.IO.File.ReadAllLines(Application.dataPath + path);

        leTexte.GetComponent<FicheTxtWrite>().Name.GetComponent<TMP_InputField>().text = LeSplit(lines[2]);
        leTexte.GetComponent<FicheTxtWrite>().Titre.GetComponent<TMP_InputField>().text = LeSplit(lines[4]);
        leTexte.GetComponent<FicheTxtWrite>().Description.GetComponent<TMP_InputField>().text = LeSplit(lines[5]);
        
        for (int i = 0; i < 7; i++)
        {
            if (leTexte.GetComponent<FicheTxtWrite>().RaceDropdown.GetComponent<TMP_Dropdown>().options[i].text == LeSplit(lines[3]))
            {
                leTexte.GetComponent<FicheTxtWrite>().RaceDropdown.GetComponent<TMP_Dropdown>().value = i;
            }
        }
    }

    private string LeSplit(string laListe)
    {
        string leTexte = "";
        string[] leSplit = laListe.Split(' ');
        for (int i = 1; i < leSplit.Length; i++)
        {
            leTexte += leSplit[i];
            if (i != leSplit.Length - 1)
            {
                leTexte += " ";
            }
        }
        return leTexte;
    }
}
