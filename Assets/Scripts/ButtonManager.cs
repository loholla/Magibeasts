using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
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

        GameObject button2 = Instantiate<GameObject>(buttonPrefab);
        
        button2.GetComponentInChildren<TMP_Text>().text = "Beasts";
        button2.GetComponent<RectTransform>().SetParent(panel.transform);
        button2.name = "BeastButton";
        
        pos = Vector3.zero;
        pos.x = 236;
        pos.y = 27;
        pos.z = -5;

        button2.GetComponent<RectTransform>().transform.SetLocalPositionAndRotation(pos, rotation);

        dimensions = Vector2.zero;
        dimensions.x = 92;
        dimensions.y = 35;
        button2.GetComponent<RectTransform>().sizeDelta = dimensions;

        scale = Vector3.zero;
        scale.x = 1.25f;
        scale.y = 1.147959f;
        scale.z = 1;
        button2.GetComponent<RectTransform>().localScale = scale;

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

        GameObject button4 = Instantiate<GameObject>(buttonPrefab);
        
        button4.GetComponentInChildren<TMP_Text>().text = "button?";
        button4.GetComponent<RectTransform>().SetParent(panel.transform);
        
        pos = Vector3.zero;
        pos.x = 236;
        pos.y = -30;
        pos.z = -5;

        button4.GetComponent<RectTransform>().transform.SetLocalPositionAndRotation(pos, rotation);

        dimensions = Vector2.zero;
        dimensions.x = 92;
        dimensions.y = 35;
        button4.GetComponent<RectTransform>().sizeDelta = dimensions;

        scale = Vector3.zero;
        scale.x = 1.25f;
        scale.y = 1.147959f;
        scale.z = 1;
        button4.GetComponent<RectTransform>().localScale = scale;
    }
}
