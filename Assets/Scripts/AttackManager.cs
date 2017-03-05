using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour {

	static int minYear = 1970;

	List<Attack>[] attacks = new List<Attack>[2015 - minYear + 1];
	public GameObject attackObject;
	public LineManager lineManager;

	public void AddAttack(float latitude, float longitude, int year, string type, float tourismEffect) {
		if (attacks [0] == null) {
			Initialize ();
		}
		GameObject attackObj = (GameObject) Instantiate (attackObject, this.transform);
		Attack attack = attackObj.GetComponent<Attack> ();
		attack.InitializeAttack (lineManager.gameObject, latitude, longitude, year, type, tourismEffect);
		Debug.Log (year);
		attacks [year - minYear].Add (attack);
	}

	void Initialize() {
		for (int i = 0; i < attacks.Length; i++) {
			attacks [i] = new List<Attack> ();
		}
	}

	public void DrawAttackLines(int startYear, int endYear) {
		Debug.Log ("Drawing Attack Lines");
		Debug.Log (startYear);
		Debug.Log (endYear);
		lineManager.DeleteLines ();
		for (int i = startYear; i <= endYear; i++) {
			var yearAttacks = attacks [i - minYear];
			foreach (Attack attack in yearAttacks) {
				attack.DrawLine ();
			}
		}
		Debug.Log ("Done");
	}

}
