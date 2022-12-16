using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*****************************************************
 * 
 * Hugo Simon
 * 
 *****************************************************/

public class ActualisationCommpetenceRace : MonoBehaviour
{
    [SerializeField] private GameObject _BaseStats;
    
    public void Actualisation()
    {
        GetComponent<TMP_InputField>().text = _BaseStats.GetComponent<FicheUI>()
            .RaceStructs[_BaseStats.GetComponent<FicheUI>().DropDownRace.GetComponent<TMP_Dropdown>().value]
            .CompetenceRace;
    }
}
