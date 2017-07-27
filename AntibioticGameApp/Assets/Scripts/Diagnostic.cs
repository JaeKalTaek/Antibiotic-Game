using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diagnostic {

	public int value;
	public int terrain;
	public int bacteria;
	public int site;
	public int resistance;
	public int antibiotic;

	public Diagnostic(int t, int a, int b, int r, int s, int v) {

		terrain = t;
		antibiotic = a;
		bacteria = b;
		resistance = r;
		site = s;
		value = v;

	}

	public int GetValue(int field) {

		switch (field) {

			case 0:
				return terrain;

			case 1:
				return antibiotic;

			case 2:
				return bacteria;

			case 3:
				return resistance;

			case 4:
				return site;

			case 5:
				return value + 1;

			default:
				return -1;

		}

	}

	/*public string ToString() {

		return terrain + ", " + antibiotic + ", " + bacteria + ", " + resistance + ", " + site + ", " + value;

	}*/

}
