using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Happiness : MonoBehaviour
{
    // Start is called before the first frame update
    //public float health = 100.0f;
    //public float damage = 5.0f;
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer = 10.0f;
    //public Animator anim;
    public GameObject other;
    public Health health;
    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    void Start()
    {
        health = other.GetComponent<Health>();
        timer = mainTimer;
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(timer >= 0.0f && canCount)
        {
            health.TakeDamage(Time.deltaTime);
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");

        }

        else if(timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            QuitGame();
            //EditorApplication.isPlaying = false;
        }
    }

    public void QuitGame()
    {
        Debug.Log("HI");
        Application.Quit();
    }

}

