﻿using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class SaveSystemXML : MonoBehaviour {

    [XmlAttribute("name")]
    public string name;
}
