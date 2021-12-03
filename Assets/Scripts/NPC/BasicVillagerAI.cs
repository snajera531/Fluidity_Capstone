using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicVillagerAI : MonoBehaviour
{
    public enum eColor
    {
        RED,
        GREEN,
        BLUE
    }

    public float X { get; set; }
    public float Speed { get; set; }
    public bool FacingRight { get; set; }
    public bool Paused { get; set; }
    public Rigidbody2D Rb { get; set; }

    //wandering functionality
    //npc wanders between the two nodes
    public GameObject Node1 { get; set; }
    public GameObject Node2 { get; set; }
    public int walkTimer = 10;
    public GameObject buttonPrompt;

    private void Start()
    {
        buttonPrompt.SetActive(false);
    }
}
