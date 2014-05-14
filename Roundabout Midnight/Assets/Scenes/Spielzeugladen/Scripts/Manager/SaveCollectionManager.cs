using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("SaveCollectionManager")]
public class SaveCollectionManager : MonoBehaviour {

    [XmlArray("Balls")]
    [XmlArrayItem("Fitschi")]
    public List<SaveSystemXML> saveSystemXML = new List<SaveSystemXML>();
}
