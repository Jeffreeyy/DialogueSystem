using UnityEngine;
using System.Collections;

public class TogglePanel : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetPanelState(bool state)
    {
        _animator.SetBool("isOpen", state);
    }
}
