using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recallBoard : MonoBehaviour
{
    public Transform player;




    public void Board()
    {
        Vector3 shift = new Vector3(0.0f, 0.0f, 2f);
        this.transform.position = player.transform.position + shift;
    }
}
