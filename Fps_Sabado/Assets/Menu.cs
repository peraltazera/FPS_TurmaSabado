using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void ComecaJogo()
    {
        SceneManager.LoadScene("FPS");
    }

    public void FechaJogo()
    {
        Application.Quit();
    }
}
