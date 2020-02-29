using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;
    private Animator animator;
    [SerializeField] private Sprite jump_charging_sprite;
    [SerializeField] private Sprite idle_sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {   
        if(playerMovement.direction > 0) {
            spriteRenderer.flipX = false;
        }else if(playerMovement.direction < 0){
            spriteRenderer.flipX = true;
        }

        if(playerMovement.jump_charging){
            animator.enabled = false;
            SetSprite(jump_charging_sprite);
        } else{
            animator.enabled = true;
            SetSprite(idle_sprite);
        }
        
        if(playerMovement.moving){
            animator.SetBool("Moving", true);
            return;
        }

        animator.SetBool("Moving", false);
    }

    public void SetSprite(Sprite sprite){
        spriteRenderer.sprite = sprite;
    }
}
