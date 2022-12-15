//owen bernard
//quand un objet est visé par le MJ, il est donc Outliner, il peut maintenant le posseder
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PossessionMJ : MonoBehaviour
{
    public GameObject ObjectPosseder;
    public GameObject LookAt;
    public bool possession;

    // Update is called once per frame
    void Update()
    {
        LookAt = transform.GetChild(0).GetComponent<LookAt>().colliderActif;
        if (LookAt != null)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (possession)
                {
                    ObjectPosseder = null;
                    ObjectPosseder.GetComponent<DeplacementEnnemis>().possession = false;
                    possession = false;
                }
                else
                {
                    ObjectPosseder = LookAt;
                    ObjectPosseder.GetComponent<DeplacementEnnemis>().possession = true;
                    possession = true;
                }
            }
        }

        if (possession)
        {
            transform.position = new Vector3(ObjectPosseder.transform.position.x, ObjectPosseder.transform.position.y+2, ObjectPosseder.transform.position.z);
        }
    }
}
