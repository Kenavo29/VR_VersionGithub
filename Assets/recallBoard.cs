using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recallBoard : MonoBehaviour
{
    public Transform player;




    public void Board()
    {
        Vector3 shift = new Vector3(0.0f, -1.5f, 0.0f);
        this.transform.position = player.transform.position + shift;
    }
}
