using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {

    public Transform targetObject;
    public Color targetColor;
    public int distance = 2;
    public int maxDistanceDelta = 25;

    BoxMovement targetScript = new BoxMovement();

    public float speed = 10;
    float deaccel = 30;
    public Vector3 impulseDirection;

    // Use this for initialization
    void Start() {
        targetScript = targetObject.GetComponent<BoxMovement>();
    }

    void Update()
    {
        if (speed != 0)
        {
            speed = Mathf.MoveTowards(speed, 0, deaccel * Time.deltaTime);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 targetViewPos = targetObject.position + (Vector3.up * distance);
        Gizmos.DrawWireSphere(targetViewPos, 0.5f);

        Gizmos.color = Color.red;
        Vector3 currentViewPos = new Vector3(transform.position.x, transform.position.y, 0);
        Gizmos.DrawWireSphere(currentViewPos, 0.5f);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(targetViewPos, currentViewPos);

    }

    void LateUpdate()
    {
        Vector3 targetCamPos = targetObject.position + (targetScript.sightDirection.up * distance);
        Vector3 currentCamPos = transform.position;
        targetCamPos.z = transform.position.z;
        float currentDistance = Vector3.Distance(currentCamPos, targetCamPos);
        transform.position = Vector3.MoveTowards(transform.position, targetCamPos, maxDistanceDelta * currentDistance * Time.deltaTime);
    }
}
