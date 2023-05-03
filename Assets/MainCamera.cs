using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float moveSpeed = 10f;

    public float nearClipPlaneDistance = 0.1f;
    public float farClipPlaneDistance = 100f;
    public float nearCutPlane = 30;
    public float farCutPlane = 40;
    public bool cutPlane = false;

    // Start is called before the first frame update
    void Start()
    {
        // Récupérer la caméra attachée à cet objet
        Camera camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        transform.position += direction * moveSpeed * Time.deltaTime;


        if (Input.GetKey(KeyCode.Space))
        {

            // Récupérer la caméra attachée à cet objet
            Camera camera = GetComponent<Camera>();

            // Modifier la distance du plan de coupe proche (near clip plane)
            camera.nearClipPlane = nearCutPlane;

            // Modifier la distance du plan de coupe éloigné (far clip plane)
            camera.farClipPlane = farCutPlane;
        }
        if(Input.GetKey(KeyCode.B)){
            Camera camera = GetComponent<Camera>();
            camera.nearClipPlane = nearClipPlaneDistance;
            camera.farClipPlane = farClipPlaneDistance;
        }

    }

    public void ButtonCuttingPlane()
    {

        if (!cutPlane)
        {
            activateCuttingPlane();
            cutPlane = true;
        }
        else
        {
            disableCuttingPlane();
            cutPlane = false;
        }
    }


    public void activateCuttingPlane()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Récupérer la caméra attachée à cet objet
        Camera camera = GetComponent<Camera>();

        // Modifier la distance du plan de coupe proche (near clip plane)
        camera.nearClipPlane = nearCutPlane;

        // Modifier la distance du plan de coupe éloigné (far clip plane)
        camera.farClipPlane = farCutPlane;
    }

    public void disableCuttingPlane()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        transform.position += direction * moveSpeed * Time.deltaTime;
        Camera camera = GetComponent<Camera>();
        camera.nearClipPlane = nearClipPlaneDistance;
        camera.farClipPlane = farClipPlaneDistance;
    }
}
