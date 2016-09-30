using UnityEngine;
using System.Collections;

public class TogglePanel : MonoBehaviour {

    private Animator _animator;
    private bool _isOpen = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ToggleDialogPanel()
    {
        _isOpen = !_isOpen;
        _animator.SetBool("isOpen", _isOpen);
    }
}
