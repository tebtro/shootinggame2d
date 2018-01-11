using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    spaceship spaceship;
	// Use this for initialization
	IEnumerator Start () {
        while (true)
        {
            spaceship = GetComponent<spaceship>();
            spaceship.Shoot(transform);
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(spaceship.shotdelay);
        }
	}
	
   
	// Update is called once per frame
	void Update () {
        // horizontale und vertikale bewegung empfangen
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x,y).normalized;
        Move(direction);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetComponent<FollowScript>().SetTarget(mousePos);
    }

    private void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        Vector2 pos = transform.position; 
        pos = pos+direction*+spaceship.speed*Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x,min.x,max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string layername = LayerMask.LayerToName(collision.gameObject.layer);
        if (layername.Equals("bullet(Enemy)"))
        {
            Destroy(collision.gameObject);
        }
        if (layername.Equals("bullet(Enemy)") || layername.Equals("enemy"))
        {
            FindObjectOfType<manager>().GameOver();
            FindObjectOfType<Score>().Save();
            spaceship.Explosion();
            Destroy(gameObject);
        }
    }
}
