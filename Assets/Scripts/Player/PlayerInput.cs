using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Player player;
    public LayerMask groundLayer;
    int stepTime = 2;

    private void Update()
    {
        player.rb.velocity = new Vector2(player.x * player.speed, player.rb.velocity.y);

        if (!player.facingRight && player.x > 0f)
        {
            FlipPlayer();
        } else if (player.facingRight && player.x < 0f)
        {
            FlipPlayer();
        }

        if (Grounded())
        {
            AudioManager.Instance.Play("Player_Step" + Random.Range(2, 6));
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!player.paused)
        {
            if (context.performed && Grounded())
            {
                player.rb.velocity = new Vector2(player.rb.velocity.x, player.jumpForce);
            }

            if (context.canceled && player.rb.velocity.y > 0f)
            {
                player.rb.velocity = new Vector2(player.rb.velocity.x, player.rb.velocity.y * 0.5f);
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!player.paused)
        {
            player.x = context.ReadValue<Vector2>().x;
        }
    }

    public void Select(InputAction.CallbackContext context)
    {
        if (!player.selected)
        {
            //when p is close enough to an npc,
            //selected = true & dialogue pops up, p can choose options w/ arrows? mvmt gets locked
            Debug.Log("Select xP");
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed && !GameManager.Instance.pauseMenuPanel.activeInHierarchy)
        {
            GameManager.Instance.PauseMenu();
        }
        else if(context.performed && GameManager.Instance.pauseMenuPanel.activeInHierarchy)
        {
            GameManager.Instance.ExitPause();
        }
    }

    public void LeftColor(InputAction.CallbackContext context)
    {
        if (!player.paused)
        {
            if (player.currentColor == Player.eColor.RED && context.performed && player.hasBlue)
            {
                player.currentColor = Player.eColor.BLUE;
            }
            else if (player.currentColor == Player.eColor.GREEN && context.performed && player.hasRed)
            {
                player.currentColor = Player.eColor.RED;
            }
            else if (player.currentColor == Player.eColor.BLUE && context.performed && player.hasGreen)
            {
                player.currentColor = Player.eColor.GREEN;
            }

            GameManager.Instance.CheckColorStatus();
        }
    }

    public void RightColor(InputAction.CallbackContext context)
    {
        if (!player.paused)
        {
            if (player.currentColor == Player.eColor.RED && context.performed && player.hasGreen)
            {
                player.currentColor = Player.eColor.GREEN;
            }
            else if (player.currentColor == Player.eColor.GREEN && context.performed && player.hasBlue)
            {
                player.currentColor = Player.eColor.BLUE;
            }
            else if (player.currentColor == Player.eColor.BLUE && context.performed && player.hasRed)
            {
                player.currentColor = Player.eColor.RED;
            }

            GameManager.Instance.CheckColorStatus();
        }
    }

    private bool Grounded()
    {
        return Physics2D.OverlapCircle(player.groundCheck.position, 1f, groundLayer);
    }

    private void FlipPlayer()
    {
        player.facingRight = !player.facingRight;
        player.sprite.flipX = !player.sprite.flipX;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Color Object")
        {
            switch (collision.gameObject.name)
            {
                case "RedSymbol":
                    player.hasRed = true;
                    break;
                case "GreenSymbol":
                    player.hasGreen = true;
                    break;
                case "BlueSymbol":
                    player.hasBlue = true;
                    break;
                default:
                    break;
            }

            Destroy(collision.gameObject);
        }

        if(collision.gameObject.layer == 3)
        {

            AudioManager.Instance.Play("Player_Step1");
        }
    }
}
