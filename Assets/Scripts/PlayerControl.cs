using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float speed;
    public float jump;
    private float moveVelocity;
    private bool grounded = true;
    private SpriteRenderer mySpriteRenderer;
    public Animator anim;
    public Collider2D attacktriggerleft;
    public Collider2D attacktriggerright;
    private bool attacking = false;


    void Start() {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Awake()
    {
        attacktriggerleft.enabled = false;
        attacktriggerright.enabled = false;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.F) && attacking == false)
        {
            attacking = true;
            if (mySpriteRenderer.flipX == false)
            {
                attacktriggerright.enabled = true;
            }
            else if (mySpriteRenderer.flipX == true)
            {
                attacktriggerleft.enabled = true;
            }
            anim.SetBool("attack", true);
        }

        if (Input.GetKeyUp(KeyCode.F) && attacking == true)
        {
            attacking = false;
            attacktriggerleft.enabled = false;
            attacktriggerright.enabled = false;
            anim.SetBool("attack", false);
        }

        float move = Input.GetAxis("Horizontal");
        if (move == 0) {
            anim.SetBool("IsMoving", false);
        }

        moveVelocity = 0;   
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            if (grounded) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            anim.SetBool("IsMoving", true);
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            anim.SetBool("IsMoving", true);
            moveVelocity = speed;
        }

        if (moveVelocity > 0 && mySpriteRenderer.flipX == true)
        {
            mySpriteRenderer.flipX = false;
        }
        else if(moveVelocity < 0 && mySpriteRenderer.flipX == false){
            mySpriteRenderer.flipX = true;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
	}

    void OnTriggerEnter2D() {
        grounded = true;
        anim.SetBool("IsGrounded", true);
    }

    void OnTriggerExit2D() {
        grounded = false;
        anim.SetBool("IsGrounded", false);
    }
}
