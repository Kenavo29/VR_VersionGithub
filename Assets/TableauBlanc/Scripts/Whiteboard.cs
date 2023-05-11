using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048, 2048); //resolution

    void Start()
    {
        var r = GetComponent<Renderer>(); //gère le rendu graphique du tableau
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y); //nouvelle texture manipulable
        r.material.mainTexture = texture; // "texture" est la texture principale du renderer r
    }
}
