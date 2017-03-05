using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrorLine : MonoBehaviour {

	LineRenderer line;
	//private static float innerSphere = ;
	static float width = .02f;
	static float longitude_offset = -90f;
	static float radius = 3.8f;

	// Use this for initialization
	void Start () {
		
	}

	public void DrawLine(float longitude, float latitude, float scale, Material material) {
		line = this.gameObject.GetComponent<LineRenderer>();
		Debug.Log ("Drawing the line...");
		longitude += longitude_offset;
		Vector3 spherePoint = GetPointOnSphere (longitude, latitude, radius);
		Vector3 innerSpherePoint = GetPointOnSphere(longitude, latitude, radius/2.0f);
		Vector3 endPoint = spherePoint * (1 - scale) + innerSpherePoint * (scale);
		//Vector3 endPoint = innerSpherePoint;
		//Vector3 endPoint = Vector3.zero;
		var arr = new Vector3[] { spherePoint, endPoint };
		line.numPositions = 2;
		line.SetPositions(arr);
		
		line.material = material;
		line.startWidth = width;
		line.endWidth = .005f;
	}

	// Use this for initialization
	Vector3 GetPointOnSphere(float longitude, float latitude, float radius)
	{
		
		latitude = Mathf.PI * latitude / 180;
		longitude = -Mathf.PI * longitude / 180;

		// adjust position by radians	
		//latitude -= Mathf.PI/2; // subtract 90 degrees (in radians)

		// and switch z and y (since z is forward)
		/*float xPos = (radius) * Mathf.Sin(latitude) * Mathf.Cos(longitude);
		float zPos = (radius) * Mathf.Sin(latitude) * Mathf.Sin(longitude);
		float yPos = (radius) * Mathf.Cos(latitude);*/

		float xPos = (radius) * Mathf.Cos (latitude) * Mathf.Cos (longitude);
		float zPos = (radius) * Mathf.Cos (latitude) * Mathf.Sin (longitude);
		float yPos = (radius) * Mathf.Sin (latitude);


		// return position
		return new Vector3(xPos, yPos, zPos);
	}
}
