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

    public void SetHUD(CharStats battler)
    {
        HUDName.text = battler.charName.ToString();
        HUDLevel.text = "Lvl " + battler.lvl.ToString();
        healthSlider.maxValue = battler.maxHP;
        healthSlider.value = battler.currHP;
    }

    public void SetHealth(int hp) {
        healthSlider.value = hp;
    }

}
