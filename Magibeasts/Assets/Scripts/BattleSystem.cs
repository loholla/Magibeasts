using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Build.Content;
using Unity.VisualScripting;
using System;

public enum CurrentState {
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject buttonPrefab;

    public Transform playerPosition;
    public Transform enemyPosition;

    public TMP_Text dialogueText;

    Battler playerBattler;
    Battler enemyBattler;

    public BattlerHUD playerHUD;
    public BattlerHUD enemyHUD;
    public CurrentState state;


    // Start is called before the first frame update
    void Start()
    {
        state = CurrentState.START;
        StartCoroutine(BattleSetup());
    }

    IEnumerator BattleSetup() {
        GameObject playerGO = Instantiate(playerPrefab, playerPosition);
        playerBattler = playerGO.GetComponent<Battler>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyPosition);
        enemyBattler = enemyGO.GetComponent<Battler>();

        dialogueText.text = "A wild " + enemyBattler.battlerName + " approaches!";

        playerHUD.SetHUD(playerBattler);
        enemyHUD.SetHUD(enemyBattler);
        
        yield return new WaitForSeconds(2f);

        state = CurrentState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn() {
        var panel = GameObject.Find("DialogueBox");
        dialogueText.text = "Choose your action: ";

        GameObject button1 = Instantiate<GameObject>(buttonPrefab);

        

        button1.GetComponentInChildren<TMP_Text>().text = "Attack";
        button1.GetComponent<RectTransform>().SetParent(panel.transform);
        
        Vector3 pos = Vector3.zero;
        pos.x = 75f;
        pos.y = 27f;
        pos.z = -5f;
        button1.GetComponent<RectTransform>().transform.position = pos;

        Vector2 dimensions = Vector2.zero;
        dimensions.x = 92f;
        dimensions.y = 35f;
        button1.GetComponent<RectTransform>().sizeDelta = dimensions;

        Vector3 scale = Vector3.zero;
        scale.x = 1.25f;
        scale.y = 1.147959f;
        scale.z = 1f;
        button1.GetComponent<RectTransform>().localScale = scale;
    }


}
