using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    public static int playSelection = UnityEngine.Random.Range(1, 6);
    public static int enemySelection = UnityEngine.Random.Range(1, 6);

    public static void setPSelection(int x) {
        playSelection = x;
    }

    public static void setESelection() {
        enemySelection = UnityEngine.Random.Range(1,6);
    }

}