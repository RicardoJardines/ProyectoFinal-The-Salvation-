using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

    public Transform targetTransform;
    public float distance;
    public float smooth;
    public float height;
    private float yVelocity = 0.0f;

    private Vector3 camPosition;
    
	// Update is called once per frame
	void Update () {

        var angle = targetTransform.GetComponentInParent<PlayerController>().FirstRotation;
        float targuetAngle = angle.y ==0 || angle.y == -90 ? angle.y+270 :angle.y -90  ;
        
        float yAngle = Mathf.SmoothDamp(transform.eulerAngles.y, targuetAngle, ref yVelocity, smooth);
        
        Vector3 position = targetTransform.position;
        position += Quaternion.Euler(0, yAngle, 0) * new Vector3(0, height, -distance);
        transform.position = position;
        transform.LookAt(targetTransform);
	}
}
