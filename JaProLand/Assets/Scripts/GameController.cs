using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] creep;
	public GameObject boss;
    public int numCreeps;
    public float startWait;
    public float spawnWait;

	private int numCreepsTemporary;
    private TowerController tower;
    private PlayerController player;

    void Start()
    {
		Screen.SetResolution(640, 480, true);
        GameObject towerObj = GameObject.Find("Tower");
        tower = (TowerController)towerObj.GetComponent(typeof(TowerController));

        GameObject playerObj = GameObject.Find("Player");
        player = (PlayerController)playerObj.GetComponent(typeof(PlayerController));
		numCreepsTemporary = numCreeps;

        Debug.Log("Num Creeps " + numCreeps);
        StartCoroutine (SpawnWaves());
    }

    private void Update()
    {
        if (tower.getHealth() <= 0)
        {
            //Debug.Log("DESTROYED!!!!!!!!");
            Time.timeScale = 0;
        }

        if (player.getNumKill() == numCreeps)
        {
            //Debug.Log("WAVE CLEAR!!!!!!!!");
            Time.timeScale = 0;
            //player.resetNumKill();
        }
    }
	public int getCurrentCreeps()
	{
		return numCreepsTemporary;
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        var center = transform.position;
        float width = 25;
        float height = 22;
		var pos = RandomElipse(center, width, height);
		var rot = new Quaternion();

        for (int i = 0; i < 3; i++)
        {
            pos = RandomElipse(center, width, height);
            // make the object face the center
            //var rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            rot = new Quaternion();

			Instantiate(creep[0], pos, rot);

            yield return new WaitForSeconds(spawnWait);
        }
		for (int i = 0; i < 3; i++)
		{
			pos = RandomElipse(center, width, height);
			// make the object face the center
			//var rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
			rot = new Quaternion();

			Instantiate(creep[1], pos, rot);

			yield return new WaitForSeconds(spawnWait);
		}
		for (int i = 0; i < 3; i++)
		{
			pos = RandomElipse(center, width, height);
			// make the object face the center
			//var rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
			rot = new Quaternion();

			Instantiate(creep[2], pos, rot);

			yield return new WaitForSeconds(spawnWait);
		}
		numCreepsTemporary -= 10;
		for (int i = 0; i < numCreepsTemporary; i++)
		{
			pos = RandomElipse(center, width, height);
			// make the object face the center
			//var rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
			rot = new Quaternion();

			Instantiate(creep[Random.Range(0,creep.Length)], pos, rot);

			yield return new WaitForSeconds(spawnWait);
		}

		pos = RandomElipse(center, width, height);
		// make the object face the center
		//var rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
		rot = new Quaternion();

		Instantiate(boss, pos, rot);

		yield return new WaitForSeconds(spawnWait);
    }

    Vector3 RandomElipse(Vector3 center, float width, float height) { 
	    // create random angle between 0 to 360 degrees
	    var ang = Random.value * 360;
        var pos = new Vector3 ();
        pos.x = center.x + width* Mathf.Sin(ang* Mathf.Deg2Rad);
        pos.y = center.y + height* Mathf.Cos(ang* Mathf.Deg2Rad);
        pos.z = center.z;

	    return pos;
    }
}
