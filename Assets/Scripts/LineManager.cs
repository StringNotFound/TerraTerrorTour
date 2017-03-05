using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {

	public void DeleteLines() {
		foreach (Transform child in transform) {
			Destroy(child.gameObject);
		}
	}

}
