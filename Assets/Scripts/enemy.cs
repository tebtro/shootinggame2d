using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public int hp = 1;
    public float speed;
    spaceship spaceship;
    public int points = 100;

    IEnumerator Start()
    {
        spaceship = GetComponent<spaceship>();
        Move(transform.up * -1);
        if (!spaceship.canshoot) yield break;
        while (true)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform shotpos = transform.GetChild(i);
                spaceship.Shoot(shotpos);
            }

            yield return new WaitForSeconds(spaceship.shotdelay);
        }
    }

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

        if (hp<=0)
        {
            FindObjectOfType<Score>().AddPoints(points);
            spaceship.Explosion();
            Destroy(gameObject);
        } else
        {
            spaceship.GetAnimator().SetTrigger("Damage");
        }

       
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called once per frame
    public void Move(Vector2 direction)
    {
        //bewegen
        GetComponent<Rigidbody2D>().velocity = speed * direction;
    }
}
