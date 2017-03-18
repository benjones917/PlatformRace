using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
	public float minX = -10;
	public float maxX = 10;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position;
    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 15f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            
			transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
			transform.position = new Vector3 (
				Mathf.Clamp (transform.position.x, minX, maxX), transform.position.y, transform.position.z);

        }
    }
}