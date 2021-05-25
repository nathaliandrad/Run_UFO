using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Enemy Follow

    public Transform target;
    public float movementSpeed;
    public float movementSpeedRun;
    public bool followState;
    public bool idleState;
    public float startFollowDistance;
    public SpriteRenderer sprite;
    Color enemyColor = new Color(144, 13, 1, 255);

    // Update is called once per frame
    void Start()
    {
        movementSpeedRun = 4;
        idleState = false;
        followState = true;
        startFollowDistance = 15;

    }
    void Update()
    {
    
        //iddle state will be true when the sprite color = enemy color
        idleState |= (sprite.color == enemyColor) == true;

        if (Vector2.Distance(transform.position, target.position) < startFollowDistance)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        }

        if (idleState)
        {
          
                transform.position = Vector2.MoveTowards(transform.position, target.position, -1 * movementSpeedRun * Time.deltaTime);

        }

    }
}
