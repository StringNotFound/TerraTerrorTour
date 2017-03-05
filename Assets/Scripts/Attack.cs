using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	//GameObject linePrefab;
	public TerrorLine linePrefab;
	public GameObject lineManager;
	public float latitude;
	public float longitude;
	public int year;
	public Material type;
	public float tourismEffect;

	public Material Assassination;
	public Material Hijacking;
	public Material Kidnapping;
	public Material Barricade_Incident;
	public Material Bombing;
	public Material Armed_Assault;
	public Material Unarmed_Assault;
	public Material Facility;
	public Material Unknown;

	public void InitializeAttack(
		GameObject lineManager,
		float latitude, 
		float longitude, 
		int year, 
		string type, 
		float tourismEffect) {

		this.lineManager = lineManager;
		this.latitude = latitude;
		this.longitude = longitude;
		this.year = year;
		this.type = GetColorFromType(type);
		this.tourismEffect = tourismEffect;
	}

	public void DrawIfInYear(int startYear, int endYear) {
		if (this.year >= startYear || this.year <= endYear) {
			DrawLine ();
		}
	}

	public void DrawLine() {
		var newLine = Instantiate (linePrefab, lineManager.transform);
		//TerrorLine tl = newLine.GetComponent<TerrorLine> ();
		Debug.Log ("attack is drawing line...");
		newLine.DrawLine (longitude, latitude, tourismEffect, type);
	}

	Material GetColorFromType(string type) {
		switch (type) 
		{
		case "Assassination":
			return Assassination;
		case "Hijacking":
			return Hijacking;
		case "Kidnapping":
			return Kidnapping;
		case "Barricade Incident":
			return Barricade_Incident;
		case "Bombing/Explosion":
			return Bombing;
		case "Armed Assault":
			return Armed_Assault;
		case "Unarmed Assault":
			return Unarmed_Assault;
		case "Facility/Infrastructure Attack":
			return Facility;
		case "Unknown":
		default:
			return Unknown;
		}
	}
}
