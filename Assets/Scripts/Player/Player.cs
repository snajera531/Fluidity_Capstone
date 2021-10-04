using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum eColor
    {
        NONE,
        RED,
        GREEN,
        BLUE
    }

    public bool hasRed = false;
    public bool hasGreen = false;
    public bool hasBlue = false;

    public float x;
    public float speed = 8f;
    public float jumpForce = 10f;
    public bool facingRight = true;
    public bool paused = false;

    public eColor currentColor = eColor.RED;
    public Transform groundCheck;
    public Transform player;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
}
