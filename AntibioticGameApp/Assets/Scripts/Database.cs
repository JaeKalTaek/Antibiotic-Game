using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour {

	[HideInInspector]
	public static List<Diagnostic> diagnostics;
	public static string[][] dictionnary;

	void Start () {

		diagnostics = new List<Diagnostic> ();

		// value / terrain / bacteria / site / resistance / antibiotic

		// sain - penicillin

		diagnostics.Add (new Diagnostic (1, 1, 1, 1, 1, 1));
		diagnostics.Add (new Diagnostic (1, 1, 1, 1, 2, 1));

		diagnostics.Add (new Diagnostic (1, 1, 1, 2, 1, 1));
		diagnostics.Add (new Diagnostic (1, 1, 1, 2, 2, 1));

		diagnostics.Add (new Diagnostic (1, 1, 2, 1, 3, 3));
		diagnostics.Add (new Diagnostic (1, 1, 2, 1, 4, 3));

		diagnostics.Add (new Diagnostic (1, 1, 2, 2, 3, 0));
		diagnostics.Add (new Diagnostic (1, 1, 2, 2, 4, 0));

		diagnostics.Add (new Diagnostic (1, 1, 3, 1, 2, 1));
		diagnostics.Add (new Diagnostic (1, 1, 3, 2, 2, 0));

		// sain - penicillin + inhib

		diagnostics.Add (new Diagnostic (1, 2, 1, 1, 1, 2));
		diagnostics.Add (new Diagnostic (1, 2, 1, 1, 2, 2));

		diagnostics.Add (new Diagnostic (1, 2, 1, 2, 1, 2));
		diagnostics.Add (new Diagnostic (1, 2, 1, 2, 2, 2));

		diagnostics.Add (new Diagnostic (1, 2, 2, 1, 3, 2));
		diagnostics.Add (new Diagnostic (1, 2, 2, 1, 4, 2));

		diagnostics.Add (new Diagnostic (1, 2, 2, 2, 3, 0));
		diagnostics.Add (new Diagnostic (1, 2, 2, 2, 4, 0));

		diagnostics.Add (new Diagnostic (1, 2, 3, 1, 2, 3));
		diagnostics.Add (new Diagnostic (1, 2, 3, 2, 2, 0));

		// sain - C3G

		diagnostics.Add (new Diagnostic (1, 3, 1, 1, 1, 2));
		diagnostics.Add (new Diagnostic (1, 3, 1, 1, 2, 2));

		diagnostics.Add (new Diagnostic (1, 3, 1, 2, 1, 2));
		diagnostics.Add (new Diagnostic (1, 3, 1, 2, 2, 2));

		diagnostics.Add (new Diagnostic (1, 3, 2, 1, 3, 1));
		diagnostics.Add (new Diagnostic (1, 3, 2, 1, 4, 1));

		diagnostics.Add (new Diagnostic (1, 3, 2, 2, 3, 1));
		diagnostics.Add (new Diagnostic (1, 3, 2, 2, 4, 1));

		diagnostics.Add (new Diagnostic (1, 3, 3, 1, 2, 2));
		diagnostics.Add (new Diagnostic (1, 3, 3, 2, 2, 0));

		// sain - Carba

		diagnostics.Add (new Diagnostic (1, 4, 1, 1, 1, 2));
		diagnostics.Add (new Diagnostic (1, 4, 1, 1, 2, 2));

		diagnostics.Add (new Diagnostic (1, 4, 1, 2, 1, 2));
		diagnostics.Add (new Diagnostic (1, 4, 1, 2, 2, 2));

		diagnostics.Add (new Diagnostic (1, 4, 2, 1, 3, 2));
		diagnostics.Add (new Diagnostic (1, 4, 2, 1, 4, 2));

		diagnostics.Add (new Diagnostic (1, 4, 2, 2, 3, 2));
		diagnostics.Add (new Diagnostic (1, 4, 2, 2, 4, 2));

		diagnostics.Add (new Diagnostic (1, 4, 3, 1, 2, 3));
		diagnostics.Add (new Diagnostic (1, 4, 3, 2, 2, 0));

		// sain - Fluoro

		diagnostics.Add (new Diagnostic (1, 5, 1, 1, 1, 3));
		diagnostics.Add (new Diagnostic (1, 5, 1, 1, 2, 3));

		diagnostics.Add (new Diagnostic (1, 5, 1, 2, 1, 0));
		diagnostics.Add (new Diagnostic (1, 5, 1, 2, 2, 0));
			
		diagnostics.Add (new Diagnostic (1, 5, 2, 1, 3, 1));
		diagnostics.Add (new Diagnostic (1, 5, 2, 1, 4, 2));

		diagnostics.Add (new Diagnostic (1, 5, 2, 2, 3, 2));
		diagnostics.Add (new Diagnostic (1, 5, 2, 2, 4, 2));

		diagnostics.Add (new Diagnostic (1, 5, 3, 1, 2, 3));
		diagnostics.Add (new Diagnostic (1, 5, 3, 2, 2, 0));

		// sain - Vanco

		diagnostics.Add (new Diagnostic (1, 6, 1, 1, 1, 0));
		diagnostics.Add (new Diagnostic (1, 6, 1, 1, 2, 0));

		diagnostics.Add (new Diagnostic (1, 6, 1, 2, 1, 0));
		diagnostics.Add (new Diagnostic (1, 6, 1, 2, 2, 0));

		diagnostics.Add (new Diagnostic (1, 6, 2, 1, 3, 0));
		diagnostics.Add (new Diagnostic (1, 6, 2, 1, 4, 0));

		diagnostics.Add (new Diagnostic (1, 6, 2, 2, 3, 0));
		diagnostics.Add (new Diagnostic (1, 6, 2, 2, 4, 0));

		diagnostics.Add (new Diagnostic (1, 6, 3, 1, 2, 3));
		diagnostics.Add (new Diagnostic (1, 6, 3, 2, 2, 1));

		// immuno - penicillin

		for (int i = 1; i < 5; i++) {
			
			diagnostics.Add (new Diagnostic (2, 1, 1, 1, i, 1));
			diagnostics.Add (new Diagnostic (2, 1, 1, 2, i, 1));
			diagnostics.Add (new Diagnostic (2, 1, 2, 1, i, 2));
			diagnostics.Add (new Diagnostic (2, 1, 2, 2, i, 0));

		}

		diagnostics.Add (new Diagnostic (2, 1, 3, 1, 1, 3));
		diagnostics.Add (new Diagnostic (2, 1, 3, 1, 2, 3));
		diagnostics.Add (new Diagnostic (2, 1, 3, 2, 1, 0));
		diagnostics.Add (new Diagnostic (2, 1, 3, 2, 2, 0));

		// immuno - penicillin + inhib

		for (int i = 1; i < 5; i++) {

			diagnostics.Add (new Diagnostic (2, 2, 1, 1, i, 2));
			diagnostics.Add (new Diagnostic (2, 2, 1, 2, i, 2));
			diagnostics.Add (new Diagnostic (2, 2, 2, 1, i, 2));
			diagnostics.Add (new Diagnostic (2, 2, 2, 2, i, 0));

		}

		diagnostics.Add (new Diagnostic (2, 2, 3, 1, 1, 1));
		diagnostics.Add (new Diagnostic (2, 2, 3, 1, 2, 1));
		diagnostics.Add (new Diagnostic (2, 2, 3, 2, 1, 0));
		diagnostics.Add (new Diagnostic (2, 2, 3, 2, 2, 0));

		// immuno - C3G

		for (int i = 1; i < 5; i++) {

			diagnostics.Add (new Diagnostic (2, 3, 1, 1, i, 2));
			diagnostics.Add (new Diagnostic (2, 3, 1, 2, i, 2));
			diagnostics.Add (new Diagnostic (2, 3, 2, 1, i, 1));
			diagnostics.Add (new Diagnostic (2, 3, 2, 2, i, 1));

		}

		diagnostics.Add (new Diagnostic (2, 3, 3, 1, 1, 2));
		diagnostics.Add (new Diagnostic (2, 3, 3, 1, 2, 2));
		diagnostics.Add (new Diagnostic (2, 3, 3, 2, 1, 0));
		diagnostics.Add (new Diagnostic (2, 3, 3, 2, 2, 0));

		// immuno - Carba

		for (int i = 1; i < 5; i++) {

			diagnostics.Add (new Diagnostic (2, 4, 1, 1, i, 2));
			diagnostics.Add (new Diagnostic (2, 4, 1, 2, i, 2));
			diagnostics.Add (new Diagnostic (2, 4, 2, 1, i, 2));
			diagnostics.Add (new Diagnostic (2, 4, 2, 2, i, 2));

		}

		diagnostics.Add (new Diagnostic (2, 4, 3, 1, 1, 2));
		diagnostics.Add (new Diagnostic (2, 4, 3, 1, 2, 2));
		diagnostics.Add (new Diagnostic (2, 4, 3, 2, 1, 0));
		diagnostics.Add (new Diagnostic (2, 4, 3, 2, 2, 0));

		// immuno - Fluoro

		for (int i = 1; i < 5; i++) {

			diagnostics.Add (new Diagnostic (2, 5, 1, 1, i, 3));
			diagnostics.Add (new Diagnostic (2, 5, 1, 2, i, 0));
			diagnostics.Add (new Diagnostic (2, 5, 2, 1, i, (i == 3) ? 1 : 2));
			diagnostics.Add (new Diagnostic (2, 5, 2, 2, i, (i == 3) ? 1 : 2));

		}

		diagnostics.Add (new Diagnostic (2, 5, 3, 1, 1, 3));
		diagnostics.Add (new Diagnostic (2, 5, 3, 1, 2, 3));
		diagnostics.Add (new Diagnostic (2, 5, 3, 2, 1, 0));
		diagnostics.Add (new Diagnostic (2, 5, 3, 2, 2, 0));

		// immuno - Vanco

		for (int i = 1; i < 5; i++) {

			diagnostics.Add (new Diagnostic (2, 6, 1, 1, i, 0));
			diagnostics.Add (new Diagnostic (2, 6, 1, 2, i, 0));
			diagnostics.Add (new Diagnostic (2, 6, 2, 1, i, 0));
			diagnostics.Add (new Diagnostic (2, 6, 2, 2, i, 0));

		}

		diagnostics.Add (new Diagnostic (2, 6, 3, 1, 1, 2));
		diagnostics.Add (new Diagnostic (2, 6, 3, 1, 2, 2));
		diagnostics.Add (new Diagnostic (2, 6, 3, 2, 1, 1));
		diagnostics.Add (new Diagnostic (2, 6, 3, 2, 2, 1));

		//-----------------------------------------------------------------

		dictionnary = new string[][] { new string[] { "Healthy", "Immuno-D" },
			new string[] { "Penicillin", "Penicillin + Inhib", "C3G", "Carbapenem", "Fluoroquinolone", "Vancomycin" },
			new string[] { "Streptococcus", "Escherischia coli", "Staphylococcus Aureus" },
			new string[] { "1", "2" },
			new string[] { "Lungs", "Skin", "Urine", "Digestive Tube" }
		};

	}	

	public static string IntToString(int field, int value) {

		return (field == 5) ? value.ToString () : dictionnary [field] [value];

	}

}
