using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;

public class navigateCamera : MonoBehaviour
{

    void Save() {
        int i;
        string path;
        GameObject[] ElemList;

        ElemList = GameObject.FindGameObjectsWithTag("levelElements");
        path = Application.persistentDataPath + "/map.json";

        File.WriteAllText(path, "[");

        for(i=0; i<ElemList.Length; i++) {
            File.AppendAllText(path, "[\"" + ElemList[i].name + "\"," + ElemList[i].transform.position.x + "," + ElemList[i].transform.position.y + "," + ElemList[i].transform.localEulerAngles.y + "," + ElemList[i].transform.localScale.x + "]");
            if(i != ElemList.Length - 1) {
                File.AppendAllText(path, ",");
            }
        }

        File.AppendAllText(path, "]");

    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKey(KeyCode.Z)) {
            this.transform.Translate(20f * Time.deltaTime * (-Vector3.up));
        }
        if(Input.GetKey(KeyCode.S)) {
            this.transform.Translate(20f * Time.deltaTime * (-Vector3.down));
        }
        if(Input.GetKey(KeyCode.Q)) {
            this.transform.Translate(20f * Time.deltaTime * (-Vector3.left));
        }
        if(Input.GetKey(KeyCode.D)) {
            this.transform.Translate(20f * Time.deltaTime * (-Vector3.right));
        }
        if(Input.GetKey(KeyCode.Return)) {
            Save();
        }
    }
}
