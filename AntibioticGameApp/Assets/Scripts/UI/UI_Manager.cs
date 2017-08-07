using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

	public GameObject mainPanel, infectResultsPanel, cureResultsPanel;
	public Base_Module[] modules;

	void Update() {

		if (Input.GetKeyDown (KeyCode.Escape)) Back ();
			
	}

	/// <summary>
	/// Method to go back to the precedent screen (quits if on main menu).
	/// </summary>
	public void Back() {

		if (mainPanel.activeSelf)
			Application.Quit ();
		else
			ShowPanel (infectResultsPanel.activeSelf ? 1 : (cureResultsPanel.activeSelf ? 3 : 0));

	}

	/// <summary>
	/// Shows the panel according to the given id.
	/// </summary>
	/// <param name="id">Identifier.</param>
	public void ShowPanel(int id) {

		foreach (Base_Module m in modules)
			m.ResetResult ();

		foreach (Transform t in transform)
			t.gameObject.SetActive (t.GetSiblingIndex () == id);

	}

}
