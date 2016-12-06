using UnityEngine;
using System.Collections;

public interface EnemyStateInterface
{
	void Execute();
	void Enter(Enemy enemy);
	void Exit();
	void OnTriggerEnter(Collider2D other);
}
