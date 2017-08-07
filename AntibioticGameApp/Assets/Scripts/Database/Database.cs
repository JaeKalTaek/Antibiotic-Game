using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class Database : MonoBehaviour {

	public static List<Diagnostic> diagnostics;
	public TextAsset databaseFile;

	void Start () {

		diagnostics = new List<Diagnostic> ();

		XmlDocument xmlDoc = new XmlDocument ();
		xmlDoc.LoadXml (databaseFile.text);
		XmlNodeList diagnosticsList = xmlDoc.GetElementsByTagName ("Diagnostic");

		foreach (XmlNode d in diagnosticsList) {

			XmlNodeList attributes = d.ChildNodes;

			Diagnostic diagnostic = new Diagnostic ();

			int i = 0;

			foreach (XmlNode a in attributes) {

				diagnostic.SetAttribute (i, a.InnerText);
				i++;

			}

			if(!diagnostic.GetAttribute(4).Equals("0")) diagnostics.Add (diagnostic);

			/*if (!diagnostic.GetAttribute (4).Equals ("0"))
				print (diagnostic.ToString ());*/

		}

	}	

	public static List<string> GetAttributeList(int id, bool unknown = true) {

		List<string> attributeList = new List<string> ();

		foreach(Diagnostic d in diagnostics)  {

			string attribute = d.GetAttribute (id);
			
			if ((!attributeList.Contains (attribute)) && (!attribute.Equals ("X"))) {

				if (unknown) {					
					attributeList.Add (attribute);
				} else {
					if(!attribute.Equals ("Unknown")) attributeList.Add (attribute);
				}

			}

		}

		return attributeList;

	}

	public static List<string> GetResistanceList(string bacteria) {

		List<string> resistanceList = new List<string> ();

		foreach(Diagnostic d in diagnostics)  {

			if (d.bacteria.Equals (bacteria) && (!d.value.Equals ("X")) && (!resistanceList.Contains (d.resistance)))
				resistanceList.Add (d.resistance);

		}

		return resistanceList;

	}

}
