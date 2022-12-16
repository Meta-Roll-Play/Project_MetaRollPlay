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

    public GameObject openMenu;
    
    public string path;
    
    private List<TMP_Dropdown.OptionData> listeFichier = new List<TMP_Dropdown.OptionData>();
    
    // Liste tout les fichiers dans le dossier "Assets/Fiches" finissant par ".txt"
    public void Start()
    {
        dropdown.ClearOptions();
        listeFichier.Clear();
        string[] fichiers = System.IO.Directory.GetFiles(Application.persistentDataPath, "*.txt");
        foreach (string fichier in fichiers)
        {
            listeFichier.Add(new TMP_Dropdown.OptionData(System.IO.Path.GetFileNameWithoutExtension(fichier)));
        }
        dropdown.AddOptions(listeFichier);
        if (listeFichier.Count == 0)
        {
            openMenu.SetActive(false);
        }
    }

    public void Import()
    {
        path = dropdown.options[dropdown.value].text + ".txt";
        string[] lines = System.IO.File.ReadAllLines(Application.persistentDataPath + "/" + path);

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
        
        leTexte.GetComponent<FicheTxtWrite>().Force.GetComponent<Slider>().value = int.Parse(LeSplit(lines[9]));
        leTexte.GetComponent<FicheTxtWrite>().Intelligence.GetComponent<Slider>().value = int.Parse(LeSplit(lines[10]));
        leTexte.GetComponent<FicheTxtWrite>().Perception.GetComponent<Slider>().value = int.Parse(LeSplit(lines[11]));
        leTexte.GetComponent<FicheTxtWrite>().Dexterite.GetComponent<Slider>().value = int.Parse(LeSplit(lines[12]));
        leTexte.GetComponent<FicheTxtWrite>().Endurance.GetComponent<Slider>().value = int.Parse(LeSplit(lines[13]));
        leTexte.GetComponent<FicheTxtWrite>().Charisme.GetComponent<Slider>().value = int.Parse(LeSplit(lines[14]));

        leTexte.GetComponent<FicheTxtWrite>().Comp.GetComponent<TMP_InputField>().text = LeSplit(lines[17]);
        leTexte.GetComponent<FicheTxtWrite>().Equipment.GetComponent<TMP_InputField>().text = LeSplit(lines[19]);
    }

    public void Suppr()
    {
        path = dropdown.options[dropdown.value].text + ".txt";
        System.IO.File.Delete(Application.persistentDataPath + "/" + path);
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
