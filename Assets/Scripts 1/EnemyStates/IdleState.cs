using UnityEngine;
using System.Collections;

public class IdleState : EnemyStateInterface
{
	private Enemy enemy;
	private float idleTimer;
	private float idleDuration = 3;
	
	public void Enter(Enemy enemy)
	{
		this.enemy = enemy;
	}
	
	public void Execute()
	{
		Debug.Log("Currently Idle State");
		Idle();
		
		if (enemy.Target != null)
		{
			enemy.ChangeState(new PatrolState());
		}
	}
	
	public void Exit()
	{

	}
	
	public void OnTriggerEnter(Collider2D other)
	{
		
	}
	
	private void Idle()
	{
		enemy.myAnimator.SetFloat("speed", 0);
		
		//Delta time is amount of time since last frame was rendered
		idleTimer += Time.deltaTime;
		
		if (idleTimer >= idleDuration)
		{
			enemy.ChangeState(new PatrolState());
		}
	}
}
