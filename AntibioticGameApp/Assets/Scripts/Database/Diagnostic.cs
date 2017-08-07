using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diagnostic {

	public string background;
	public string bacteria;
	public string resistance;
	public string site;
	public string antibiotic;
	public string value;
	public string reference;

	public Diagnostic() { }

	public Diagnostic(string back, string bac, string res, string s, string anti, string v, string r) {

		background = back;
		bacteria = bac;
		resistance = res;
		site = s;
		antibiotic = anti;
		value = v;
		reference = r;

	}

	public string GetAttribute(int id) {

		if (id == 0)
			return background;
		else if (id == 1)
			return bacteria;
		else if (id == 2)
			return resistance;
		else if (id == 3)
			return site;
		else if (id == 4)
			return antibiotic;
		else if (id == 5)
			return value;
		else
			return reference;

	}

	public void SetAttribute(int id, string attribute) {

		if (id == 0)
			background = attribute;
		else if (id == 1)
			bacteria = attribute;
		else if (id == 2)
			resistance = attribute;
		else if (id == 3)
			site = attribute;
		else if (id == 4)
			antibiotic = attribute;
		else if (id == 5)
			value = attribute;
		else
			reference = attribute;

	}

	public override string ToString() {

		return "Background : " + background + "\n" +
			"Bacteria : " + bacteria + "\n" +
			"Resistance : " + resistance + "\n" +
			"Site : " + site + "\n" +
			"Antibiotic : " + antibiotic + "\n" +
			"Value : " + value  + "\n" +
			"Reference : " + reference;

	}

}
