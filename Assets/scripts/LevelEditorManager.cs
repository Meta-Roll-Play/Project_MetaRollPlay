using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;

public class LevelEditorManager : MonoBehaviour
{

    public ItemController[] ItemButtons;
    public GameObject[] Itemprefabs;




    public int CurrentButtonPressed;

    public int idTab;


    /*private void Load() {
        int i, idElement;
        string path;
        string[][] ElemList;

        path = Application.persistentDataPath + "/map.json";
        string jsonText;

        if(File.Exists(path)) {
            jsonText = File.ReadAllText(path);
            Debug.Log(jsonText);

            ElemList = JsonUtility.FromJson<string[][]>(jsonText);
            Debug.Log(ElemList.Length);

            for(i=0; i<ElemList.Length; i++) {
                //switch(ElemList[i][])

                //GameObject newObject = Instantiate(Itemprefabs[idElement], new Vector3(1, 1, worldPosition.z), Quaternion.identity);
                //newObject.transform.rotation.y = 0;
            }
        }
    }*/


    private void Start()
    {

    }
    
        private void Update()
    {
        
        GameObject newObject;
              
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if(Input.GetMouseButtonDown(0) && ItemButtons[CurrentButtonPressed].Clicked &&  !EventSystem.current.IsPointerOverGameObject())
        {
            ItemButtons[CurrentButtonPressed].Clicked = false;
            newObject = Instantiate(Itemprefabs[CurrentButtonPressed], new Vector3(worldPosition.x, 1, worldPosition.z), Quaternion.identity);

        }


        /*if(Input.GetKey(KeyCode.O)) {
            Load();
        }*/
    }

}
