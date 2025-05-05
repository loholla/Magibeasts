using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

public class ButtonManager : MonoBehaviour
{
    int[] moves = new int[3];

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            int x = UnityEngine.Random.Range(1, 14);
            if (moves.Contains(x))
            {
                x = UnityEngine.Random.Range(1, 14);
            }

            moves[i] = x;
        }
    }

    public void CreateFirstSetButtons(GameObject buttonPrefab) {
        GameObject button1 = Instantiate<GameObject>(buttonPrefab);
        var panel = GameObject.Find("DialogueBox");

        Quaternion rotation = Quaternion.Euler(0, 0, 0);

        button1.GetComponentInChildren<TMP_Text>().text = "Attack";
        button1.GetComponent<RectTransform>().SetParent(panel.transform);
        button1.name = "AttackButton";
        
        Vector3 pos = Vector3.zero;
        pos.x = 75;
        pos.y = 27;
        pos.z = -5;

        button1.GetComponent<RectTransform>().transform.SetLocalPositionAndRotation(pos, rotation);

        Vector2 dimensions = Vector2.zero;
        dimensions.x = 92;
        dimensions.y = 35;
        button1.GetComponent<RectTransform>().sizeDelta = dimensions;

        Vector3 scale = Vector3.zero;
        scale.x = 1.25f;
        scale.y = 1.147959f;
        scale.z = 1;
        button1.GetComponent<RectTransform>().localScale = scale;

        GameObject button3 = Instantiate<GameObject>(buttonPrefab);
        
        button3.GetComponentInChildren<TMP_Text>().text = "Items";
        button3.GetComponent<RectTransform>().SetParent(panel.transform);
        button3.name = "ItemButton";
        
        pos = Vector3.zero;
        pos.x = 75;
        pos.y = -30;
        pos.z = -5;

        button3.GetComponent<RectTransform>().transform.SetLocalPositionAndRotation(pos, rotation);

        dimensions = Vector2.zero;
        dimensions.x = 92;
        dimensions.y = 35;
        button3.GetComponent<RectTransform>().sizeDelta = dimensions;

        scale = Vector3.zero;
        scale.x = 1.25f;
        scale.y = 1.147959f;
        scale.z = 1;
        button3.GetComponent<RectTransform>().localScale = scale;

        
    }

    public void DestroyFirstSetButtons()
    {
        GameObject GO1 = GameObject.Find("AttackButton");
        GameObject GO3 = GameObject.Find("ItemButton");
        Destroy(GO1);
        Destroy(GO3);
    }

    public void CreateMoveButtons(GameObject buttonPrefab)
    {
        GameObject go = GameObject.Find("MovesList");
        
        GameObject button1 = Instantiate<GameObject>(buttonPrefab);
        var panel = GameObject.Find("DialogueBox");

        Quaternion rotation = Quaternion.Euler(0, 0, 0);

        button1.GetComponentInChildren<TMP_Text>().text = "move1";
        button1.GetComponent<RectTransform>().SetParent(panel.transform);
        button1.name = "Move1";
        
        Vector3 pos = Vector3.zero;
        pos.x = 75;
        pos.y = 27;
        pos.z = -5;

        button1.GetComponent<RectTransform>().transform.SetLocalPositionAndRotation(pos, rotation);

        Vector2 dimensions = Vector2.zero;
        dimensions.x = 92;
        dimensions.y = 35;
        button1.GetComponent<RectTransform>().sizeDelta = dimensions;

        Vector3 scale = Vector3.zero;
        scale.x = 1.25f;
        scale.y = 1.147959f;
        scale.z = 1;
        button1.GetComponent<RectTransform>().localScale = scale;

        GameObject button2 = Instantiate<GameObject>(buttonPrefab);
        button2.GetComponentInChildren<TMP_Text>().text = "move2";
        button2.GetComponent<RectTransform>().SetParent(panel.transform);
        button2.name = "Move2";

        pos.x = 250;
        button2.GetComponent<RectTransform>().transform.SetLocalPositionAndRotation(pos, rotation);
        button2.GetComponent<RectTransform>().sizeDelta = dimensions;
        button2.GetComponent<RectTransform>().localScale = scale;

        GameObject button3 = Instantiate<GameObject>(buttonPrefab);
        
        pos.x = 75;
        pos.y = -32;
        button3.GetComponentInChildren<TMP_Text>().text = "move3";
        button3.GetComponent<RectTransform>().SetParent(panel.transform);
        button3.name = "Move3";


        button3.GetComponent<RectTransform>().transform.SetLocalPositionAndRotation(pos, rotation);
        button3.GetComponent<RectTransform>().sizeDelta = dimensions;
        button3.GetComponent<RectTransform>().localScale = scale;

        GameObject button4 = Instantiate<GameObject>(buttonPrefab);

        button4.GetComponentInChildren<TMP_Text>().text = "Back";
        button4.GetComponent<RectTransform>().SetParent(panel.transform);
        button4.name = "Back";

        pos.x = 250;
        button4.GetComponent<RectTransform>().transform.SetLocalPositionAndRotation(pos, rotation);
        button4.GetComponent<RectTransform>().sizeDelta = dimensions;
        button4.GetComponent<RectTransform>().localScale = scale;

    }
    public void DestroySecondSetButtons()
    {
        GameObject go1 = GameObject.Find("Move1");
        GameObject go2 = GameObject.Find("Move2");
        GameObject go3 = GameObject.Find("Move3");
        GameObject go4 = GameObject.Find("Back");
        Destroy(go1);
        Destroy(go2);
        Destroy(go3);
        Destroy(go4);
    }
}
