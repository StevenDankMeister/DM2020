using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int movement_speed;
    [SerializeField] private float jump_height;
    private float moveHorizontal;
    private float jump_direction;
    private Rigidbody2D rb;

    [SerializeField] private bool grounded;
    public bool jump_charging;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
        jump_charging = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        Jump();
    }

    private void Jump(){
        if(!grounded) {
            return;
        }
        // Charge jump
        if(Input.GetButton("Jump") && jump_height < 5){
            jump_charging = true;
            
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            jump_height += 0.1f;
        }

        // Release jump
        if(Input.GetButtonUp("Jump")){
            jump_direction = Input.GetAxis("Horizontal");
            rb.velocity = new Vector3(jump_direction, jump_height, 0.0f);
            jump_charging = false;
        }
    }
    private void MoveHorizontal()
    {
        if(!grounded || jump_charging){
            return;
        }

        if (Input.GetButton("Horizontal")){
            moveHorizontal = Input.GetAxis("Horizontal") * movement_speed;
            rb.velocity = new Vector3(moveHorizontal, rb.velocity.y, 0.0f);
        }

        if (Input.GetButtonUp("Horizontal")){
            rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall"){
            grounded = true;
            jump_height = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall"){
            grounded = false;
        }
    }
}
