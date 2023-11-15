using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed;
    private int spTurn;
    public int dashLenth;
    public float healthPoints;
    public float baseAttack;
    public int baseAttackSpeed;
    public float attackModifier;

    public float dash;
    public Vector3 pteradactyl;
    private int where;
    public bool canMove;
    public bool isMoving;
    public bool hasMoved;
    public bool canAttack;

    public float X;
    public float Y;
    private void Start()
    {
        speed = 3;
        spTurn = Random.Range(0, speed);
        dashLenth = 3;
        healthPoints = 10;
        baseAttack = 1;
        baseAttackSpeed = 1;
        attackModifier = 1;

        canMove = false;
        isMoving = false;
        hasMoved = true;
        canAttack = false;
    }
    
    public void CanMove(Vector3 playerPteradactyl)
    {
        Vector3 diffPeteradactil = pteradactyl - playerPteradactyl;
        X = diffPeteradactil.x;
        Y = diffPeteradactil.y;
        spTurn ++ ;
        if(Mathf.Abs(diffPeteradactil.x) + Mathf.Abs(diffPeteradactil.y) > 1 && speed == spTurn) 
        {
            hasMoved = false;
            canMove = true;
            dash = 0;
            spTurn = 0;
            List<int> list = new List<int>();
            if(diffPeteradactil.y > 0) list.Add(0);
            if(diffPeteradactil.y < 0) list.Add(1);
            if(diffPeteradactil.x > 0) list.Add(2);
            if(diffPeteradactil.x < 0) list.Add(3);
            where = list[Random.Range(0, list.Count)];//It just works
        }
    }
    public void Move()
    {
        switch(where)
        {
            case 0:
                pteradactyl.y -= 0.0625f;
                break;
            case 1:
                pteradactyl.y += 0.0625f;
                break;
            case 2:
                pteradactyl.x -= 0.0625f;
                break;
            case 3:
                pteradactyl.x += 0.0625f;
                break;
        }
        dash += 0.0625f;
        if(dashLenth == dash)
        {
            canMove = false;
            hasMoved = true;
        }
        transform.position = pteradactyl;
    }
}
