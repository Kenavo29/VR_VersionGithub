using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemOfTheBled : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction _pylou;
    public PyloneBuilder pyloneManager;
    public LaserPointer pointer;
    public static GameObject listPylou;
    public float increaseScale = 0.1f;


    public float scaleX = 1f;
    public float scaleY = 1f;
    public float scaleZ = 1f;


    private void Start()
    {
        _pylou = inputActions.FindActionMap("XRI RightHand").FindAction("Pylone");
        _pylou.Enable();
        _pylou.performed += TogglePylone;
    }

    private void OnDestroy()
    {
        _pylou.performed -= TogglePylone;
    }

    public void TogglePylone(InputAction.CallbackContext context)
    {
        if (pyloneManager.pyloneBuildActive)
        {
            GameObject newCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            newCylinder.transform.position = pointer.hitP;
            newCylinder.transform.localScale = new Vector3(scaleX, scaleY,scaleZ);


            Debug.Log("Tenta creation pylou");

        }
    }

    public void IncreaseScaleX()
    {
        scaleX += increaseScale;
        scaleY += increaseScale;
        scaleZ += increaseScale;
    }

    public void reduceScaleX()
    {
        scaleX -= increaseScale;
        scaleY -= increaseScale;
        scaleZ -= increaseScale;
    }
}
