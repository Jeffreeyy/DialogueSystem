using UnityEngine;
using System.Collections;

public class TogglePanel : MonoBehaviour
{
    private Animator _animator;

    void OnEnable()
    {
        _animator = GetComponent<Animator>();
        CheckCollision.OnTogglePanel += SetPanelState;
    }

    void OnDisable()
    {
        CheckCollision.OnTogglePanel -= SetPanelState;
    }

    public void SetPanelState(bool state)
    {
        _animator.SetBool("isOpen", state);
    }
}
