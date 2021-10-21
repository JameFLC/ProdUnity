using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickButton : MonoBehaviour
{
    public Button btn;
    public string theScene;
    
    void Start()
    {
        theScene = SceneManager.GetActiveScene().name;
        btn.onClick.AddListener(ReloadLevel);
    }
    void Update()
    {
        
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(theScene);
    }
}
