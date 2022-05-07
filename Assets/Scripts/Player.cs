using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;
    
    private string WALK_ANIMATION = "isWalking";

    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    private string ENEMEY_TAG = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

    }

    void AnimatePlayer(){

        if(movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true); 
            sr.flipX = true;
        }
        else if(movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        
    }

    void PlayerJump(){

        if(Input.GetButtonDown("Jump") && isGrounded == true){
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }

    void OnCollisionEnter2D(Collision2D collision){
        
        if(collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag(ENEMEY_TAG)){
            Destroy(gameObject);
        }
        
    }


}//class
















































