using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

    public Transform cameraTransform;

    public float normalSpeed;
    public float fastSpeed;
    public float movementSpeed;
    public float movementTime;
    public float rotationAmount;
    public float rotationTime;
    public Vector3 zoomAmount;
    public float zoomTime;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 newZoom;

    // Start is called before the first frame update
    void Start()
    {
        
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
    }

    void HandleMovementInput(){

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
            movementSpeed = fastSpeed;
        }
        else
        {
            movementSpeed = normalSpeed;
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            
            newPosition += (transform.forward * movementSpeed);

        }

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            
            newPosition += (transform.forward * -movementSpeed);

        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            
            newPosition += (transform.right * movementSpeed);

        }
        
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            
            newPosition += (transform.right * -movementSpeed);

        }

        if(Input.GetKeyUp(KeyCode.Q)){

            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);

        }
        if(Input.GetKeyUp(KeyCode.E)){

            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);

        }

        if(Input.GetKey(KeyCode.R)){

            GetComponent<Camera> ().orthographicSize-= zoomTime;

        }
        if(Input.GetKey(KeyCode.F)){

            GetComponent<Camera> ().orthographicSize+= zoomTime;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * rotationTime);
        //cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * zoomTime);

    }
}
