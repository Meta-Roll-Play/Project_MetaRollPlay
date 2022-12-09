using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ChangementPrefabNetwork : NetworkBehaviour
{

    //public string OwnerClientId;
    public string converter;

    // Start is called before the first frame update
    void Start()
    {
        converter = OwnerClientId.ToString();
        Debug.Log(converter);

        //si c'est l'owner alors il doit voir son MJcontroller, les autres sont détruit, les canvas des player sont détruit
        //si ce n'est pas l'owner alors il doit voir le MJcontroller de l'owner, detruire les canvas des player 
        /*
        if (IsOwner)
        {

            Destroy(transform.GetChild(1).gameObject);
            if (converter != "0")
            {
                //destruction des canvas puis camera
                Destroy(transform.GetChild(0).GetChild(1).gameObject);
                Destroy(transform.GetChild(0).GetChild(0).GetChild(0).gameObject);
                //destruction du script de 
            }
        }
        else
        {

            //destruction du MJ
            Destroy(transform.GetChild(0).gameObject);
            if (converter != "0")
            {
                //destruction du canva du joueur
                Destroy(transform.GetChild(1).GetChild(10).gameObject);
                //destruction de la caméra du joueur
                Destroy(transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).gameObject);
            }
        }*/
    }
}
