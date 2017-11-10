using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    public int health = 3;

    // Update is called once per frame
    void Update()
    {	
        if (health == 0)
        {
            Destroy(gameObject);

            GameObject playerObj = GameObject.Find("Player");
            PlayerController player = (PlayerController)playerObj.GetComponent(typeof(PlayerController));
            player.increaseNumKill();
			player.increaseScore ();
            Debug.Log("Num Kill " + player.getNumKill());
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            GameObject towerObj = GameObject.Find("Tower");
            TowerController tower = (TowerController)towerObj.GetComponent(typeof(TowerController));
            tower.hit();

            Debug.Log("Tower health " + tower.getHealth());
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter Player Collision", gameObject);
            GameObject playerObj = GameObject.Find("Player");
            PlayerController player = (PlayerController)playerObj.GetComponent(typeof(PlayerController));

            if (player.getMana() > 0)
            {
                health = health - 1;
				//Debug.Log("Health " + health);
				GetComponent<Animator> ().SetTrigger ("isHit");
                


                player.reduceMana();

                Debug.Log("Mana " + player.getMana());
            }

            //if (Input.touchCount > 0)
            //{
            //    Touch touch = Input.GetTouch(0);

            //    Vector3 touchPosWorld = Camera.main.ScreenToWorldPoint(touch.position);

            //    Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

                //RaycastHit2D hit = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

                //if (hit.collider.tag == "Enemy")
                //{
                //    Debug.Log("Enemy is touched");
                //}

                //if (hit.collider.gameObject == gameObject)
                //{
                //    health = health - 1;
                //    Debug.Log("Health " + health);

                //    GameObject playerObj = GameObject.Find("Player");
                //    PlayerController player = (PlayerController)playerObj.GetComponent(typeof(PlayerController));
                //    player.reduceMana();
                    
                //    Debug.Log("Mana " + player.getMana());
                //}

                //if (hit.collider.tag == "Player")
                //{
                //    Debug.Log("Player is touched");
                //}
            //}
        }
    }
}
