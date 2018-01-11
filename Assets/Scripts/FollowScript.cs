using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour {

    public float speed = 2.0f;
    public Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		
	}

    public void SetTarget(Vector3 targetPos)
    {
        targetPosition = targetPos;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = Quaternion.LookRotation(this.transform.forward, targetPosition - this.transform.position);
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, speed);
	}

}
