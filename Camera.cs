using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	GUITexture bgTexture;
	WebCamTexture camTexture;
	// Use this for initialization
	void Start () {
		Debug.Log("Initialize");
		bgTexture = gameObject.AddComponent<GUITexture>();
		bgTexture.pixelInset = new Rect(0,0,Screen.width,Screen.height);
		//set up camera
		WebCamDevice[] devices = WebCamTexture.devices;
		string backCamName="";
		for( int i = 0 ; i < devices.Length ; i++ ) {
			Debug.Log("Device:"+devices[i].name+ "IS FRONT FACING:"+devices[i].isFrontFacing);
			
			if (devices[i].isFrontFacing) {
				backCamName = devices[i].name;
			}
		}
		
		camTexture = new WebCamTexture(backCamName,10000,10000,30);
		camTexture.Play();
		bgTexture.texture = camTexture;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
