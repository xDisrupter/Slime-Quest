using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate(){//Called after update so it doesnt have to compete with players update
        transform.LookAt(target);
        Vector3 desiredPosition = target.position +offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = desiredPosition;     
    }
}
