using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueLoader : MonoBehaviour {
    [Header("Load Dialogue")]
    [SerializeField]private TextAsset _file;

    [Header("Text Objects")]
    [SerializeField]private Text _source;
    [SerializeField]private Text _speech;
    [SerializeField]private Text[] _options;


    private DialogueContainer _dc;
    // Use this for initialization
    void Start ()
    {
        _dc = DialogueContainer.Load(_file);

        /*foreach(Dialogue dialogue in _dc.dialogues)
        {
            print(dialogue.option_1);
        }*/
        LoadDialogue(1);
	}

    public void LoadDialogue(int ID)
    {
        foreach (Dialogue dialogue in _dc.dialogues)
        {
            if (dialogue.id == ID)
            {
                _source.text = dialogue.source;
                _speech.text = dialogue.text;
            }

        }
    }
}
