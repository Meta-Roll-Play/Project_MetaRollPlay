using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateObject : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject objectDestination;
    public Text clonetext;


    //Fonction qui permet de spawner un prefab dans un gameobject
    public void SpawnObject(GameObject prefab, GameObject parent)
    {
        GameObject newObject = Instantiate(prefab, parent.transform);

        if (objectToSpawn.name == "NewSuivi")
        {
            Debug.Log("suivi on");
            // Get a reference to the Text component of the clone
            //clonetext = newObject.GetComponentInChildren<Text>();
            //
        }

        /*
         //déplacer le prefab en avant dernière position
         newObject.transform.SetSiblingIndex(parent.transform.childCount - 2);
         */
    }
    
    public void SpawnSheet()
    {
        SpawnObject(objectToSpawn, objectDestination);
    }
    
    public void DestroySheet()
    {
        Destroy(objectDestination.transform.GetChild(0).gameObject);
    }
    
    public void SpawnSuivi()
    {
        SpawnObject(objectToSpawn, objectDestination);
    }

    public void SpawnJournalFile()
    {
        SpawnObject(objectToSpawn, objectDestination);
    }
}