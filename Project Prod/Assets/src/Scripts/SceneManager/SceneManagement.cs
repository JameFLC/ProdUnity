using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    [SerializeField]
    string Victory_name;

    [SerializeField]
    string Fail_name;

    [SerializeField]
    string Game_name;

    [SerializeField]
    string Menu_name;


    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(ChangeSceneVictoryToMenu(5));
        StartCoroutine(ChangeSceneFailToMenu(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeSceneVictoryToMenu(float sec)
    {
        yield return new WaitForSeconds(sec);

        if (SceneManager.GetActiveScene().name == Victory_name)
        {
            SceneManager.LoadScene("Menu");

        }
        else SceneManager.LoadScene("Game");
    }

    IEnumerator ChangeSceneFailToMenu(float sec)
    {
        yield return new WaitForSeconds(sec);

        if (SceneManager.GetActiveScene().name == Fail_name)
        {
            SceneManager.LoadScene("Menu");

        }
        else SceneManager.LoadScene("Game");
    }

    public void ChangeSceneGameToVictory()
    {
        SceneManager.LoadScene(Victory_name);
    }

    public void ChangeSceneGameToFail()
    {
        SceneManager.LoadScene(Fail_name);
    }

    public void ChangeSceneGameToMenu()
    {
        SceneManager.LoadScene(Menu_name);
    }

    public void ChangeSceneMenuToGame()
    {
        SceneManager.LoadScene(Game_name);
    }
}
