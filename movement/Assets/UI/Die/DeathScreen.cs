using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public TMP_Text gameOver;
    private string[] deathLevel = {
        "Subjet brainwaves have ceased\nSubject did not last long."
    };
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameOver.text = "You Died";
    }
}
