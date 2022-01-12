using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadBarGame : MonoBehaviour
{
    [SerializeField] private SceneManagement sceneManagement;

    public void ReloadGame()
    {
        sceneManagement.ChangeSceneById(sceneManagement.GetCurrentSceneID());
    }
}
