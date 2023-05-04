using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LaserPointer : MonoBehaviour
{
    public XRRayInteractor controller; // reference to the controller with the ray interactor
    public LayerMask groundLayer; // layer mask for the ground
    public Vector3 hitP;

    private void Update()
    {
        RaycastHit hit;
        bool raycastHit = controller.TryGetCurrent3DRaycastHit(out hit);

        if (raycastHit)
        {
            // the ray has hit the ground
            Vector3 intersectionPoint = hit.point;
            hitP = intersectionPoint;
            //Debug.Log("Intersection point: " + intersectionPoint);
        }
    }


}
