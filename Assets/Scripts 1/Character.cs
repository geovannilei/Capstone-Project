using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour 
{	
	[SerializeField]
	protected Transform projectilePos;
	
	[SerializeField]
	protected float movementSpeed;
	
	protected bool facingRight;
	
	[SerializeField]
	private GameObject projectilePrefab;
	
	[SerializeField]
	protected int health;
	
	[SerializeField]
	protected int deathTimer = 10;
	
	public abstract bool IsDead { get; }
	
	public bool Attack { get; set; }
	
	public Animator myAnimator { get; private set; }
	
	// Use this for initialization
	public virtual void Start ()
	{
		Debug.Log("CharStart");
		facingRight = true;
		
		myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public void ChangeDirection()
	{
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
	}
	
	public virtual void ThrowProjectile(int value)
	{
		if (facingRight)
		{
			GameObject tmp = (GameObject)Instantiate(projectilePrefab, projectilePos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
			tmp.GetComponent<Projectile>().Initialize(Vector2.right);
		}
		
		else
		{
			GameObject tmp = (GameObject)Instantiate(projectilePrefab, projectilePos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
			tmp.GetComponent<Projectile>().Initialize(Vector2.left);
		}
	}
	
	public abstract IEnumerator TakeDamage();
	
	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			StartCoroutine(TakeDamage());
		}
	}
}
