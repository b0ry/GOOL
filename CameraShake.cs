using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
	Vector3 originPosition = new Vector3();
	Quaternion originRotation = new Quaternion();
	float shake_decay;
	float shake_intensity;
	
	void Update(){
		if(shake_intensity > 0f){
			transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			transform.rotation =  new Quaternion(
				originRotation.x + Random.Range(-shake_intensity,shake_intensity)*0.2f,
				originRotation.y + Random.Range(-shake_intensity,shake_intensity)*0.2f,
				originRotation.z + Random.Range(-shake_intensity,shake_intensity)*0.2f,
				originRotation.w + Random.Range(-shake_intensity,shake_intensity)*0.2f);
			shake_intensity -= shake_decay;
			if (shake_intensity <= 0f)
			{
				transform.position = originPosition;
				transform.rotation = originRotation;
			}
		}
	}
	
	public void Shake(){
		originPosition = transform.position;
		originRotation = transform.rotation;
		shake_intensity = 0.2f;
		shake_decay = 0.002f;
	}
}
