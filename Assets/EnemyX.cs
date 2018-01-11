using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour {

    public int hp = 10;
    public int points = 200;

    public float speed = 5.0f;
    public GameObject bullet;
    public float shotdelay = 8.0f;
    public bool canshoot;
    public GameObject explosion;
    private Animator animator;

    // Use this for initialization
    IEnumerator Start()
    {

        animator = GetComponent<Animator>();
        
        Move(transform.up * -1);
        if (canshoot) yield break;
        while (true)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform shotpos = transform.GetChild(i);
                Shoot(shotpos);
            }

            yield return new WaitForSeconds(shotdelay);
        }
    }

    public void Shoot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string layername = LayerMask.LayerToName(collision.gameObject.layer);
        if (!layername.Equals("bullet(Player)"))
        {
            return;
        }

        Transform playerBulletTransform = collision.transform.parent;
        bullet bullet = playerBulletTransform.GetComponent<bullet>();

        hp = hp - bullet.power;

        Destroy(collision.gameObject);

        if (hp <= 0)
        {
            FindObjectOfType<Score>().AddPoints(points);
            Explosion();
            Destroy(gameObject);
        }
        else
        {
            GetAnimator().SetTrigger("Damage");
        }
        
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    public void Move(Vector2 direction)
    {
        //bewegen
        GetComponent<Rigidbody2D>().velocity = speed * direction;
    }
}
