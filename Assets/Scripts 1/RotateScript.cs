using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour
{
	// http://answers.unity3d.com/questions/569717/trying-to-make-a-projectile-rotate-and-move-forwar.html

	// Ignoring collisions by layer
	// http://answers.unity3d.com/questions/642871/ignore-collision-for-2d-collider.html
	
	int X;
	int Y;
	int Z;
	
	float rotationsPerMinute = 100f;
	
	void Start()
	{
		//gameObject.rigidbody.AddForce(transform.forward * shotPower, ForceMode.Impulse);
	}
	
	void FixedUpdate()
	{
		transform.Rotate(X, Y, Z * (rotationsPerMinute * Time.deltaTime), 0);
	}
}