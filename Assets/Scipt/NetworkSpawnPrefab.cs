using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkSpawnPrefab : NetworkBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Id : " + OwnerClientId);
        if(OwnerClientId == 0)
        {
            GameObject go = Instantiate(prefab1, Vector3.zero, Quaternion.identity);
            go.GetComponent<NetworkObject>().Spawn();
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
