using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base_Module : MonoBehaviour {

	public Text result;

	/// <summary>
	/// Resets the result text.
	/// </summary>
	public void ResetResult() {

		result.color = Color.black;
		result.text = "En attente de test";

	}

	/// <summary>
	/// Sets the result text according to the given value (usually the value of a Diagnostic).
	/// </summary>
	/// <param name="value">Value.</param>
	protected void SetResultText(string value) {

		if (value.Equals ("X")) {

			result.color = new Color (127, 0, 0);
			result.text = "Infection shouldn't be possible";

		} else if (value.Equals ("0")) {

			result.color = Color.grey;
			result.text = "Useless";

		} else if (value.Equals ("1")) {

			result.color = Color.green;
			result.text = "Perfect";

		} else if (value.Equals ("2")) {

			result.color = new Color (255, 142, 0);
			result.text = "Possible but not advised";

		}

	}

}
