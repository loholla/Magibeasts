using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int lvl = 1;
    public int maxHP = 100;
    public int currHP;
    public int attack = 10;
    public int defense = 10;
    public int specialAttack = 20;
    public int specialDefense = 20;
    public int speed = 10;

    void Start(){
        currHP = maxHP;
    }

    public bool takeDmg(int dmg){
        currHP -= dmg;
        if(currHP < 0){
            currHP = 0;
        }

        return(currHP == 0);
    }

    public void Heal(int hp){
        currHP += hp;
        if(currHP > maxHP){
            currHP = maxHP;
        }
    }
}