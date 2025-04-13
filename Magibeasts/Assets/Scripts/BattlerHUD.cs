using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattlerHUD : MonoBehaviour
{
    public TMP_Text HUDName;
    public TMP_Text HUDLevel;

    public Slider healthSlider;

    public void SetHUD(Battler battler)
    {
        HUDName.text = battler.battlerName.ToString();
        HUDLevel.text = "Lvl " + battler.level.ToString();
        healthSlider.maxValue = battler.maxHP;
        healthSlider.value = battler.currentHP;
    }

    public void SetHealth(int hp) {
        healthSlider.value = hp;
    }
}
