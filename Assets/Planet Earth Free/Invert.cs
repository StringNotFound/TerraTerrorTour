using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Invert : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh mesh = GetComponent<MeshFilter> ().mesh;
		mesh.triangles = mesh.triangles.Reverse ().ToArray ();

		MeshRenderer renderer = GetComponent<MeshRenderer> ();
		renderer.material.SetTextureScale("_MainTex", new Vector2(-1,1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
