using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
//using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

/*************************************************************************************
 * 
 *  Limite les sliders pour ne pas aller au dessus de -3 et +4 par rapport aux states de base
 *  Et limite en fonction du nombre de point restant dans les points attribuables
 *
 *  Hugo Simon
 * 
 ************************************************************************************/

public class LimiteSlider : MonoBehaviour
{
    [SerializeField] private GameObject ValueBase;
    [SerializeField] private TMP_InputField Stats;
    [SerializeField] private string ValueName;
    private int BaseValue;
    
    private int previousValue;

    public void Actualisation()
    {
        switch (ValueName)
        {
            case "Force":
                BaseValue = ValueBase.GetComponent<FicheUI>().RaceStructs[ValueBase.GetComponent<FicheUI>().DropDownRace.GetComponent<TMP_Dropdown>().value].Force;
                break;
            case "Intelligence":
                BaseValue = ValueBase.GetComponent<FicheUI>().RaceStructs[ValueBase.GetComponent<FicheUI>().DropDownRace.GetComponent<TMP_Dropdown>().value].Intelligence;
                break;
            case "Perception":
                BaseValue = ValueBase.GetComponent<FicheUI>().RaceStructs[ValueBase.GetComponent<FicheUI>().DropDownRace.GetComponent<TMP_Dropdown>().value].Perception;
                break;
            case "Dexterite":
                BaseValue = ValueBase.GetComponent<FicheUI>().RaceStructs[ValueBase.GetComponent<FicheUI>().DropDownRace.GetComponent<TMP_Dropdown>().value].Dexterite;
                break;
            case "Endurance":
                BaseValue = ValueBase.GetComponent<FicheUI>().RaceStructs[ValueBase.GetComponent<FicheUI>().DropDownRace.GetComponent<TMP_Dropdown>().value].Endurance;
                break;
            case "Charisme":
                BaseValue = ValueBase.GetComponent<FicheUI>().RaceStructs[ValueBase.GetComponent<FicheUI>().DropDownRace.GetComponent<TMP_Dropdown>().value].Charisme;
                break;
            default:
                BaseValue = 0;
                break;
        }
        previousValue = BaseValue;
        GetComponent<Slider>().value = BaseValue;
    }

    public void OnSliderValueChanged()
    {
        //Verifie qu'on ne dépasse pas la valeur de base de -3 et +4
        if (GetComponent<Slider>().value > BaseValue + 4)
        {
            GetComponent<Slider>().value = previousValue;
        }
        else if (GetComponent<Slider>().value < BaseValue - 3)
        {
            GetComponent<Slider>().value = previousValue;
        }
        
        //Ajoute ou enleve les points attribuables en fonction de la valeur du slider
        if (GetComponent<Slider>().value > previousValue)
        {
            if (ValueBase.GetComponent<FicheUI>().PointAttribut > 0)
            {
                for (int i = 0; i < GetComponent<Slider>().value - previousValue; i++)
                {
                    ValueBase.GetComponent<FicheUI>().PointAttribut--;
                }
                previousValue = (int)GetComponent<Slider>().value;
            }
            else
            {
                GetComponent<Slider>().value = previousValue;
            }
        }
        else if (GetComponent<Slider>().value < previousValue)
        {
            for (int i = 0; i < previousValue - GetComponent<Slider>().value; i++)
            {
                ValueBase.GetComponent<FicheUI>().PointAttribut++;
            }
            previousValue = (int)GetComponent<Slider>().value;
        }
        
        //Affiche la valeur du slider dans le TMP_InputField
        Stats.text = GetComponent<Slider>().value.ToString(CultureInfo.InvariantCulture);
    }
}