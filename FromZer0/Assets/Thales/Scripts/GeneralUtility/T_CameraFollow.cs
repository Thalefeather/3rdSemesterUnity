
using UnityEngine;

public class T_CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }


    /*private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }*/

}
