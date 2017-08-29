using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AutoCollide : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //buscamos si el objeto que colisiono es comida.
        if (collision.tag == "Player")
        { 
            // You lose! 
            //SceneManager.LoadScene(0);
            Debug.Log("Perdiste contra ti mismo!");
        }
    }
}
