using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private string SceneName;
    public void LoadAScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
