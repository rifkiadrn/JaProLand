using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody2D rb2d;
    private int count;
    private Vector2 target;
    private float currMana;
    private float maxMana;
	private float score;
    private int numKill;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
        target = transform.position;
        currMana = 8;
        maxMana = 8;
        numKill = 0;
    }

    void Update()
    {
        //for (var i = 0; i < Input.touchCount; i++)
        //{
          //  if (Input.GetTouch(i).phase == TouchPhase.Began && i == 0)
		if(Input.GetMouseButtonDown(0))
            {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        //}

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //var angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, angle * 90);
        

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You win!";
        }
    }

    public float getMana()
    {
        return currMana;
    }

	public float getScore()
	{
		return score;
	}

    public void reduceMana()
    {
        currMana = currMana - 1;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Tower"))
        {
            Debug.Log("Player on Tower", gameObject);
            Debug.Log("Recharge mana " + currMana);

            restoreMana();
            //IEnumerator coroutine = increaseMana();
            //StartCoroutine(coroutine);
        }
    }

    private void restoreMana()
    {
		if (currMana < maxMana) {
			currMana = currMana + 1;		
		}
        //currMana = Mathf.Min(currMana + 1 * Time.deltaTime, maxMana);
        /*while(currMana < maxMana)
        {
            yield return new WaitForSeconds(1);
            currMana = currMana + 1;
            Debug.Log("Recharge mana " + currMana);
        }*/
    }

	public void increaseScore()
	{
		score = score + 1;
	}

    public void increaseNumKill()
    {
        numKill = numKill + 1;
    }

    public int getNumKill()
    {
        return numKill;
    }

    public void resetNumKill()
    {
        numKill = 0;
    }
}
