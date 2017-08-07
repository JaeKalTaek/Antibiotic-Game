using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Train : Base_Module {

	public Dropdown antibiotic;
	public GameObject firstPanel, resultsPanel;
	public Text treatments;
	public Transform attributes, resultAttributes;
	Diagnostic diagnostic;

	public void Start() {

		antibiotic.AddOptions(Database.GetAttributeList(4));

	}

	/// <summary>
	/// Selects a new random combination of background/bacteria/resistance/site every time.
	/// </summary>
	void OnEnable() {

		do diagnostic = Database.diagnostics [Random.Range (0, Database.diagnostics.Count)];
		while (diagnostic.value.Equals ("X"));

		SetAttributesText(attributes, diagnostic);

	}

	/// <summary>
	/// Prints the results of the training.
	/// </summary>
	public void TrainingResults() {

		GameObject.Find ("Canvas").GetComponent<UI_Manager> ().ShowPanel (6);

		Diagnostic chosenDiagnostic = null;
		List<Diagnostic> preferredDiagnostics = new List<Diagnostic> ();

		foreach (Diagnostic d in Database.diagnostics) {

			if (d.background.Equals (diagnostic.background) && d.site.Equals (diagnostic.site)
				&& d.bacteria.Equals (diagnostic.bacteria) && d.resistance.Equals (diagnostic.resistance)) {

				if (d.antibiotic.Equals (antibiotic.captionText.text)) chosenDiagnostic = d;

				if (d.value.Equals("1")) preferredDiagnostics.Add (d);

			}

		}

		SetAttributesText(resultAttributes, chosenDiagnostic);

		SetResultText(chosenDiagnostic.value);

		treatments.text = "Preferred treatment" + ((preferredDiagnostics.Count < 2) ? " : " : "s : ");

		foreach (Diagnostic d in preferredDiagnostics)
			treatments.text += "\n" + d.antibiotic; 

	}

	/// <summary>
	/// Sets various texts according to a given Diagnostic.
	/// </summary>
	/// <param name="container">Container.</param>
	/// <param name="diagnostic">Diagnostic.</param>
	void SetAttributesText(Transform container, Diagnostic diagnostic) {

		for (int i = 0; i < container.childCount; i++)
			container.GetChild (i).GetComponent<Text> ().text = diagnostic.GetAttribute (i);

	}

}
