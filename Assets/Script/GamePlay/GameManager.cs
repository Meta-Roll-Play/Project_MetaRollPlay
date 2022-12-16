using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fait par Callaghan

public class GameManager : MonoBehaviour
{
    /*// Variable de point de vie
    public int health = 80;
    // Variable de point de vie max
    public int maxHealth = 100;
    // Variable de montant de dégâts
    public int damageValue = 10;*/

    // Update is called once per frame
    void Update()
    {
        /*// Affichage des points de vie et de mana
        Debug.Log("Health : " + health + "/" + maxHealth);

        // Si on appuie sur la touche i
        if (Input.GetKeyDown(KeyCode.I))
        {
            // On lance la fonction d'initialisation
            InitializeToMax(ref health, maxHealth);
        }

        // Si on appuie sur la touche G
        if (Input.GetKeyDown(KeyCode.G))
        {
            // On lance la fonction de changement de vie
            ChangeValue(damageValue,  ref health);
            // On fixe les erreurs de valeur
            FixValue(ref health, ref maxHealth);
        }*/
    }
    
    // Fonction d'initialisation d'une variable à son maximum
    public void InitializeToMax(ref int value, int maxValue)
    {
        // On initialise la variable à sa valeur maximum
        value = maxValue;
    }
    
    // Fonction qui permet de changer la valeur max d'une variable
    public void ChangeMaxValue(int amount, ref int maxValue)
    {
        // On change la valeur max
        maxValue += amount;
    }
    
    // Fonction qui permet de régler les conflits de valeur et valeur max
    public void FixValue(ref int value, ref int maxValue)
    {
        // Si la valeur est supérieure à la valeur max
        if (value > maxValue)
        {
            // On met la valeur à la valeur max
            value = maxValue;
        }
        
        // Si la valeur est inférieure à 0
        if (value < 0)
        {
            // On met la valeur à 0
            value = 0;
        }
        
        // Si la valeur max est inférieure à 0
        if (maxValue < 0)
        {
            // On met la valeur max à 0
            maxValue = 0;
        }
    }
    
    // Fonction qui permet de changer la valeur d'une variable
    public void ChangeValue(int amount, ref int value)
    {
        // On change la valeur
        value += amount;
    }
}
