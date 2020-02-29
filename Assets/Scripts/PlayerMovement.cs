using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int movement_speed;
    [SerializeField] private float jump_height;
    private float moveHorizontal;
    public float direction;
    private Rigidbody2D rb;

    public bool grounded;
    public bool jump_charging;
    public bool moving;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
        jump_charging = false;
        direction = 0;
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
            moving = false;
            
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            jump_height += 0.1f;
        }

        // Release jump
        if(Input.GetButtonUp("Jump")){
            direction =  Mathf.Sign(direction)*Mathf.Ceil(Mathf.Abs(direction));
            rb.velocity = new Vector3(direction*3f, jump_height, 0.0f);
            jump_charging = false;
        }
    }
    private void MoveHorizontal()
    {
        direction = Input.GetAxis("Horizontal");

        if(!grounded || jump_charging){
            return;
        }

        if (Input.GetButton("Horizontal")){
            moving = true;
            moveHorizontal = direction * movement_speed;
            rb.velocity = new Vector3(moveHorizontal, rb.velocity.y, 0.0f);
        }

        if (Input.GetButtonUp("Horizontal")){
            moving = false;
            rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall"){
            grounded = true;
            jump_height = 0;
            jump_charging = false;
            rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall"){
            grounded = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall"){
            grounded = true;
        }
    }
}
