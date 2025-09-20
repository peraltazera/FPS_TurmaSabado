using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public GameObject inimigo;
    public Transform respawn;

    public string nome;
    public Transform personagem;

    public Sprite inimigoIdle;
    public Sprite inimigoDead;
    public SpriteRenderer alien;

    public void Destroy_Respawn()
    {
        alien.sprite = inimigoDead;
        gameObject.GetComponent<MeshCollider>().enabled = false;
        Invoke("Respawn", 0.5f);
    }


    public void Respawn()
    {
        gameObject.GetComponent<MeshCollider>().enabled = true;
        Destroy(inimigo);
        inimigo.name = nome;
        Vector3 incremento = new Vector3(Random.Range(-30f, 30f), 3, Random.Range(-30f, 30f));
        respawn.position = incremento;
        gameObject.GetComponent<Inimigo>().enabled = true;
        alien.sprite = inimigoIdle;
        Instantiate(inimigo, respawn.position, inimigo.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(personagem);
        transform.Rotate(Vector3.right, 90);
    }
}
