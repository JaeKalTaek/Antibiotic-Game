using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cure : Base_Module {

	public Dropdown background, bacteria, resistance, site, antibiotic;
	public GameObject firstPanel, resultsPanel;

	public void Start() {

		background.AddOptions(Database.GetAttributeList(0));
		bacteria.AddOptions(Database.GetAttributeList(1));
		resistance.AddOptions(Database.GetResistanceList(bacteria.captionText.text));
		site.AddOptions(Database.GetAttributeList(3));
		antibiotic.AddOptions(Database.GetAttributeList(4));

	}

	/// <summary>
	/// Prints the results of the tested cure.
	/// </summary>
	public void Test() {

		//GameObject.Find ("Canvas").GetComponent<ButtonManager> ().ShowPanel (4);

		string value = null;

		foreach (Diagnostic d in Database.diagnostics) {

			if (d.background.Equals (background.captionText.text) && d.antibiotic.Equals (antibiotic.captionText.text)
				&& d.site.Equals (site.captionText.text) && d.bacteria.Equals (bacteria.captionText.text)
				&& d.resistance.Equals (resistance.captionText.text)) {

				value = d.value;

			}

		}

		if (value != null)
			SetResultText (value);
		else
			print ("ERROR");

	}
		
	/// <summary>
	/// Updates the list of resistances according to the currently selected bacteria.
	/// </summary>
	public void SetResistanceList() {

		resistance.ClearOptions ();
		resistance.AddOptions(Database.GetResistanceList(bacteria.captionText.text));

	}

}
