using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueLoader : MonoBehaviour {
    [Header("Load Dialogue")]
    [SerializeField]private TextAsset _file;

    [Header("Text Objects")]
    [SerializeField]private Text _source;
    [SerializeField]private Text _speech;
    [SerializeField]private Button[] _options;

    //Create dialogue container
    private DialogueContainer _dc;

    void Start ()
    {
        //Load all the data in the container
        _dc = DialogueContainer.Load(_file);
        //Load the dialogue
        LoadDialogue(1);
	}

    public void LoadDialogue(int ID)
    {
        //Check for each dialogue
        foreach (Dialogue dialogue in _dc.dialogues)
        {
            //Check if the ID is the same as one of the dialogue's ID
            if (dialogue.id == ID)
            {
                //Set all the text and buttons and removes buttons if not needed
                _source.text = dialogue.source;
                _speech.text = dialogue.text;
                if (dialogue.options.Length > 0)
                {
                    RemoveButtons();
                    for (int i = 0; i < dialogue.options.Length; i++)
                    {
                        _options[i].gameObject.SetActive(true);
                        _options[i].gameObject.GetComponentInChildren<Text>().text = dialogue.options[i];
                    }
                }
                else
                    RemoveButtons();
            }

        }
    }

    void RemoveButtons()
    {
        //Removes all buttons
        for (int i = 0; i < _options.Length; i++)
        {
            _options[i].gameObject.SetActive(false);
        }
    }
}
