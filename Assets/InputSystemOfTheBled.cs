using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemOfTheBled : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction _pylou;
    public PyloneBuilder pyloneManager;
    public LaserPointer pointer;


    private void Start()
    {
        _pylou = inputActions.FindActionMap("XRI RightHand").FindAction("Pylone");
        _pylou.Enable();
    }

    public void TogglePylone(InputAction.CallbackContext context)
    {
        if (pyloneManager.pyloneBuildActive)
        {

        }
    }
}
