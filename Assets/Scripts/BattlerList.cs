using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using System.Text.Json;
using TMPro.SpriteAssetUtilities;
using Unity.VisualScripting;

public class BattlerList : MonoBehaviour
{
    public TextAsset TJSON;

    [System.Serializable]
    public struct Battlers
    {
        public string battlerName;
        public int level;
        public int maxHP;
        public int currentHP;
    }
    [System.Serializable]
    public struct BattlersList
    {
        public Battlers[] battler;
    }

    public BattlersList list = new BattlersList();

    void Start()
    {
        list = JsonUtility.FromJson<BattlersList>(TJSON.text);  
    }
}
