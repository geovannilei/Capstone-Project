using UnityEngine;
using System.Collections;

public class PatrolState : EnemyStateInterface
{
	private Enemy enemy;
	private float patrolTimer;
	private float patrolDuration = 10;
	
	public void Enter(Enemy enemy)
	{
		//throw new NotImplementedException();
		this.enemy = enemy;
	}
	
	public void Execute()
	{
		//throw new NotImplementedException();
		Debug.Log("Currently Patrol State");
		Patrol();
		
		enemy.Move();
		
		if (enemy.Target != null && enemy.inThrowRange)
		{
			enemy.ChangeState(new RangedState());
		}
	}
	
	public void Exit()
	{
		//throw new NotImplementedException();
	}
	
	public void OnTriggerEnter(Collider2D other)
	{
		//throw new NotImplementedException();
		if (other.tag == "Edge")
		{
			enemy.ChangeDirection();
		}
	}
	
	private void Patrol()
	{
		//Delta time is amount of time since last frame was rendered
		patrolTimer += Time.deltaTime;
		
		if (patrolTimer >= patrolDuration)
		{
			enemy.ChangeState(new IdleState());
		}
	}
}
