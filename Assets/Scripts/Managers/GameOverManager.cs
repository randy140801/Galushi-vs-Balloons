using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
	public float restartDelay = 5f;
    public static bool level2;
    Animator anim;
	float restartTimer;
    Text txt;
    public GameObject tm;
    public static int scene, nextscene;

    void Awake()
    {
        txt = tm.GetComponent<Text>();
        anim = GetComponent<Animator>();
        scene = SceneManager.GetActiveScene().buildIndex;

        if (level2)
        {
            nextscene = 4;
        }
        else
        {
            nextscene = 3;
        }

        if (scene == 2)
        {
            if (nextscene == 3)
            {
                StartCoroutine(Animat("Nivel 1", 0));
            }
            else
            {
                StartCoroutine(Animat("Nivel 2", 0));
            }
            StartCoroutine(Animat("¿Estas Listo?", 5));
            StartCoroutine(Animat("3", 7));
            StartCoroutine(Animat("2", 9));
            StartCoroutine(Animat("1", 11));
            StartCoroutine(Animat("EMPECEMOS", 13));
            StartCoroutine(ResetAnimat(14, nextscene));
        }
    }


    void Update()
    {
       
        if (playerHealth.currentHealth <= 0)
        {
            txt.text = "Game Over!";
            anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;
            ScoreManager.score = 0;

            if (level2)
            {
                ScoreManager.score = 500;
            }


			if (restartTimer >= restartDelay) {
              int scene = SceneManager.GetActiveScene().buildIndex;
              SceneManager.LoadScene(scene);
            }
          
        }
        

        else if (ScoreManager.score>=500 && !level2)
        {
            txt.text = "NIVEL COMPLETO";
            anim.SetTrigger("GameOver");

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                level2 = true;
                SceneManager.LoadScene(2);
            }
        }
        else if (ScoreManager.score >= 1000 && level2)
        {
            StartCoroutine(Animat("JUEGO TERMINADO", 0));

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                StartCoroutine(ResetAnimat(5, 1));
            }
        }
       //ScoreManager.score = 1500;
       //level2 = true;
    }

    IEnumerator Animat(string texto, int seconds)
    {
        yield return new WaitForSeconds(seconds);

        txt.text = texto;
        anim.SetTrigger("GameOver");

    }

    IEnumerator ResetAnimat(int seconds, int nextscene)
    {

        yield return new WaitForSeconds(seconds);       
        SceneManager.LoadScene(nextscene);

    }








}
