using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Player player;
    public LayerMask groundLayer;
    public List<BasicVillagerAI> nPCs;
    public List<BasicVillagerAI> nPCsClose;
    int stepTime = 400;
    int steps = 2;

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

        if (Grounded() && stepTime <= 0 && player.rb.velocity != new Vector2(0, 0))
        {
            AudioManager.Instance.Play("Player_Step" + steps);
            stepTime = 400;
            if (steps >= 5) {steps = 2;} 
            else { steps++; }
        }

        steps--;
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
            player.selected = true;
            if(nPCsClose.Count > 0)
            {
                if(player.hasRed)
                {
                    if (nPCsClose.Contains(nPCs[1]))
                    {
                        GameManager.Instance.StartDialogue2();
                    }
                }
                else
                {
                    if (nPCsClose.Contains(nPCs[0]))
                    {
                        GameManager.Instance.StartDialogue1();
                    }
                }
            }
        }
        else
        {
            player.selected = false;
        }
    }

    public void Continue (InputAction.CallbackContext context)
    {
        //game manager checks activity bc player shouldnt have to :)
        GameManager.Instance.ContinueText();
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed && !GameManager.Instance.pauseMenuPanel.activeInHierarchy)
        {
            GameManager.Instance.PauseMenu();
        }
        else if(context.performed && GameManager.Instance.pauseMenuPanel.activeInHierarchy && !UIManager_InGame.Instance.settingsGamePanel.activeInHierarchy)
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
                    player.currentColor = Player.eColor.RED;
                    break;
                case "GreenSymbol":
                    player.hasGreen = true;
                    player.currentColor = Player.eColor.GREEN;
                    break;
                case "BlueSymbol":
                    player.hasBlue = true;
                    player.currentColor = Player.eColor.BLUE;
                    break;
                default:
                    break;
            }

            AudioManager.Instance.Play("Player_NewColor");
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag == "Ground")
        {
            AudioManager.Instance.Play("Player_Step1");
        } else if (collision.gameObject.tag == "Platform")
        {
            AudioManager.Instance.Play("Player_StepWood");
        } else if (collision.gameObject.tag == "NPC")
        {     
            if(collision.gameObject.name == "Bear")
            {
                if (!player.hasRed)
                {
                    nPCs[0].buttonPrompt.SetActive(true);
                    nPCsClose.Add(nPCs[0]);
                }
            } else if(collision.gameObject.name == "Twink")
            {
                if (!player.hasGreen)
                {
                    nPCs[1].buttonPrompt.SetActive(true);
                    nPCsClose.Add(nPCs[1]);
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            if(nPCsClose.Count > 0)
            {
                if (collision.gameObject.name == "Bear")
                {
                    nPCs[0].buttonPrompt.SetActive(false);
                    nPCsClose.Remove(nPCs[0]);
                }
                else if (collision.gameObject.name == "Twink")
                {
                    nPCs[1].buttonPrompt.SetActive(false);
                    nPCsClose.Remove(nPCs[1]);
                }
            }
        }
    }
}
