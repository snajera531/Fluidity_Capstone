using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicVillagerAI : MonoBehaviour
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
}
