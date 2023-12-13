using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
    public override void CanMove(Vector3 playerPos){
        base.CanMove(playerPos);
    }
    public override void Move(){
        base.Move();
    }
    public override void CanAttack(Vector3 playerPos){
        base.CanAttack(playerPos);
    }
    public override void Takedamage(int dmg){
        base.Takedamage(dmg);
    }
    public override void Attack(bool oppertunity = false){
        base.Attack(oppertunity);
    }

}
