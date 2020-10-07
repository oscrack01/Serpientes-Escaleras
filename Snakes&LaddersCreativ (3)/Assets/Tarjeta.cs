using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tarjeta : MonoBehaviour
{
    private Sprite[] tarjeta;
    private SpriteRenderer rende;
    // Start is called before the first frame update
    void Start()
    {
        rende = GetComponent<SpriteRenderer>();
        tarjeta = Resources.LoadAll<Sprite>("Tarjetas/");
        rende.sprite = tarjeta[18];

    }

    // Update is called once per frame
    void Update()
    {
        rende.sprite = tarjeta[GameControl.questionIndex];
        
    }
}
