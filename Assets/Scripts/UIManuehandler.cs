using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;
using UnityEngine.UI;

public class UIManuehandler : MonoBehaviour
{
    public TextMeshProUGUI highScoretxt;
    public InputField nameInput;

    private void Awake()
    {
        Manager.Instance.LoadData();
        highScoretxt.text = Manager.Instance.SetHighScore();
    }

    public void StartNew()
    {
        Manager.Instance.currentPlayer = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();

#else
       
        Application.Quit(); // original code to quit Unity player 
     
#endif

    }
}
