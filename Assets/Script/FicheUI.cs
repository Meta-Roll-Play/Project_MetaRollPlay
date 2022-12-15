using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*************************************************************************************
 * 
 *  Permet de modifier le dropdown des races et de stocker les données de chaque race
 *
 * Hugo Simon
 * 
 ************************************************************************************/

public class FicheUI : MonoBehaviour
{
    [SerializeField] private static List<TMP_Dropdown.OptionData> Race = new List<TMP_Dropdown.OptionData>();

    public GameObject DropDownRace;

    [SerializeField] private TMP_InputField Point;
    public int PointAttribut = 8;
    
    public struct RaceStruct
    {
        public int HpMax;
        public int Force;
        public int Intelligence;
        public int Perception;
        public int Dexterite;
        public int Endurance;
        public int Charisme;
        public int PointsAttributs;
    }
    public RaceStruct[] RaceStructs = new RaceStruct[7];

    private void Awake()
    {
        AddToList("Humain", "Krobh", "Minéleste", "Félidé", "Nain", "Elfe", "Kylne");
        DropDownRace.GetComponent<TMP_Dropdown>().options = Race;
        
        Point.interactable = false;
        
        DefRace();
    }

    private void Update()
    {
        Point.text = PointAttribut.ToString();
    }

    public void OnChangeValue()
    {
        PointAttribut = RaceStructs[DropDownRace.GetComponent<TMP_Dropdown>().value].PointsAttributs;
    }
    
    void AddToList(params string[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Race.Add(new TMP_Dropdown.OptionData(list[i]));
        }
    }

    private void DefRace()
    {
        //Humain 
        RaceStructs[0].HpMax = 100;
        RaceStructs[0].Force = 0;
        RaceStructs[0].Intelligence = 0;
        RaceStructs[0].Perception = 0;
        RaceStructs[0].Dexterite = 0;
        RaceStructs[0].Endurance = 0;
        RaceStructs[0].Charisme = 0;
        RaceStructs[0].PointsAttributs = 8;
        
        //Krobh
        RaceStructs[1].HpMax = 60;
        RaceStructs[1].Force = 3;
        RaceStructs[1].Intelligence = -2;
        RaceStructs[1].Perception = 0;
        RaceStructs[1].Dexterite = -3;
        RaceStructs[1].Endurance = 2;
        RaceStructs[1].Charisme = 0;
        RaceStructs[1].PointsAttributs = 6;
        
        //Minéleste
        RaceStructs[2].HpMax = 80;
        RaceStructs[2].Force = 1;
        RaceStructs[2].Intelligence = 0;
        RaceStructs[2].Perception = -2;
        RaceStructs[2].Dexterite = -1;
        RaceStructs[2].Endurance = +3;
        RaceStructs[2].Charisme = -1;
        RaceStructs[2].PointsAttributs = 6;
        
        //Félidé
        RaceStructs[3].HpMax = 45;
        RaceStructs[3].Force = -2;
        RaceStructs[3].Intelligence = -2;
        RaceStructs[3].Perception = +3;
        RaceStructs[3].Dexterite = +1;
        RaceStructs[3].Endurance = 0;
        RaceStructs[3].Charisme = 0;
        RaceStructs[3].PointsAttributs = 6;
        
        //Nain
        RaceStructs[4].HpMax = 55;
        RaceStructs[4].Force = 0;
        RaceStructs[4].Intelligence = 2;
        RaceStructs[4].Perception = -1;
        RaceStructs[4].Dexterite = 0;
        RaceStructs[4].Endurance = 1;
        RaceStructs[4].Charisme = -2;
        RaceStructs[4].PointsAttributs = 6;
        
        //Elfe
        RaceStructs[5].HpMax = 45;
        RaceStructs[5].Force = -2;
        RaceStructs[5].Intelligence = 1;
        RaceStructs[5].Perception = 1;
        RaceStructs[5].Dexterite = 0;
        RaceStructs[5].Endurance = -2;
        RaceStructs[5].Charisme = 2;
        RaceStructs[5].PointsAttributs = 6;
        
        //Kylne
        RaceStructs[6].HpMax = 55;
        RaceStructs[6].Force = -2;
        RaceStructs[6].Intelligence = 0;
        RaceStructs[6].Perception = 0;
        RaceStructs[6].Dexterite = 2;
        RaceStructs[6].Endurance = -1;
        RaceStructs[6].Charisme = 1;
        RaceStructs[6].PointsAttributs = 6;
    }
}
