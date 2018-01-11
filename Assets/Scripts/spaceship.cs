using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class spaceship : MonoBehaviour {
    public float speed = 5.0f;
    public GameObject bullet;
    public float shotdelay;
    public bool canshoot;
    public GameObject explosion;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
    // Use this for initialization
    public void Shoot (Transform origin) {
       
        Instantiate(bullet, origin.position, origin.rotation);
    }

    public Animator GetAnimator()
    {
        return animator;
    }

}
