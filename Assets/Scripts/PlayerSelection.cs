using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    public static int playSelection = 6;
    public static int enemySelection = 6;

    private void setPSelection(int x) {
        playSelection = x;
    }

    public void setESelection(int x) {
        enemySelection = x;
    }
}