using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorShift : MonoBehaviour
{
    public Gradient gradient;
    public Text title;

    private float timer = 0;
    private bool increasingTime = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (title.color == Color.magenta)
        {
            increasingTime = false;
        }
        else if(title.color == Color.red)
        {
            increasingTime = true;
        }   

        if (increasingTime)
        {
            timer += (float)(Time.deltaTime / 8);
        }
        else
        {
            timer -= (float)(Time.deltaTime / 8);
        }

        title.color = gradient.Evaluate(timer);
    }
}
