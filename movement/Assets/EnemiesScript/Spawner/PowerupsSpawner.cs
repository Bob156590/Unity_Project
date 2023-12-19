using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsSpawner : MonoBehaviour
{
    public GameObject healthPre;
    public GameObject speedPre;
    public GameObject health;
    public GameObject speed;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("HealthPack");
        speed = GameObject.FindGameObjectWithTag("Speed_PU");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn(Vector3 pos){
        health = Instantiate(healthPre);
        health.transform.position = pos;
    }
}
