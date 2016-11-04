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

    public delegate void ToggleButtons(Dialogue dialogue, Button[] buttons,bool enabled);
    public static ToggleButtons OnToggleButtons;

    void OnEnable()
    {
        //Load all the data in the container
        _dc = DialogueContainer.Load(_file);
        House.OnLoadDialogue += LoadDialogue;
    }

    void OnDisable()
    {
        House.OnLoadDialogue -= LoadDialogue;
    }

    //Attacted to the buttons in the dialogue, checks the dialogue's destination and set it to that dialogue
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
                SetDialogue(dialogue);

                if (_currentDialogue.Options.Length > 0)
                {

                    OnToggleButtons(_currentDialogue, _options,false);   //Removes buttons that arent used
                    OnToggleButtons(_currentDialogue, _options,true);    // Adds buttons equal to the amount of responses/options to the current dialogue
                }
                else
                {
                    OnToggleButtons(_currentDialogue, _options,false);
                }
            }
        }
    }

    void SetDialogue(Dialogue dialogue)
    {
        //sets the text for the current dialog and shows the name of the NPC talking
        _currentDialogue = dialogue;
        _source.text = _currentDialogue.Source;
        _speech.text = _currentDialogue.Text;
        for (int i = 0; i < _currentDialogue.Options.Length; i++)
        {
            _options[i].gameObject.GetComponentInChildren<Text>().text = _currentDialogue.Options[i];
        }
    }
}
