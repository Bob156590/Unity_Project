using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStuff : MonoBehaviour
{
    public Player_FightSkript playerScript;
    public GameObject healthPre;
    private GameObject healthPack;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_FightSkript>();
        healthPack = GameObject.FindGameObjectWithTag("HealthPack");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.RightShift)){
            playerScript.Takedamage(10);
        }
        if(Input.GetKeyUp(KeyCode.O)){
            SpwaneHealth();
        }
    }
    public void SpwaneHealth(){
        Vector3 pos = new Vector3(1.5f, .5f,-1);
        healthPack = Instantiate(healthPre);
        healthPack.transform.position = pos;
    }
}
