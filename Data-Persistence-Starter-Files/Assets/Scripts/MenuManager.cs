using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject GreetingText;

    private string userInput;

    private void Start()
    {
        SetGreetingText();
    }
    public void ReadStringInput(string input)
    {
        userInput = input;
        SceneDataManager.instance.userName = userInput;
        Debug.Log(userInput);
        SetGreetingText();
    }

    private void SetGreetingText()
    {
        if(SceneDataManager.instance.userName == "" || userInput == "")
        {
            GreetingText.SetActive(false);
        }
        else
        {
            TextMeshProUGUI text = GreetingText.GetComponent<TextMeshProUGUI>();
            text.text = "Hello " + SceneDataManager.instance.userName;
            GreetingText.SetActive(true);
        }
    }
    public void StartGame()
    {
        if (SceneDataManager.instance.userName == "")
        {
            TextMeshProUGUI text = GreetingText.GetComponent<TextMeshProUGUI>();
            text.text = "Please Enter a Name";
            GreetingText.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
