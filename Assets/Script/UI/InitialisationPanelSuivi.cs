using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TextAsset = UnityEngine.TextAsset;

public class InitialisationPanelSuivi : MonoBehaviour
{
    //déclaration d'un game object prefab
    public GameObject prefab;
    //déclaration d'un script
    public GenerateObject scriptGenerate;
    public ReadCharacterSheet scriptRead;
    
    // Start is called before the first frame update
    void Start()
    {
        InitialisationPanel();
    }

    //fonction qui gère les fichiers du dossier /CharacterSheets
    public void InitialisationPanel()
    {
        //récupération des fichiers d'un dossier dans un tableau
        string[] files = System.IO.Directory.GetFiles("Assets/CharacterSheets");
        
        //ciblage des fichiers .txt
        foreach (string filestr in files)
        {
            if (filestr.EndsWith(".txt"))
            {
                //Debug.Log("1"+filestr+"2");
                
                //affecte le fichier à un TextAsset
                /*TextAsset filetxt = new TextAsset();
                AssetDatabase.CreateAsset(filetxt, filestr);//Resources.Load<string>(filestr));
                Debug.Log(filetxt);*/
                
                StreamReader reader = new StreamReader(filestr);
                string content = reader.ReadToEnd();
                TextAsset filetxt = new TextAsset(content);
                Debug.Log(filetxt);

                // Close the reader and return the file contents
                reader.Close();
                
                
                //création d'une instance du prefab
                scriptGenerate.SpawnSuivi();
                //lecture du fichier .txt
                scriptRead.ReadSheet(filestr, filetxt);
                
                
                Debug.Log(scriptRead.characterName);
                //scriptGenerate.clonetext.text = scriptRead.characterName;
                //scriptGenerate.objectToSpawn.name = scriptRead.characterName;
                
                

                //edit of the text input named "NameCharacter" of the prefab

            }
        }
    }
}