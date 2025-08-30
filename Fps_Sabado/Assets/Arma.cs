using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arma : MonoBehaviour
{
    Image arma;
    public Sprite armaParada;
    public Sprite armaAtirando;

    void Start()
    {
        arma = GetComponent<Image>();
    }

    public void Atirar()
    {
        arma.sprite = armaAtirando;
    }

    public void PararDeAtirar()
    {
        arma.sprite = armaParada;
    }

}
