using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;
    [SerializeField] private Sprite jump_charging_sprite;
    [SerializeField] private Sprite idle_sprite;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(playerMovement.jump_charging){
            SetSprite(jump_charging_sprite);
        }

        if(!playerMovement.jump_charging){
            SetSprite(idle_sprite);
        }

        
    }

    public void SetSprite(Sprite sprite){
        spriteRenderer.sprite = sprite;
    }
}
