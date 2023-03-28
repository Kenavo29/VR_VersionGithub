using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenshot : MonoBehaviour
{
    public int width = 1920;
    public int height = 1080;
    public string filename = "screenshot.png";

    private Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            // Créer une texture de rendu pour stocker l'image capturée
            RenderTexture renderTexture = new RenderTexture(width, height, 24);

            // Récupérer la texture active de la caméra
            RenderTexture currentRT = RenderTexture.active;

            // Assigner la texture de rendu comme texture active de la caméra
            camera.targetTexture = renderTexture;
            RenderTexture.active = renderTexture;

            // Forcer le rendu de la caméra sur la texture de rendu
            camera.Render();

            // Créer une texture 2D à partir de la texture de rendu
            Texture2D screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);
            screenshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            screenshot.Apply();

            // Enregistrer la texture 2D en tant que fichier PNG
            byte[] bytes = screenshot.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/" + filename, bytes);

            // Réinitialiser la texture active de la caméra et la texture de rendu
            camera.targetTexture = null;
            RenderTexture.active = currentRT;
        }
    }
}
