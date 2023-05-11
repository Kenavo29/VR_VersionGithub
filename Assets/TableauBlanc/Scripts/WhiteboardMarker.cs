using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class WhiteboardMarker : MonoBehaviour
{
    //Variables
    [SerializeField] private Transform _tip;
    [SerializeField] private int _penSize=5; //taille de la mine du stylo

    private Renderer _renderer;
    private Color[] _colors;
    private float _tipHeight;

    private RaycastHit _touch;
    private Whiteboard _whiteboard;
    private Vector2 _touchPos, _lastTouchPos;
    private bool _touchedLastFrame;
    private Quaternion _lastTouchRot;

    //Initialisation
    void Start()
    {
        _renderer = _tip.GetComponent<Renderer>();
        //Coloriage d'un carré de côté la taille du stylo : 5*5 pixels ici
        //Coloriage de la couleur du renderer
        _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
        _tipHeight = _tip.localScale.y;
    }

    void Update()
    {
        Draw();
    }

   
       // Méthode qui dessine sur le tableau blanc s'il y a contact avec la mine du stylo
    Draw()
    {
        //La mine est-elle en contact avec quelquechose ?
        if (Physics.Raycast(_tip.position, transform.up, out _touch, _tipHeight))
        {
            //Cet objet est-il un tableau blanc ?
            if (_touch.transform.CompareTag("TableauBlanc"))
            {
                if (_whiteboard == null)
                {
                    _whiteboard = _touch.transform.GetComponent<Whiteboard>();
                }

                //Position de contact
                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                //Abscisse et ordonnée de la zone du tableau touchée
                var x = (int)(_touchPos.x * _whiteboard.textureSize.x - (_penSize / 2));
                var y = (int)(_touchPos.y * _whiteboard.textureSize.y - (_penSize / 2));

                //Si la position du stylo est en dehors du tableau, le stylo n'écrit plus
                if (y < 0 || y > _whiteboard.textureSize.y || x < 0 || x > _whiteboard.textureSize.y) return;
                
                //Ecriture
                //Vérifie si le stylo a touché quelque chose au frame précédent
                if (_touchedLastFrame)
                {
                    //Coloration des pixels du tableau touchés
                    _whiteboard.texture.SetPixels(x, y, _penSize, _penSize, _colors);

                    // Augmentation de 3% à chaque itération pour tracer une ligne continue sans ralentir l'application
                    for (float f =0.01f; f < 1.00f; f += 0.03f)
                    {
                        var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _whiteboard.texture.SetPixels(lerpX, lerpY, _penSize, _penSize, _colors);
                    }

                    //Affectation de la dernière rotation à la rotation actuelle
                    transform.rotation = _lastTouchRot;

                    _whiteboard.texture.Apply();
                }

                //Stocke les positions et rotations actuelles dans les variables temporaires pour être utilisées dans le prochain frame
                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;

            }
        }
        //Si le stylo ne touche pas un tableau, _whiteboard et _touchedLastFrame sont désactivés
        _whiteboard = null;
        _touchedLastFrame = false;
    }
}
