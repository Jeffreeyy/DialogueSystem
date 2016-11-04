using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("dialogues")]
public class DialogueContainer
{
    [XmlArray("messages")]
    [XmlArrayItem("message")]
    public List<Dialogue> dialogues = new List<Dialogue>();

    //Function to load the file
    public static DialogueContainer Load(TextAsset file)
    {
        TextAsset _xml = file;

        //If there is no XML file, give an error
        if (_xml == null)
        {
            Debug.LogError("No XML file found!");
        }

        //Create a serializer
        XmlSerializer serializer = new XmlSerializer(typeof(DialogueContainer));
        //Create a reader
        StringReader reader = new StringReader(_xml.text);
        //Deserialize the XML file and put them in the dialogues
        DialogueContainer dialogues = serializer.Deserialize(reader) as DialogueContainer;
        //Close the file
        reader.Close();
        //Return the dialogues
        return dialogues;
    }
}