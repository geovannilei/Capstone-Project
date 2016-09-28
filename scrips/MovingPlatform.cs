using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    private Vector3 nexpos;
    private Vector3 posA;
    private Vector3 posB;
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform childTransform;
    [SerializeField]
    private Transform TransformB;

    void Start() {

        posA = childTransform.localPosition;
        posB = TransformB.localPosition;
        nexpos = posB;
    }

    void Update () {
        move();
	
	}
    private void move() {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition,nexpos, speed*Time.deltaTime);
        if (Vector3.Distance( childTransform.localPosition,nexpos) <= 0.1) {
            ChangeDestination();
        }
    }
    private void ChangeDestination() {
        nexpos = nexpos != posA ? posA : posB;
    }
}
