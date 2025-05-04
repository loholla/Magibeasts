using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkColor : MonoBehaviour
{
    private static float blinkDuration = 0.1f;
    private static Color blinkColor = Color.red;

    [Header("Dynamic")]
    public bool showingColor = false;
    public float blinkCompleteTime;

    private Material[] materials;
    private Color[] originalColors;

    void Awake() {
        materials = GetAllMaterials(gameObject);
        originalColors = new Color[materials.Length];
        for (int i = 0; i < materials.Length; i++){
            originalColors[i] = materials[i].color;
        }
    }

    void Update() {
        if(showingColor && Time.time > blinkCompleteTime){
            RevertColors();
        }
    }

    public void TriggerBlink() {
        foreach(Material m in materials) {
            m.color = blinkColor;
        }
        showingColor = true;
        blinkCompleteTime = Time.time + blinkDuration;
    }

    private void RevertColors() {
        for (int i = 0; i < materials.Length; i++) {
            materials[i].color = originalColors[i];
        }
        showingColor = false;
    }

    private Material[] GetAllMaterials(GameObject go) {
        List<Material> mats = new List<Material>();
        Renderer[] renderers = go.GetComponentsInChildren<Renderer>();
        foreach(Renderer r in renderers){
            mats.AddRange(r.materials);
        }
        return mats.ToArray();
    }
}
