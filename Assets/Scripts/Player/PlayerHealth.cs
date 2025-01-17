﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    //PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    public static bool isDead;
    bool damaged;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        //playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
        isDead = false;
        playerAudio.volume = AudioMenuSFX.SFXs;
    }


    void Update ()
    {
        playerAudio.volume = AudioMenuSFX.SFXs;
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {          
            Death ();            
        }
    }

    public void RecuperarVida(int amount)
    {
        if (currentHealth <= 100)
        {
            currentHealth += amount;
            healthSlider.value = currentHealth;
        }
        
    }

    void Death ()
    {
        isDead = true;
        playerAudio.clip = deathClip;
        playerAudio.Play ();
        playerShooting.DisableEffects();
      
    }


    public void RestartLevel ()
    {   
    SceneManager.LoadScene(2);
    }
}
