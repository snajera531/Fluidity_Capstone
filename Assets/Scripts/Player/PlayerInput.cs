using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Player player;
    public LayerMask groundLayer;

    private void Update()
    {
        player.rb.velocity = new Vector2(player.x * player.speed, player.rb.velocity.y);

        if (player!.facingRight && player.x > 0f)
        {
            FlipPlayer();
        } else if (player.facingRight && player.x < 0f)
        {
            FlipPlayer();
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
            if (player.currentColor == Player.eColor.RED && context.performed)
            {
                player.currentColor = Player.eColor.BLUE;
            }
            else if (player.currentColor == Player.eColor.GREEN && context.performed)
            {
                player.currentColor = Player.eColor.RED;
            }
            else if (player.currentColor == Player.eColor.BLUE && context.performed)
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
            if (player.currentColor == Player.eColor.RED && context.performed)
            {
                player.currentColor = Player.eColor.GREEN;
            }
            else if (player.currentColor == Player.eColor.GREEN && context.performed)
            {
                player.currentColor = Player.eColor.BLUE;
            }
            else if (player.currentColor == Player.eColor.BLUE && context.performed)
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
        player.sprite.flipX = true;
    }
}
