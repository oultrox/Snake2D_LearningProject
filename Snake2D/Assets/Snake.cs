using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Snake : MonoBehaviour {

    // Vector de dirección que por default será a la derecha.
    Vector2 dir = Vector2.right;
    List<Transform> tails = new List<Transform>();
    bool comio = false;
    public GameObject tailPrefab;
    [SerializeField] private SpawnFood gameManager;
    [SerializeField] private Text scoreText;
    private int score;


    // --------- Métodos API -------------

    // Use this for initialization
    void Start() {
        // Move the Snake every 300ms
        InvokeRepeating("Move", 0.3f, 0.08f);
        score = 0;
        this.scoreText.text = "Score: " + String.Format("{0:D4}", score);
    }

    // Update is called once per frame
    void Update()
    {
        // Controles de dirección
        if (Input.GetKey(KeyCode.RightArrow) && dir != Vector2.left)
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && dir != Vector2.up)
        {
            dir = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && dir != Vector2.right)
        {
            dir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.UpArrow) && dir != Vector2.down)
        {
            dir = Vector2.up;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //buscamos si el objeto que colisiono es comida.
        if (collision.tag == "Food")
        {
            comio = true;

            Destroy(collision.gameObject);
            gameManager.FoodSpawn();
            score += 10;
            this.scoreText.text = "Score: " + String.Format("{0:D4}", score);
        }
        else if (collision.tag == "Walls")
        {

            // You lose! 
            SceneManager.LoadScene(0);
            Debug.Log("Perdiste el mío-san!");
        }
        else if (collision.tag == "Player")
        {

            // You lose! 
            SceneManager.LoadScene(0);
            Debug.Log("¡Perdiste contra ti mismo!");
        }
    }

    // -------- Métodos API --------------

    void Move()
    {
        //Salvamos la posición actual
        Vector2 v = transform.position;

        //Movemos la cabeza a la nueva dirección
        transform.Translate(dir);
        if (comio)
        {
            GameObject g = Instantiate(tailPrefab, v, Quaternion.identity);
            tails.Insert(0, g.transform);
            comio = false;
        }
        //Preguntamos si tenemos cola
        if (tails.Count > 0)
        {
            //Movemos el ultimo elemento de la cola hacia la posición actual de antes de moverse.
            tails.Last().position = v;

            //Añadimos el ultimo a el primer elemento de la lista.
            tails.Insert(0, tails.Last());
            tails.RemoveAt(tails.Count - 1);
        }
    }

}
