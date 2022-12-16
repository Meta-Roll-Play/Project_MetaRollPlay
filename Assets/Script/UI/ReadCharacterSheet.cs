using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ReadCharacterSheet : MonoBehaviour
{
    //variable pour la fiche de suivi
    public string characterName;
    public int characterHp;
    public int characterMaxHp;
    
    //fonctions qui récupèrent les données du personnage à partir d'une fiche

    //fonction qui stoque dans une List toutes les lignes du fichier.txt
    public List<string> GetLines(TextAsset characterSheet)
    {
        List<string> lines = new List<string>();
        string[] line = characterSheet.text.Split('\n');
        foreach (string l in line)
        {
            lines.Add(l);
        }
        return lines;
    }
    
    //fonction qui récupère le nom du personnage parmi la List
    
    public string GetCharacterName(List<string> lines)
    {
        string characterName = "";
        string tempoStorage = lines.Find(x => x.Contains("nom"));
        string[] tempoCharacterName = tempoStorage.Split(char.Parse(" "));
        characterName = tempoCharacterName[1];
        return characterName;
    }
    
    //fonction qui récupère le montant d'hp du personnage dans le fichier un utilisant des listes
    
    public int GetCharacterHp(List<string> lines)
    {
        int characterHp = 0;
        string tempoStorage = lines.Find(x => x.Contains("hp"));
        string[] tempoCharacterHp = tempoStorage.Split(char.Parse(" "));
        characterHp = int.Parse(tempoCharacterHp[1]);
        return characterHp;
    }
    
    //fonction qui récupère le montant de maxhp du personnage dans le fichier un utilisant des listes
    
    public int GetCharacterMaxHp(List<string> lines)
    {
        int characterMaxHp = 0;
        string tempoStorage = lines.Find(x => x.Contains("maxh"));
        string[] tempoCharacterMaxHp = tempoStorage.Split(char.Parse(" "));
        characterMaxHp = int.Parse(tempoCharacterMaxHp[1]);
        return characterMaxHp;
    }

    //fonction qui exécute les fonctions de récupération des données du personnage
    public void ReadSheet(string file, TextAsset characterSheet)
    {
        characterName = GetCharacterName(GetLines(characterSheet));
        characterHp = GetCharacterHp(GetLines(characterSheet));
        characterMaxHp = GetCharacterMaxHp(GetLines(characterSheet));
        /*
        Debug.Log("Nom du personnage : " + characterName);
        Debug.Log("HP : " + characterHp);
        Debug.Log("MaxHP : " + characterMaxHp);
        */
    }
}
