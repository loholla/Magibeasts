using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesReader : MonoBehaviour
{
    public TextAsset TJSON;

    [System.Serializable]
    public struct Moves
    {
        public string name;
        public int damage;
        public string desc;
        public string owner;
    }

    [System.Serializable]
    public struct MovesList
    {
        public Moves[] move;
    }

    public MovesList list = new MovesList();

    void Start()
    {
        list = JsonUtility.FromJson<MovesList>(TJSON.text);
    }


}