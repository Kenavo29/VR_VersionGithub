using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Canvas Build;
    public Canvas CuttingPlane;

    void Start()
    {
        CuttingPlane.enabled = false;
        Build.enabled = false   ;
    }
    public void ButtonBuild()
    {
        CuttingPlane.enabled = false;
        Build.enabled = true;
    }
    public void ButtonCuttingPlane()
    {
        CuttingPlane.enabled = true;
        Build.enabled = false;
    }

}
