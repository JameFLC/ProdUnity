using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMode : MonoBehaviour
{
    public GameObject text;
    private Text editText;
    public bool inFullscreen; //Décide si en plein écran ou pas (ne marche pas si on ne clique pas)

    void Start()
    {
        editText = text.GetComponent<Text>();
    }

    public void fullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;

        
        
    }
}
/*=========================================
 Composition du menu option
 - Fullscreen
 - Réglage du son
 - Réglage de la sensibilité de la souris
 - Changement des inputs
===========================================
*/