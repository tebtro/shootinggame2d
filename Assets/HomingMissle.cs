using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Destroy(gameObject, GetComponent<bullet>().lifetime);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = FindObjectOfType<player>().transform.position;
        GetComponent<FollowScript>().SetTarget(pos);
    }
}
