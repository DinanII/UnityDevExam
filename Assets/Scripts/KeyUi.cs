using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class KeyUi : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image KeyIcon;
    KeyHolder KeyHolder;

    void Start() {
        // Finds and returns the first component having a KeyHolder (the player in this case).
        KeyHolder = GameObject.FindObjectOfType<KeyHolder>();
    }

    void Update() {
        if(KeyHolder.HasKey) {
            KeyIcon.color = Color.green;
        }
        else {
            KeyIcon.color = Color.red;
        }
    }
}
