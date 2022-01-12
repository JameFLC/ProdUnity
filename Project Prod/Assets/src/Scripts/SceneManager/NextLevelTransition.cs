using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelTransition : MonoBehaviour
{
    [SerializeField] private CanvasGroup transitionAlpha;
    [SerializeField] private float speed = 10;
    [SerializeField] private SceneManagement sceneManagement;
    [SerializeField] private int nextSceneID = 2;

    private bool levelLoad = false;
    private bool win = false;
    private void Awake()
    {
        transitionAlpha.alpha = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            win = true;
            levelLoad = true;
        }
    }
    private void Update()
    {
        if (levelLoad)
        {
            transitionAlpha.alpha = Mathf.Lerp(transitionAlpha.alpha, 1, Time.deltaTime * speed);
            Debug.Log(transitionAlpha.alpha);
            if (transitionAlpha.alpha >= 0.99f)
            {
                Debug.Log("Next Level");
                if (win)
                {
                    sceneManagement.ChangeSceneToNext();
                }
                else
                {
                    sceneManagement.ChangeSceneById(sceneManagement.GetCurrentSceneID());
                }
                
            }
        }
    }
    public void RelaunchLevel()
    {
        levelLoad = true;
    }
}
