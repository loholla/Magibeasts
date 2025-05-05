using UnityEngine;
using UnityEngine.SceneManagement;

public class Platform : MonoBehaviour
{
    [Header("Inscribed")]
    public string platform;

    void Start(){
        if (platform != "battle" && platform != "shop"){
            platform = null;
        }
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            if (platform == "battle"){
                PlayerSelection.setESelection();
                Debug.Log("Battle scene");
                SceneManager.LoadScene("BattleScene");
            } else if (platform == "shop"){
                Debug.Log("Shop scene");
                //SceneManager.LoadScene("ShopScene");
            } else {
                Debug.Log("How did you get here?");
            }
        }
    }
}
