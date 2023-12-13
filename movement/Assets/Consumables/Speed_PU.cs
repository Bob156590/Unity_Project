using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_PU : MonoBehaviour
{
    float distance;
    MovementControls player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementControls>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance == 0){
            Destroy(gameObject);
            player.maxMovement++;
        }
    }
}
