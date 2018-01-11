using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float speed = 0.2f;
    public float lifetime = 5;
    public int power = 1;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = speed * transform.up.normalized;
        Destroy(gameObject,lifetime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
