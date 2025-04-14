using UnityEngine;
using System.Collections;

public class store_dialogue : MonoBehaviour
{
    // Duration in seconds to display the dialogue panel before it disappears.
    public float displayDuration = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine that will hide the dialogue panel after displayDuration seconds.
        StartCoroutine(HideAfterDelay(displayDuration));
    }

    // Coroutine that waits for the specified delay and then disables the GameObject.
    IEnumerator HideAfterDelay(float delay)
    {
        // Wait for the specified duration.
        yield return new WaitForSeconds(delay);
        // Disable the dialogue panel.
        gameObject.SetActive(false);
    }
}
