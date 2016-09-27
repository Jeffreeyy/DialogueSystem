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

    [XmlElement("option_1")]
    public string option_1;

    [XmlElement("option_2")]
    public string option_2;

    [XmlElement("option_3")]
    public string option_3;
}
