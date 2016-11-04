using System.Xml;
using System.Xml.Serialization;

public class Dialogue
{
    [XmlAttribute("id")]
    public int ID { get; set; }

    [XmlElement("source")]
    public string Source { get; set; }

    [XmlElement("text")]
    public string Text { get; set; }

    [XmlArray("options")]
    [XmlArrayItem("option")]
    public string[] Options { get; set; }


    [XmlArray("destinations")]
    [XmlArrayItem("destination")]
    public int[] Destinations { get; set; }
}
