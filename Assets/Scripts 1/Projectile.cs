using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]	//ensures the Rigidbody2D component is added to any GameObject this script is attached to
public class Projectile : MonoBehaviour
{
	[SerializeField]
	private float speed;
	
	private Rigidbody2D myRigidBody;
	
	private Vector2 direction;
	
	
	// Use this for initialization
	void Start ()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
		Initialize(direction);
		//direction = Vector2.right;
	}
	
	void FixedUpdate()
	{
		myRigidBody.velocity = direction * speed;
	}
	
	public void Initialize(Vector2 direction)
	{
		this.direction = direction;
	}
	
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
	
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
