using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int movement_speed;
    [SerializeField] private int jump_height;
    private float moveHorizontal;
    private Rigidbody2D rb;

    [SerializeField] private bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
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

        if (Input.GetButton("Vertical")){
            rb.velocity = new Vector3(rb.velocity.x, jump_height, 0.0f);
        }
    }
    private void MoveHorizontal()
    {
        if (Input.GetButton("Horizontal"))
        {
            moveHorizontal = Input.GetAxis("Horizontal") * movement_speed;
            rb.velocity = new Vector3(moveHorizontal, rb.velocity.y, 0.0f);
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            rb.velocity = new Vector3(0.0f, rb.velocity.y, 0.0f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall"){
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall"){
            grounded = false;
        }
    }
}
