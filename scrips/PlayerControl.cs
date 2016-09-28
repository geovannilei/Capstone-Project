using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public float speed;
    public float jump;
    private float moveVelocity;
    private bool grounded = true;
    private SpriteRenderer mySpriteRenderer;

    void Start() {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Update () {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) {
            print(grounded);
            if (grounded) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }
        moveVelocity = 0;

        if (Input.GetKey(KeyCode.A)) {
            moveVelocity = -speed;
            mySpriteRenderer.flipX = true;
            
        }
        if (Input.GetKey(KeyCode.D)) {
            moveVelocity = speed;
            mySpriteRenderer.flipX = false;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
	}
    void OnTriggerEnter2D() {
        grounded = true;
    }
    void OnTriggerExit2D() {
        grounded = false;
    }
}
