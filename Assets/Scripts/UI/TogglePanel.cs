using UnityEngine;
using System.Collections;

public class TogglePanel : MonoBehaviour
{
    private Animator _animator;

    void OnEnable()
    {
        _animator = GetComponent<Animator>();
        CheckCollision.OnCanInteract += SetPanelState;
        DialogueLoader.OnSetPanelState += SetPanelState;
    }

    void OnDisable()
    {
        CheckCollision.OnCanInteract -= SetPanelState;
        DialogueLoader.OnSetPanelState -= SetPanelState;  
    }

    public void SetPanelState(bool state)
    {
        _animator.SetBool("isOpen", state);
    }
}
