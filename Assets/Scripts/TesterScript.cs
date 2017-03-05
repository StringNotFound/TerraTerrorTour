using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour {

	//public Renderer sphereRenderer;
	public AttackManager am;
	public TerrorLine tl;
	public LineManager lm;

	// Use this for initialization
	void Start () {

		am.AddAttack (-85, -15, 2000, "Assassination", 1);
		am.DrawAttackLines (2000, 2000);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
