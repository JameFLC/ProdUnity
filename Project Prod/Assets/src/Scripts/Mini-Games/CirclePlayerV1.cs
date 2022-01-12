using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CirclePlayerV1 : MonoBehaviour
{
    public GameObject areaBar;
    private float xArea;
    private RectTransform rtArea;
    private MovingArea scriptArea;
    private float widthArea, heightArea;
    private float bdArea, bgArea;

    public GameObject player;
    private float xPlayer;
    private RectTransform rtPlayer;
    private float widthPlayer, heightPLayer;
    private float bdPlayer, bgPlayer;

    public GameObject text;
    private Text editText;
    public GameObject suivant;

    void Start()
    {
        scriptArea = areaBar.GetComponent<MovingArea>();

        // R�cup�re les donn�es de la zone fixe
        rtPlayer = this.GetComponent<RectTransform>();
        xPlayer = rtPlayer.position.x;
        widthPlayer = rtPlayer.sizeDelta.x * rtPlayer.localScale.x;
        //R�cup�re le bord droit et gauche
        bdPlayer = xPlayer + widthPlayer / 2;
        bgPlayer = xPlayer - widthPlayer / 2;

        editText = text.GetComponent<Text>();
    }

    void Update()
    {
        //Si appuie sur le shift droit, stop la zone mouvante et v�rifie si on a gagn�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Arr�ter la zone mouvante
            scriptArea.enabled = false;

            //R�cup�re les donn�es de la zone mouvante
            rtArea = areaBar.GetComponent<RectTransform>();
            xArea = rtArea.position.x;
            widthArea = rtArea.sizeDelta.x * rtArea.localScale.x;
            //R�cup�re le bord droit et gauche
            bdArea = xArea + widthArea / 2;
            bgArea = xArea - widthArea / 2;

            if ( (bdArea > bgPlayer && bdArea < bdPlayer)    ||  ( bgArea > bgPlayer && bgArea < bdPlayer))
            {
                win();
            }
            else
            {
                loose();
            }
        }
        if (Input.GetKeyDown(KeyCode.M) && Input.GetKeyDown(KeyCode.W))
        {
            win();
        }
    }

    void win()
    {
        //Affiche un texte qui indique que l'on a gagn�
        editText.text = "Vous avez gagn� !";
        editText.fontSize = 20;
        //Rend possible de passer � l'�tape suivante (bouton "suivant")
        suivant.SetActive(true);
    }
    void loose()
    {
        //Affiche un texte qui indique que l'on a perdu
        editText.text = "Vous avez perdu, recommencez";
        editText.fontSize = 20;
    }
}
