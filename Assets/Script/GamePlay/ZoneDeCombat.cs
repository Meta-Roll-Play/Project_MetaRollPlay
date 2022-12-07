//owen bernard
//creation et suppression du zone de combat
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDeCombat : MonoBehaviour
{

    //zone de combat
    [Header("Zone de combat")]
    public GameObject zoneCombat;
    public GameObject zoneCombatInstantiate;
    public float dimensionZone;
    public Vector3 posiZone;
    public bool sendZone;

    // Update is called once per frame
    void Update()
    {

        //si le Mj veut créer une zone de combat
        if (sendZone)
        {
            sendZone = false;
            Destroy(zoneCombatInstantiate.gameObject);
            zoneCombatInstantiate = Instantiate(zoneCombat, new Vector3(posiZone.x, 0.5f, posiZone.z), Quaternion.Euler(-90, 0, 0), this.transform);
            zoneCombatInstantiate.transform.localScale += new Vector3(dimensionZone * 10, dimensionZone * 10, 0);

        }

    }
}
