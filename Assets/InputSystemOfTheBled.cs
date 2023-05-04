using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemOfTheBled : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction _pylou;
    public PyloneBuilder pyloneManager;
    public LaserPointer pointer;
    public static GameObject listPylou;


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
            Debug.Log("Tenta creation pylou");

        }
    }
}
