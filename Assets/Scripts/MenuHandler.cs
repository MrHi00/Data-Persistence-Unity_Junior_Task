using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    public TMP_InputField usernameField;

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        //Load best User data 
        DataManager.Instance.LoadBestData();
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
    // ReadStringInput metod was added to TextMesh OnEndEdit() inside Inspector
    public void ReadStringInput() 
    {
        if(usernameField.text != null)
        {
            // Debug.Log(usernameField.text + " not null");
            DataManager.Instance.SetUsername(usernameField.text);
        }
        
    }
    
}
