using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Build.Content;
using Unity.VisualScripting;
using System;
using UnityEngine.SceneManagement;

public enum CurrentState {
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}

public class BattleSystem : MonoBehaviour
{
    public GameObject windbunnyPrefab;
    public GameObject foxtrotPrefab;
    public GameObject rooPrefab;
    public GameObject mushroomPrefab;
    public GameObject fluffPrefab;
    public GameObject GAVIN;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject buttonPrefab;

    public Transform playerPosition;
    public Transform enemyPosition;

    public TMP_Text dialogueText;

    CharStats playerBattler;
    CharStats enemyBattler;

    public BattlerHUD playerHUD;
    public BattlerHUD enemyHUD;
    public CurrentState state;

    public ButtonManager buttonManager;
    public Dmg damage;


    // Start is called before the first frame update
    void Start()
    {
        buttonManager = gameObject.AddComponent(typeof(ButtonManager)) as ButtonManager;
        state = CurrentState.START;
        StartCoroutine(BattleSetup());
    }

     IEnumerator BattleSetup() {
        
        playerPrefab = assignPrefab(PlayerSelection.playSelection);
        GameObject playerGO = Instantiate(playerPrefab, playerPosition);
        playerBattler = playerGO.GetComponent<CharStats>();

        enemyPrefab = assignPrefab(PlayerSelection.enemySelection);
        GameObject enemyGO = Instantiate(enemyPrefab, enemyPosition);
        enemyBattler = enemyGO.GetComponent<CharStats>();

        dialogueText.text = "A wild " + enemyBattler.charName + " approaches!";

        playerHUD.SetHUD(playerBattler);
        enemyHUD.SetHUD(enemyBattler);
        
        yield return new WaitForSeconds(2f);

        state = CurrentState.PLAYERTURN;
        damage = gameObject.AddComponent(typeof(Dmg)) as Dmg;
        buttonManager.CreateFirstSetButtons(buttonPrefab);
        PlayerTurn();
    }

    void PlayerTurn() {
        dialogueText.text = "Choose your action: ";
        
        GameObject b1 = GameObject.Find("AttackButton");
        b1.GetComponent<Button>().onClick.AddListener(delegate() {OnMovesButton();});

    }

    public void OnAttackButton() {
        if (state != CurrentState.PLAYERTURN) return;

        StartCoroutine(PlayerAttack());
    }

    public void OnMovesButton() {
        buttonManager.DestroyFirstSetButtons();
        buttonManager.CreateMoveButtons(buttonPrefab);
        GameObject b1 = GameObject.Find("Move1");
        b1.GetComponent<Button>().onClick.AddListener(delegate() {OnAttackButton();});

        GameObject b2 = GameObject.Find("Move2");
        b2.GetComponent<Button>().onClick.AddListener(delegate() {OnAttackButton();});

        GameObject b3 = GameObject.Find("Move3");
        b3.GetComponent<Button>().onClick.AddListener(delegate() {OnAttackButton();});

        GameObject b4 = GameObject.Find("Back");
        b4.GetComponent<Button>().onClick.AddListener(delegate() {OnBackButton();});
    }

    public void OnBackButton() {
        buttonManager.DestroySecondSetButtons();
        buttonManager.CreateFirstSetButtons(buttonPrefab);

        GameObject b1 = GameObject.Find("AttackButton");
        b1.GetComponent<Button>().onClick.AddListener(delegate() {OnMovesButton();});
    }

    IEnumerator PlayerAttack() {
        state = CurrentState.ENEMYTURN;

        dialogueText.text = playerBattler.charName + " is attacking!";

        playerBattler.GetComponent<AttackLunge>()?.TriggerLunge();

        yield return new WaitForSeconds(1f);

        bool death = enemyBattler.takeDmg(damage.calcDmg(playerBattler, enemyBattler, playerBattler.attack, false));

        if (death) {
            state = CurrentState.WON;
            EndBattle();
        } else {
            enemyHUD.SetHealth(enemyBattler.currHP);
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn() {
        yield return new WaitForSeconds(1f);

        dialogueText.text = enemyBattler.charName + " is attacking!";

        enemyBattler.GetComponent<AttackLunge>()?.TriggerLunge();
        
        yield return new WaitForSeconds(1f);

        bool death = playerBattler.takeDmg(damage.calcDmg(enemyBattler, playerBattler, enemyBattler.attack, false));

        playerHUD.SetHealth(playerBattler.currHP);

        yield return new WaitForSeconds(1f);

        if (death) {
            state = CurrentState.LOST;
            EndBattle();
        } else {
            state = CurrentState.PLAYERTURN;
            PlayerTurn();
        }
    }
    
    void EndBattle() {
        if (state == CurrentState.WON) {
            dialogueText.text = "You win!";
            SceneManager.LoadScene("walking");
        } else if (state == CurrentState.LOST) {
            dialogueText.text = "You lose! Game Over.";
        }
    }

    GameObject assignPrefab(int num)
    {
        switch(num) {
            case 2:
                return foxtrotPrefab;
            case 3:
                return rooPrefab;
            case 4:
                return mushroomPrefab;
            case 5:
                return fluffPrefab;
            case 6:
                return GAVIN;
            default:
                return windbunnyPrefab;
        }
    }

    public int RandomNum() {return UnityEngine.Random.Range(1, 6);}
}
