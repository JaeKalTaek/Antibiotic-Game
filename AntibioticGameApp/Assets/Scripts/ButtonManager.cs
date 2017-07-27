using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

	public GameObject mainPanel, infectPanel, curePanel, learningPanel, learningResultsPanel, trainingPanel, trainingResultsPanel;
	public Dropdown terrainInfect, bacteriaInfect, siteInfect;
	public Dropdown terrainCure, antibioticCure, bacteriaCure, resistanceCure,siteCure;
	public Dropdown terrainLearning, antibioticLearning, bacteriaLearning, resistanceLearning, siteLearning;
	public Dropdown antibioticTraining;
	public Text infectionResult, cureResult, noResultFound, trainingResult, trainingTreatments;
	public GameObject resultLine;
	public Transform resultsContainer, trainingContainer, trainingContainer_2, learningContainer;
	public Sprite blueLineBackground, greenLineBackground;
	Diagnostic trainingDiagnostic;

	void Update() {

		if (Input.GetKeyDown (KeyCode.Escape)) {

			if (mainPanel.activeSelf)
				Application.Quit ();
			else
				ShowPanel (learningResultsPanel.activeSelf ? 3 : 0);

		}

	}

	public void ShowPanel(int id) {

		ResetTestText ();

		mainPanel.SetActive (id == 0);
		infectPanel.SetActive (id == 1);
		curePanel.SetActive (id == 2);
		learningPanel.SetActive (id == 3);
		learningResultsPanel.SetActive (id == 4);
		trainingPanel.SetActive (id == 5);
		trainingResultsPanel.SetActive (id == 6);

		if (id == 5)
			SetTrainingDiagnostic ();

	}
		
	void SetTrainingDiagnostic() {

		trainingDiagnostic = Database.diagnostics [Random.Range (0, Database.diagnostics.Count)];

		for (int i = 0; i < trainingContainer.childCount; i++) {

			int j = (i == 0) ? 0 : (i + 1);
			trainingContainer.GetChild (i).GetComponent<Text> ().text = Database.IntToString (j, trainingDiagnostic.GetValue (j) - 1);

		}

	}

	public void TestInfection() {

		bool possible = false;

		foreach (Diagnostic d in Database.diagnostics) {

			if ((d.terrain == (terrainInfect.value + 1)) && (d.bacteria == (bacteriaInfect.value + 1)) && (d.site == (siteInfect.value + 1)))
				possible = true;

		}

		infectionResult.color = !possible ? Color.red : Color.green;
		infectionResult.text = "Infection " + (possible ? "possible" : "not possible");

	}

	public void ResetTestText() {

		infectionResult.color = Color.black;
		infectionResult.text = "En attente de test";

		cureResult.color = Color.black;
		cureResult.text = "En attente de test";

		foreach (Transform t in resultsContainer)
			if(t.name.StartsWith("Result_Line")) Destroy (t.gameObject);
		
		noResultFound.gameObject.SetActive (false);

	}

	public void SetBacteriaUnknown() {

		if (bacteriaCure.value == 0)
			resistanceCure.value = 0;

	}

	public void TestCure() {

		List<int> results = new List<int>();

		foreach (Diagnostic d in Database.diagnostics) {

			if ( (d.terrain == (terrainCure.value + 1)) && (d.antibiotic == (antibioticCure.value + 1))
				&& ((d.bacteria == bacteriaCure.value) || (bacteriaCure.value == 0))
				&& ((d.resistance == resistanceCure.value) || (resistanceCure.value == 0))
				&& (d.site == (siteCure.value + 1)) ) {

				results.Add (d.value);

			}

		}

		if (results.Count > 1) {

			int first = results[0];
			bool allSame = true;

			foreach (int result in results)
				if (result != first) allSame = false;

			if (allSame) results.RemoveRange (1, results.Count - 1);

		}

		if (results.Count == 0) {

			cureResult.color = new Color (127, 0, 0);
			cureResult.text = "Infection shouldn't be possible";

		} else if (results.Count == 1) {

			SetResultText(cureResult, results [0]);

		} else {

			int[] differentResults = new int[4];

			foreach (int result in results)
				differentResults [result]++;

			cureResult.color = Color.grey;
			cureResult.text = "Various results possible";

		}

	}

	public void LearningResults() {

		ShowPanel (4);

		List<Diagnostic> results = new List<Diagnostic>();

		foreach (Diagnostic d in Database.diagnostics) {

			if ( ((d.terrain == terrainLearning.value) || (terrainLearning.value == 0))
				&& ((d.antibiotic == antibioticLearning.value) || (antibioticLearning.value == 0))
				&& ((d.bacteria == bacteriaLearning.value) || (bacteriaLearning.value == 0))
				&& ((d.resistance == resistanceLearning.value) || (resistanceLearning.value == 0))
				&& ((d.site == siteLearning.value) || (siteLearning.value == 0))) {

				results.Add (d);

			}

		}

		if (results.Count == 0) {

			noResultFound.gameObject.SetActive (true);

		} else {

			//resultsContainer.GetComponent<RectTransform> ().rect =new Rect(resultsContainer.GetComponent<RectTransform> ().rect.position, resultsContainer.GetComponent<RectTransform> ().rect.size + new Vector2(0, - 23f * results.Count));
			//resultsContainer.GetComponent<RectTransform> ().

			/*List<Transform> children = new List<Transform> ();
			foreach (Transform tr in resultsContainer.transform) {
				children.Add (tr);
			}

			resultsContainer.transform.DetachChildren ();

			resultsContainer.transform.localScale = new Vector3 (resultsContainer.transform.localScale.x, 1 + results.Count, resultsContainer.transform.localScale.z);

			foreach (Transform tr in children) {
				tr.SetParent (resultsContainer);
			}*/

			for (int i = 0; i < results.Count; i++) {

				GameObject go = Instantiate (resultLine, resultsContainer);
				go.GetComponent<Result_Line> ().Initialize (results[i]);
				go.GetComponent<Image>().sprite = ((i % 2) == 0) ? blueLineBackground : greenLineBackground;
				go.transform.position += new Vector3 (0, -.47f * i, 0);

			}		

		}

		Dropdown[] filters = new Dropdown[] {
			terrainLearning,
			siteLearning,
			bacteriaLearning,
			resistanceLearning,
			antibioticLearning
		};

		for (int i = 0; i < learningContainer.childCount; i++)
			learningContainer.GetChild (i).GetComponent<Text> ().text = GetSelectedItemText (filters [i]);

	}

	public void TrainingResults() {

		ShowPanel (6);

		for (int i = 0; i < trainingContainer.childCount; i++)
			trainingContainer_2.GetChild (i).GetComponent<Text> ().text = Database.IntToString (i, trainingDiagnostic.GetValue (i) - 1);

		trainingContainer_2.GetChild (4).GetComponent<Text> ().text = antibioticTraining.captionText.text;
	
		Diagnostic chosenDiagnostic = null;
		List<Diagnostic> preferredDiagnostics = new List<Diagnostic> ();

		foreach (Diagnostic d in Database.diagnostics) {

			if ( (d.terrain == trainingDiagnostic.terrain)
				&& (d.bacteria == trainingDiagnostic.bacteria)
				&& (d.resistance == trainingDiagnostic.resistance)
				&& (d.site == trainingDiagnostic.site) ) {

				if (d.antibiotic == (antibioticTraining.value + 1)) chosenDiagnostic = d;

				if (d.value == 1) preferredDiagnostics.Add (d);

			}

		}

		SetResultText(trainingResult, chosenDiagnostic.value);

		trainingTreatments.text = "Preferred treatment" + ((preferredDiagnostics.Count < 2) ? " : \n" : "s : \n");

		foreach (Diagnostic d in preferredDiagnostics)
			trainingTreatments.text += Database.IntToString (1, d.antibiotic - 1) + "\n";

	}

	string GetSelectedItemText(Dropdown d) {

		return (d.value == 0) ? "Unknown" : d.captionText.text;

	}

	void SetResultText(Text text, int value) {

		text.color = (value == 0) ? Color.grey : ((value == 1) ? Color.green : ((value == 2) ? new Color (255, 142, 0) : Color.red));
		text.text = (value == 0) ? "Useless" : ((value == 1) ? "Perfect" : ((value == 2) ? "Possible but not advised" : "Terrible"));

	}

}
