using UnityEngine;
using UnityEngine.UI;

public class DialogueLoader : MonoBehaviour
{

    [Header("Load Dialogue File")]
    [SerializeField]
    private TextAsset _file;

    [Header("Text Objects")]
    [SerializeField]
    private GameObject _panel; //Panel
    [SerializeField]
    private Text _source;    //Npc thats talking
    [SerializeField]
    private Text _speech;    //The npc's dialogue
    [SerializeField]
    private Button[] _options;   //The players response options

    //Current dialogue
    private Dialogue _currentDialogue;

    //Create dialogue container
    private DialogueContainer _dc;

    void Start()
    {
        //Load all the data in the container
        _dc = DialogueContainer.Load(_file);
    }

    public void CheckDialogue(int index)
    {
        LoadDialogue(_currentDialogue.Destinations[index]);
    }

    public void LoadDialogue(int ID)
    {
        if(ID == 0)
        {
            _panel.GetComponent<TogglePanel>().SetPanelState(false);
        }

        //Check for each dialogue in the container
        foreach (Dialogue dialogue in _dc.dialogues)
        {
            //Check if the ID is the same as one of the dialogue's ID
            if (dialogue.ID == ID)
            {
                GetDialogue(dialogue);

                if (_currentDialogue.Options.Length > 0)
                {
                    RemoveButtons(); //Removes buttons that arent used
                    AddButtons();   // Adds buttons equal to the amount of responses/options to the current dialogue
                }
                else
                {
                    RemoveButtons();
                }
            }
        }
    }

    void GetDialogue(Dialogue dialogue)
    {
        //sets the text for the current dialog and shows the name of the NPC talking
        _currentDialogue = dialogue;
        _source.text = _currentDialogue.Source;
        _speech.text = _currentDialogue.Text;
    }

    void RemoveButtons()
    {
        //Removes all buttons
        for (int i = 0; i < _options.Length; i++)
        {
            _options[i].gameObject.SetActive(false);
        }
    }

    void AddButtons()
    {
        //Adds buttons that are needed for the current dialogue
        for (int i = 0; i < _currentDialogue.Options.Length; i++)
        {
            _options[i].gameObject.SetActive(true);
            _options[i].gameObject.GetComponentInChildren<Text>().text = _currentDialogue.Options[i];
        }
    }
}
