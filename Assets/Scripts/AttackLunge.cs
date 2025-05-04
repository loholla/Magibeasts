using System.Collections;
using UnityEngine;

public class AttackLunge : MonoBehaviour
{
    public float lungeDistance = 0.5f;
    public float lungeDuration = 0.2f;
    public bool isPlayer = true;

    private Vector3 originalPosition;
    private bool isLunging = false;

    void Awake() {
        originalPosition = transform.localPosition;
    }

    public void TriggerLunge() {
        if (!isLunging) {
            StartCoroutine(Lunge());
        }
    }

    private IEnumerator Lunge() {
        isLunging = true;
        Vector3 targetPosition = originalPosition;

        // Decide direction of lunge
        if(isPlayer){
            targetPosition += Vector3.right * lungeDistance;
        } else {
            targetPosition += Vector3.left * lungeDistance;
        }

        // Move to target
        float elapsed = 0f;
        while(elapsed < lungeDuration / 2){
            transform.localPosition = Vector3.Lerp(originalPosition, targetPosition, elapsed / (lungeDuration / 2));
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = targetPosition;

        // Move back
        elapsed = 0f;
        while(elapsed < lungeDuration / 2){
            transform.localPosition = Vector3.Lerp(targetPosition, originalPosition, elapsed / (lungeDuration / 2));
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPosition;
        isLunging = false;
    }
}