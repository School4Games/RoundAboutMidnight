using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

public class Levelmanager : MonoBehaviour {

    public void WriteToXml()
    {
        string filepath = Application.dataPath + "/Data/gamexmldata.xml";
        XmlDocument xmlDoc = new XmlDocument();

        if (File.Exists(filepath))
        {
            xmlDoc.Load(filepath);
            XmlElement elmRoot = xmlDoc.DocumentElement;
            XmlElement elmNew = xmlDoc.CreateElement("level");

            XmlElement level = xmlDoc.CreateElement("lvl");

            elmNew.AppendChild(level);

            xmlDoc.Save(filepath);
        }
    }
}



