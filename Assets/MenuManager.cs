using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public bool isHovered;
    public Canvas Build;
    public Canvas CuttingPlane;
    public InputSystemOfTheBled inp;
    public Transform player;
    private bool testingZone = false;

    



    void Start()
    {
        CuttingPlane.enabled = false;
        Build.enabled = false;
    }
    public void ButtonBuild()
    {
        CuttingPlane.enabled = false;
        Build.enabled = true;
        inp.setAllModeOff();

    }
    public void ButtonCuttingPlane()
    {
        CuttingPlane.enabled = true;
        Build.enabled = false;
        inp.setAllModeOff();

    }
    void OnMouseEnter()
    {
        isHovered = true;
        Debug.Log("Entrée souris");

    }

    void OnMouseExit()
    {
        isHovered = false;
        Debug.Log("Sortie souris");
    }

    public void ButtonTest()
    {
        if (!testingZone)
        {
            player.transform.position = new Vector3(10, 20, 500);
            testingZone = true;
        }
        else
        {
            player.transform.position = new Vector3(0, 1, 0);
            testingZone = false;
        }
    }

}
