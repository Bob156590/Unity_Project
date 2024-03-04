using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consume : MonoBehaviour
{
    Player player;
    FightScript fightScript;
    public Test test;
    public int id;
    public int uses;
    public float hpDiff;
    public bool equippable;
    public bool overTimeEffect;
    // Start is called before the first frame update
    void Start()
    {
        fightScript = GameObject.FindGameObjectWithTag("Player").GetComponent<FightScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        id = test.id;
        uses = test.uses;
        hpDiff = test.hpDiff;
        equippable = test.equippable;
        overTimeEffect = test.overTimeEffect;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.CompareTo("Player") == 0)
        {
            
            switch (equippable)
            {
                case true:
                    break;
                case false:
                    if(overTimeEffect)
                    {
                        fightScript.Takedamage2(2,2);
                    }
                    break;
            }
            Destroy(gameObject);  
        }   
    }
}
