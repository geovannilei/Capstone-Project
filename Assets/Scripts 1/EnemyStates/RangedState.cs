using UnityEngine;
using System.Collections;

public class RangedState : EnemyStateInterface
{
	private Enemy enemy;
	
	private float throwTimer;
	private float throwCoolDown = 3;
	private bool canThrow = true;
	
	public void Enter(Enemy enemy)
	{
		this.enemy = enemy;
	}
	
	public void Execute()
	{
		ThrowProjectile();
		
		if (enemy.Target != null)
		{
			enemy.Move();
		}
		else
		{
			enemy.ChangeState(new IdleState());
		}
	}
	
	public void Exit()
	{
		
	}
	
	public void OnTriggerEnter(Collider2D other)
	{
		
	}
	
	private void ThrowProjectile()
	{
		throwTimer += Time.deltaTime;
		
		if (throwTimer >= throwCoolDown)
		{
			canThrow = true;
			throwTimer = 0;
		}
		
		if (canThrow)
		{
			canThrow = false;
			enemy.myAnimator.SetTrigger("throw");
		}
	}
}
