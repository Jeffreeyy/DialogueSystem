using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Dialogue
{
    [XmlAttribute("id")]
    public int id;

    [XmlElement("source")]
    public string source;

    [XmlElement("text")]
    public string text;

    [XmlArray("options")]
    [XmlArrayItem("option")]
    public string[] options;
}
