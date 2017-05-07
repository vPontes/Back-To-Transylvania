using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigosProj1 : MonoBehaviour{
    private bool isEsquerda;
    public float velocidade = 5f;
    public float mxDelay;


    public float instanciadorTempo = 5f;

    public float instanciadorDelay = 3f;

    private float timeMovimento = 0f;

    public Transform verticeInicial;
    public Transform verticeFinal;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movimentar();
        Raycasting();
    }

    void Raycasting()
    {
        Debug.DrawLine(verticeInicial.position, verticeFinal.position, Color.red);
    }

    void Movimentar()
    {//função a ser chamada para o personagem se movimentar na tela horizontalmente
        timeMovimento += Time.deltaTime;
        if (timeMovimento <= mxDelay){
            if (isEsquerda){
                transform.Translate(Vector2.right * velocidade * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 180);
            }
            else{
                transform.Translate(Vector2.right * velocidade * Time.deltaTime);//Através dessa linha com vector negativo, o personagem pode andar no sentido oposto
                transform.eulerAngles = new Vector2(0, 0);//através dessa linha o ersonagem irá virar caso ande no seu sentido contrário
            }
        }else{
            isEsquerda = !isEsquerda;
            timeMovimento = 0;
        }   
    }
}
    