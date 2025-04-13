using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Battler : MonoBehaviour
{
    [System.Serializable]
    public struct moves
    {
        int damage;
        string name;
    }

    public string battlerName;
    public int level;
    public int damage;
    public int maxHP;
    public int currentHP;
    public List<moves> moveset = new List<moves>();
}
