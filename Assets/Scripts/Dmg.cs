using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmg : MonoBehaviour
{
    public int calcDmg(CharStats attacker, CharStats defender, int power, bool isSpecial = false){
        float attackStat = isSpecial? attacker.specialAttack : attacker.attack;
        float defenseStat = isSpecial? defender.specialDefense : defender.defense;

        float baseDmg = (attacker.lvl * 2f / 5f + 2f) * power * (attackStat / defenseStat) / 50f + 2f;
        float randomness = Random.Range(0.85f, 1.0f);
        int dmg = Mathf.FloorToInt(baseDmg * randomness);

        return dmg;
    }
}