using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text towerHealth;
    public Text mana;
	public Text score;
    public Text gameOver;
    public Text outMana;
    public Text waveClear;

    private TowerController tower;
    private PlayerController player;
    private GameController game;

	// Use this for initialization
	void Start () {
        GameObject towerObj = GameObject.Find("Tower");
        tower = (TowerController)towerObj.GetComponent(typeof(TowerController));

        GameObject playerObj = GameObject.Find("Player");
        player = (PlayerController)playerObj.GetComponent(typeof(PlayerController));

        GameObject gameObj = GameObject.Find("Game Controller");
        game = (GameController)gameObj.GetComponent(typeof(GameController));
    }
	
	// Update is called once per frame
	void Update () {
		SetTowerText();
        SetManaText();
		SetPlayerScore();
        SetGameOverText();
        SetOutMana();
        SetWaveClear();
	}

    void SetTowerText()
    {
        towerHealth.text = "Health: " + tower.getHealth().ToString();
    }

    void SetManaText()
    {
        mana.text = "Mana: " + player.getMana().ToString();
    }

	void SetPlayerScore()
	{
		score.text = "Score: " + player.getScore().ToString();	
	}

    void SetGameOverText()
    {
        if (tower.getHealth() <= 0)
        {
            gameOver.text = "GAME OVER!";
        }
        else
        {
            gameOver.text = "";
        }
    }

    void SetOutMana()
    {
        if(player.getMana() <= 0)
        {
            outMana.text = "OUT OF MANA!";
        } else
        {
            outMana.text = "";
        }
    }

    void SetWaveClear()
    {
        if(player.getNumKill() == game.numCreeps)
        {
            waveClear.text = "WAVE CLEAR!";
        }
        else
        {
            waveClear.text = "";
        }
    }
}
