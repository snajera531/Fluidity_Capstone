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

    public float x;
    public float speed = 5f;
    public bool facingRight = true;
    public bool paused = false;
    public Rigidbody2D rb;
}
