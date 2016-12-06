using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class PlayerControl : MonoBehaviour {
	
	//[SerializeField]
	//private int maxPlayerHealth = 100;
	
	[SerializeField]
	private Stat playerHealth;
	
	public bool isDead;
	
	[SerializeField]
	private int enemyDamage = 5;
	
	[SerializeField]
	private int enemyProjectileDamage = 10;
	
    public float speed;
    public float jump;
    private float moveVelocity;
    private bool grounded = true;
    private SpriteRenderer mySpriteRenderer;
    public Animator anim;
    public Collider2D attacktriggerleft;
    public Collider2D attacktriggerright;
    public Collider2D portaltrigger;
    public object portal;
    public string nextscene;
    private bool attacking = false;
    private bool change = false;


    void Start() {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
		playerHealth.Initialize();
		//playerHealth.bar = gameObject.AddComponent(System.Type.GetType("BarScript"));
		//GameObject sc = GetComponent(System.Type.GetType("PlayerHealthBar")) as GameObject;
		//playerHealth.bar = sc;
    }
    void Awake()
    {
        attacktriggerleft.enabled = false;
        attacktriggerright.enabled = false;
    }

    void Update () {
        print(change);

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
		
		if (isDead == true) Application.LoadLevel(Application.loadedLevel);
		
		if (playerHealth.CurrentVal <= 0 && !isDead)
        {
			playerHealth.CurrentVal = 0;
			isDead = true; 
		}

		//text.text = "" + playerHealth;
		//healthBar.value = playerHealth;
		
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
	}

    void OnTriggerEnter2D() {
        grounded = true;
        anim.SetBool("IsGrounded", true);
    }

    void OnTriggerExit2D() {
        grounded = false;
        anim.SetBool("IsGrounded", false);
    }
	
	public void HurtPlayer(int damageToGive)
	{
		playerHealth.CurrentVal -= damageToGive;
	}

	public void FullHealth()
	{
		playerHealth.CurrentVal = playerHealth.MaxVal;
	}

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Spike")
        {
			playerHealth.CurrentVal = 0;
            isDead = true;
        }
		
		else if (collision.gameObject.tag == "Enemy")
		{
			HurtPlayer(enemyDamage);
			//playerHealth = playerHealth - 10;
		}
		
		else if (collision.gameObject.tag == "EnemyProjectile")
		{
			HurtPlayer(enemyProjectileDamage);
		}
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			HurtPlayer(enemyDamage);
			//playerHealth = playerHealth - 10;
		}
		
		if (collision.gameObject.tag == "EnemyProjectile")
		{
			HurtPlayer(enemyProjectileDamage);
		}
	}
}
