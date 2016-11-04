using UnityEngine;
using System.Collections;

public class CheckCollision : MonoBehaviour
{
    public delegate void TogglePanelAction(bool state);
    public static event TogglePanelAction OnTogglePanel;

    public delegate void ToggleInteractText(bool state);
    public static event ToggleInteractText OnToggleInteractText;

    private House _house;

    private bool _canInteract;


    void OnEnable()
    {
        _house = GetComponent<House>();
        PlayerPCInput.OnInteract += CheckInteractState;
    }

    void OnDisable()
    {
        PlayerPCInput.OnInteract -= CheckInteractState;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        _canInteract = true;

        if (OnToggleInteractText != null)
            OnToggleInteractText(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        _canInteract = false;

        if(OnToggleInteractText != null)
            OnToggleInteractText(false);

        if(OnTogglePanel != null)
            OnTogglePanel(false);
    }

    private void CheckInteractState()
    {
        if(_canInteract)
        {
            if (OnTogglePanel != null)
                OnTogglePanel(true);

            if(OnToggleInteractText != null)
                OnToggleInteractText(false);

            _house.Ring();
            _canInteract = false;
        }
    }
}
