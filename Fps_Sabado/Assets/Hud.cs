using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    public TMP_Text pontuacao;
    public int pontos;
    public TMP_Text timer;
    public float tempo = 30.0f;

    public void GanharPontos()
    {
        pontos++;
    }

    void Update()
    {
        pontuacao.text = pontos.ToString();

        tempo -= Time.deltaTime;
        timer.text = Mathf.RoundToInt(tempo).ToString();

        if (tempo <= 0.0f)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
