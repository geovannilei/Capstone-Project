using UnityEngine;
using System.Collections;
using System;

public class Enemy : Character
{
	[SerializeField]
	private Stat enemyHealth;
	
	private EnemyStateInterface currentState;
	
	public GameObject Target { get; set; }
	
	[SerializeField]
	private float throwRange;
	
	public bool inThrowRange
	{
		get
		{
			if (Target != null)
			{
				return Vector2.Distance(transform.position, Target.transform.position) <= throwRange;
			}
			return false;
		}
	}
	
	// Use this for initialization
	public override void Start ()
	{
		base.Start();
		
		ChangeState(new IdleState());
		
		enemyHealth.Initialize();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!IsDead)
		{
			currentState.Execute();
		
			LookAtTarget();
		}
		
		else if (IsDead)
		{
			myAnimator.SetTrigger("death");
			deathTimer = deathTimer - 1;
			
			if (deathTimer == 0 && gameObject.tag != "Boss")
			{
				Destroy(gameObject);
			}
		}
	}
	
	private void LookAtTarget()
	{
		if (Target != null)
		{
			float xDir = Target.transform.position.x - transform.position.x;
		
			if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
			{
				ChangeDirection();
			}
		}
	}
	
	public void ChangeState(EnemyStateInterface newState)
	{
		if (currentState != null)
		{
			currentState.Exit();
		}
		
		currentState = newState;
		
		currentState.Enter(this);
	}
	
	public void Move()
	{
		if (!Attack)
		{
			myAnimator.SetFloat("speed", 1);
		
			transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
		}
		
		//myAnimator.SetFloat("speed", 1);
		
		//transform.Translate(GetDirection() * (movementSpeed * Time.deltaTime));
	}
	
	public Vector2 GetDirection()
	{
		return facingRight ? Vector2.right : Vector2.left;
		
		/*
		if (facingRight)
		{
			return Vector2.right;
		}
		else
		{
			return Vector2.left;
		}
		*/
		
	}
	
	public override void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D(other);
		currentState.OnTriggerEnter(other);
	}
	
	public override IEnumerator TakeDamage()
	{
		enemyHealth.CurrentVal -= 5;
		
		if (IsDead)
		{
			myAnimator.SetTrigger("death");
			yield return null;
		}
	}
	
	public override bool IsDead
	{
		get
		{
			// Function returns true if health is less than or equal to 0
			return enemyHealth.CurrentVal <= 0;
		}
	}
}
