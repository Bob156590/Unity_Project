using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "pot", menuName = "Consumble")]
public class Test : ScriptableObject {

    public int id;

    public int uses;

    public float hpDiff;

    public bool equippable;

    public bool overTimeEffect;
}
