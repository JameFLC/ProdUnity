
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimonManager : MonoBehaviour
{
    private List<int> playerTaskList = new List<int>();
    private List<int> playerSequanceList = new List<int>();

    [SerializeField] private SceneManagement sceneManagement;
    public List<AudioClip> buttonSoundsList = new List<AudioClip>();
    public List<List<Color32>> buttonColors = new List<List<Color32>>();
    public List<Button> clickableButtons;
    public AudioClip loseSound;
    public AudioSource audioSource;
    public CanvasGroup buttons;
    public GameObject startButton;
    public int numberOffRounds = 6;


    public void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        buttons.alpha = 0;
        buttonColors.Add(new List<Color32> { new Color32(255, 100, 100, 255), new Color32(255, 0, 0, 255) });
        buttonColors.Add(new List<Color32> { new Color32(255, 187, 109, 255), new Color32(255, 136, 0, 255) });
        buttonColors.Add(new List<Color32> { new Color32(162, 255, 124, 255), new Color32(72, 248, 0, 255) });
        buttonColors.Add(new List<Color32> { new Color32(57, 111, 255, 255), new Color32(0, 70, 255, 255) });

        for (int i = 0; i < 4; i++)
        {
            clickableButtons[i].GetComponent<Image>().color = buttonColors[i][0];
        }

    }

    public void AddToPlayerSequenceList(int buttonId)
    {
        playerSequanceList.Add(buttonId);
        StartCoroutine(HighlighButton(buttonId));
        for (int i = 0; i < playerSequanceList.Count; i++)
        {
            if (i + 1 >= numberOffRounds)
            {
                Win();
            }
            if (playerTaskList[i] == playerSequanceList[i])
            {
                continue;
            }
            else
            {
                StartCoroutine(PlayerLost());
                return;
            }
        }
        if (playerSequanceList.Count == playerTaskList.Count)
        {
            StartCoroutine(StartNextRound());
        }
    }

    public void StartGame()
    {
        buttons.alpha = 1;
        startButton.SetActive(false);
        StartCoroutine(StartNextRound());

    }

    public IEnumerator HighlighButton(int buttonid)
    {
        clickableButtons[buttonid].GetComponent<Image>().color = buttonColors[buttonid][1];
        //audioSource.PlayOneShot(buttonSoundsList[buttonid]);
        yield return new WaitForSeconds(0.5f);
        clickableButtons[buttonid].GetComponent<Image>().color = buttonColors[buttonid][0];
    }
    public IEnumerator PlayerLost()
    {
        audioSource.PlayOneShot(loseSound);
        yield return new WaitForSeconds(1f);
        sceneManagement.ChangeSceneById(sceneManagement.GetCurrentSceneID());
    }

    public IEnumerator StartNextRound()
    {
        playerSequanceList.Clear();
        buttons.interactable = false;
        yield return new WaitForSeconds(1f);
        playerTaskList.Add(Random.Range(0, 4));
        foreach (int index in playerTaskList)
        {
            Debug.Log(index);
            yield return StartCoroutine(HighlighButton(index));
        }
        
        buttons.interactable = true;
        yield return null;
    }
    public void Win()
    {
        Debug.Log("Won");
        sceneManagement.ChangeSceneToNext();
    }
}
