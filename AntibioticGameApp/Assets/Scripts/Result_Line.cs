using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result_Line : MonoBehaviour {

	public void Initialize(Diagnostic d) {

		for (int i = 0; i < transform.childCount; i++)
			transform.GetChild(i).GetComponent<Text>().text = Database.IntToString (i, d.GetValue (i) - 1);

	}

}
