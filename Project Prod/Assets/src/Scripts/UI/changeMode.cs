using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMode : MonoBehaviour
{
    public GameObject text;
    private Text editText;
    public bool inFullscreen; //D�cide si en plein �cran ou pas (ne marche pas si on ne clique pas)

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
 - R�glage du son
 - R�glage de la sensibilit� de la souris
 - Changement des inputs
===========================================
*/