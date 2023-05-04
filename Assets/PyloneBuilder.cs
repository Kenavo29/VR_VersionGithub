using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyloneBuilder : MonoBehaviour
{
    public bool pyloneBuildActive = false;
    public void ButtonPylone()
    {
        if (pyloneBuildActive)
        {
            pyloneBuildActive = false;
        }
        else
        {
            pyloneBuildActive = true;
        }
    }
}
