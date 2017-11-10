using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	public float speed;

    void Update()
    {
        Vector2 target = new Vector2 (0, 0);

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        var angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle * 90);
    }
}