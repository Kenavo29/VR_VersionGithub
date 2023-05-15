using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class InputSystemOfTheBled : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction _pylou;
    public PyloneBuilder pyloneManager;
    public WallsBuilder wallManager;
    public LaserPointer pointer;



    public static GameObject[] listObj;
    public int index;
    public int increaseScale = 2;
    public int decreaseScale = 2;
    public MenuManager menuManager;

    private GameObject cylinderPreview;
    private GameObject wallPreview;
    private Renderer rendererC;
    private Renderer rendererW;
    public Material wallMat;
    public Material pylonMat;



    public float scaleX = 1f;
    public float scaleY = 1f;
    public float scaleZ = 1f;


    public void Start()
    {
        Debug.Log("Initialisation OK");

        listObj = new GameObject[1000];
        index = 0;
        _pylou = inputActions.FindActionMap("XRI RightHand").FindAction("Pylone");
        _pylou.Enable();
        _pylou.performed += TogglePylone;
        Debug.Log("Chargement des inputs");

        cylinderPreview = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinderPreview.transform.position = new Vector3(10000, 10000, 10000);
        cylinderPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        Renderer rendererC = cylinderPreview.GetComponent<Renderer>();
        pylonMat = cylinderPreview.GetComponent<Renderer>().material;
        pylonMat.color = Color.blue;
        //Suppression des collider pour eviter de completement casser la scene
        Collider c = cylinderPreview.GetComponent<Collider>();
        c.enabled = false;

        Debug.Log("Cr�ation previsualisation pylone");


        wallPreview = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wallPreview.transform.position = new Vector3(10000, 10000, 10000);
        wallPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        Renderer rendererW = wallPreview.GetComponent<Renderer>();
        wallMat = wallPreview.GetComponent<Renderer>().material;
        wallMat.color = Color.red;
        //Suppression des collider pour eviter de completement casser la scene
        Collider cWall = wallPreview.GetComponent<Collider>();
        cWall.enabled = false;

        Debug.Log("Cr�ation previsualisation murs");


    }

    private void OnDestroy()
    {
        _pylou.performed -= TogglePylone;
    }

    private void Update()
    {
        preview();
    }
    public void preview()
    {
        if (pyloneManager.pyloneBuildActive && !wallManager.wallBuildActive)
        {
            wallPreview.transform.position = new Vector3(10000, 10000, 10000);
            cylinderPreview.transform.position = pointer.hitP;
        }
        if (!pyloneManager.pyloneBuildActive && wallManager.wallBuildActive)
        {
            cylinderPreview.transform.position = new Vector3(10000, 10000, 10000);
            wallPreview.transform.position = pointer.hitP;

        }
    }
    public void TogglePylone(InputAction.CallbackContext context)
    {

        if (pyloneManager.pyloneBuildActive && !wallManager.wallBuildActive && !menuManager.isHovered)
        {
            GameObject newCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            newCylinder.transform.position = pointer.hitP;
            newCylinder.transform.localScale = new Vector3(scaleX, scaleY,scaleZ);
            listObj[index] = newCylinder;
            index++;

            Debug.Log("Tenta creation pylou");

        }
        if (!pyloneManager.pyloneBuildActive && wallManager.wallBuildActive && !menuManager.isHovered)
        {
            GameObject carre = GameObject.CreatePrimitive(PrimitiveType.Cube);
            carre.transform.position = pointer.hitP;
            carre.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            listObj[index] = carre;
            index++;

            Debug.Log("Tenta creation car�");

        }
    }
    public void undo()
    {
        GameObject ob;
        if (index > 0)
        { 
            ob = listObj[index];
            index--;
            ob.transform.position = new Vector3(10000, 10000, 10000);

        }
        
        if (index > 0)
        {
            ob = listObj[index];
            index--;
            ob.transform.position = new Vector3(10000, 10000, 10000);
        }
    }

    public void IncreaseScaleX()
    {
        scaleX = scaleX*increaseScale;
        cylinderPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        wallPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);



    }

    public void reduceScaleX()
    {
        scaleX = scaleX/ decreaseScale;
        cylinderPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        wallPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);


    }
    public void IncreaseScaleY()
    {
        scaleY = scaleY * increaseScale;
        cylinderPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        wallPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);


    }

    public void reduceScaleY()
    {
        scaleY = scaleY/ decreaseScale;
        cylinderPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        wallPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);


    }
    public void IncreaseScaleZ()
    {
        scaleZ = scaleZ * increaseScale;
        cylinderPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        wallPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);


    }

    public void reduceScaleZ()
    {
        scaleZ = scaleZ / decreaseScale;
        cylinderPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        wallPreview.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);


    }

    public void setAllModeOff()
    {
        pyloneManager.pyloneBuildActive = false;
        wallManager.wallBuildActive = false;

    }
}
