using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int playerHP;
    public int dmg;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = 100;
        dmg = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP <= 0) SceneManager.LoadScene("GameOver");
    }

    public void Takedamage(int dmg){
        playerHP -= dmg;
    }
}
