using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public TextAsset dataset;
	public AttackManager attackManager;

	public int leftYear = 1990;
	public int rightYear = 1990;

	public bool debug = false;

	// Use this for initialization
	void Start () {
		if (!debug) {
			Debug.Log ("Parsing Dataset...");
			string[,] grid = CSVReader.SplitCsvGrid (dataset.text);
			int rows = grid.GetLength (1);
			Debug.Log (rows);

			rows = 1000;
			for (int i = 0; i < rows - 2; i++) {
				attackManager.AddAttack (
				//Debug.Log(grid[
					float.Parse (grid [1, i]), 
					float.Parse (grid [2, i]), 
					int.Parse (grid [0, i]), 
					grid [3, i], 
					float.Parse (grid [4, i]));
			}
			Debug.Log ("Finished parsing");
		}
	}

	public void RefreshLines() {
		if (leftYear > rightYear) {
			attackManager.DrawAttackLines (rightYear, leftYear);
		} else {
			attackManager.DrawAttackLines (leftYear, rightYear);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
