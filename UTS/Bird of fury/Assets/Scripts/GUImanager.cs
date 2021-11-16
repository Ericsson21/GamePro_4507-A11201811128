using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUImanager : MonoBehaviour
{
    public void OnPlay()
    {
SceneManager.LoadScene("Level1");

    }

    public void OnHelp()
    {
SceneManager.LoadScene("Help");

    }

    public void OnCredit()
    {
SceneManager.LoadScene("Credit");

    }

    public void OnBack()
    {
SceneManager.LoadScene("Menu");

    }

}
