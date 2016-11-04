using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleInteractInfo : MonoBehaviour {

    [SerializeField]private Text _interactText;
	// Use this for initialization
    void OnEnable()
    {
        CheckCollision.OnToggleInteractText += ToggleInteractState;
    }

    private void ToggleInteractState(bool state)
    {
        _interactText.enabled = state;
    }
}
