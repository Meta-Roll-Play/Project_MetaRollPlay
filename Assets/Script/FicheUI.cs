using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FicheUI : MonoBehaviour
{
    [SerializeField] private static List<TMP_Dropdown.OptionData> Race = new List<TMP_Dropdown.OptionData>();

    [SerializeField] private GameObject DropDownRace;

    private void Awake()
    {
        AddToList("Humain", "Krobh", "Minéleste", "Félidé", "Nain", "Elfe", "Kylne");
        DropDownRace.GetComponent<TMP_Dropdown>().options = Race;
    }

    void AddToList(params string[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Race.Add(new TMP_Dropdown.OptionData(list[i]));
        }
    }
}
