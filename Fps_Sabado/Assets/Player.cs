using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float sensibilidadeMouse = 100f;
    public Transform jogador;
    public float rotacaoX = 0f;

    public CharacterController controller;
    public float velocidade = 4.0f;
    public float gravidade = -9.81f;

    Vector3 aceleracao;

    public Arma arma;
    public float timer = 1f;
    public bool atirou = false;

    public Hud hud;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            atirou = true;
            timer = 0.1f;
            arma.Atirar();
            Vector3 origem = transform.position;
            Vector3 direcao = transform.forward;
            Ray ray = new Ray(origem, direcao);
            RaycastHit informacao;
            bool hit = Physics.Raycast(ray, out informacao);

            if (informacao.collider.CompareTag("Inimigo"))
            {
                Inimigo inimigo = informacao.collider.GetComponent<Inimigo>();
                inimigo.Destroy_Respawn();
                hud.GanharPontos();
                //pontosTimer.AumentarPontuacao();
            }

            print(hit);
        }

        if (atirou)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                arma.PararDeAtirar();
                atirou = false;
            }
        }

        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse * Time.deltaTime;

        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
        jogador.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * velocidade * Time.deltaTime);

        aceleracao.y += gravidade * Time.deltaTime;
        controller.Move(aceleracao * Time.deltaTime);
    }
}
