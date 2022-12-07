//Owen bernard
//variable de base du joueur
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableDuJoueur : MonoBehaviour
{

    [Header("Mouvement")]
    public float speed = 5f;
    public Vector3 velocity;
    public float gravity = -9.10f;
    public CharacterController controllePlayer;

    [Header("Attribut")]
    public int life;

    [Header("Possession")]
    public bool acces;
    public bool modeCombat;

}
