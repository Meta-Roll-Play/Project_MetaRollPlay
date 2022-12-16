using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeWindow : MonoBehaviour
{
    public float maxheight = 100;
    public float minheight = 0;
    
    //fonction qui permet de redimensionner l'ui sur la hauteur au maximum
    public void ResizeToMaxHeightUI()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, maxheight);
    }
    
    //fonction qui permet de redimensionner l'ui sur la hauteur au minimum
    public void ResizeToMinHeightUI()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, minheight);
    }
}