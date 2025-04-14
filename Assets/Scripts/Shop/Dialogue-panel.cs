using UnityEngine;

public class DialoguePanelController : MonoBehaviour
{
    public GameObject clerkSpeechPanel;

    void Start()
    {
        // Show the panel
        clerkSpeechPanel.SetActive(true);

        // Invoke the HidePanel method after 10 seconds
        Invoke("HidePanel", 1f);
    }

    void HidePanel()
    {
        clerkSpeechPanel.SetActive(false);
    }
}
