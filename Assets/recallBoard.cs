using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recallBoard : MonoBehaviour
{
    public Transform player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Board()
    {
        Vector3 shift = new Vector3(0.0f, 2f, 0.0f);
        this.transform.position = player.transform.position + shift;
    }
}
