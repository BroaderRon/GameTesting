using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToCamera : MonoBehaviour
{

    private Transform Camera;
    private Vector3 targetPos;
    private Vector3 targetDir;

    public float angle;

    // Start is called before the first frame update
    void Start()
    {
       // Camera = FindObjectOfType<CameraMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Get Tareget Position and Direction
        targetPos = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        targetDir = targetPos - transform.position;

        // Get Angle
        angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, targetPos);
    }
}
