using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetOptionButtons : MonoBehaviour
{
    void OnEnable()
    {
        DialogueLoader.OnToggleButtons += ToggleButtons;
    }

    void OnDisable()
    {
        DialogueLoader.OnToggleButtons -= ToggleButtons;
    }

    private void ToggleButtons(Dialogue dialogue, Button[] buttons,bool enabled)
    {
        if(enabled)
        {
            //Adds buttons that are needed for the current dialogue
            for (int i = 0; i < dialogue.Options.Length; i++)
            {
                buttons[i].gameObject.SetActive(true);
            }
        }
        else
        {
            //Removes all buttons
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }
}
