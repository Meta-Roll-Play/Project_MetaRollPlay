using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/************************************************************************************
 *
 *  Hugo SIMON
 * 
 *  This script is for limiting the number of characters in a text field
 * 
 ************************************************************************************/

public class LimiteInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private int maxLenght;
    
    public void Start()
    {
        inputField.characterLimit = maxLenght;
    }
}
