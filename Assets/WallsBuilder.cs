using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsBuilder : MonoBehaviour
{
    public bool wallBuildActive = false;
    public void ButtonWall()
    {
        if (wallBuildActive)
        {
            wallBuildActive = false;
        }
        else
        {
            wallBuildActive = true;

        }
    }

    public void ButtonDisableWall()
    {
        wallBuildActive = false;

    }
}
