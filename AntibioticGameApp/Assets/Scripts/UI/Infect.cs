using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Infect : Base_Module {

	public Dropdown background, bacteria, site;
	public GameObject firstPanel, resultsPanel;

	public void Start() {

		background.AddOptions(Database.GetAttributeList(0));
		bacteria.AddOptions(Database.GetAttributeList(1, false));
		site.AddOptions(Database.GetAttributeList(3));

	}

	/// <summary>
	/// Prints the results of the tested infection.
	/// </summary>
	public void Test() {

		//GameObject.Find ("Canvas").GetComponent<ButtonManager> ().ShowPanel (2);

		bool possible = true;

		foreach (Diagnostic d in Database.diagnostics) {

			if (d.background.Equals (background.captionText.text) && d.bacteria.Equals (bacteria.captionText.text)
				&& d.site.Equals (site.captionText.text)) {

				if (d.value.Equals ("X")) possible = false;

			}				

		}

		result.color = !possible ? Color.red : Color.green;
		result.text = "Infection " + (possible ? "possible" : "not possible");

	}

}
