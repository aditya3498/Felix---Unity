using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public const float maxHealth = 100.0f;
    public float currentHealth = maxHealth;
    public RectTransform healthbar;
    public Tree_Damage tree_script;
    public GameObject[] trees;
    public GameObject[] trucks;
    public Damage_script truck_damage;

    void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("Destructible_Tree");
        trucks = GameObject.FindGameObjectsWithTag("Enemy_Truck");
        //for (int i = 0; i<10; i++)
        //{
        
        //Debug.Log(trees[3].GetComponent<Tree_Damage>().isDestroyed);
        //}
    }

    void Update()
    {
        //Debug.Log(trees[3].GetComponent<Tree_Damage>().isDestroyed);
        for (int i = 0; i < 10; i++)
        {
            if (trees[i].GetComponent<Tree_Damage>() != null)
            {
                if (trees[i].GetComponent<Tree_Damage>().isDestroyed == true && trees[i].GetComponent<Tree_Damage>().count == 5)
                {
                    currentHealth -= 10.0f;

                }
            }

            else
            {
                //Destroy(trees[i]);
                trees[i] = null;
                //continue;
            }
        }
    

        /*if (trucks[9].GetComponent<Damage_script>().count == 5)
        {
            currentHealth += 2.0f;
        }

        if (trucks[8].GetComponent<Damage_Script2>().count == 5)
        {
            currentHealth += 2.0f;
        }

        if (trucks[7].GetComponent<Damage_Script3>().count == 5)
        {
            currentHealth += 2.0f;
        }

        if (trucks[6].GetComponent<Damage_Script4>().count == 5)
        {
            currentHealth += 2.0f;

        }

        if (trucks[5].GetComponent<Damage_Script5>().count == 5)
        {
            currentHealth += 2.0f;
        }

        if (trucks[4].GetComponent<Damage_Script6>().count == 5)
        {
            currentHealth += 2.0f;
        }

        if (trucks[3].GetComponent<Damage_Script7>().count == 5)
        {
            currentHealth += 2.0f;
        }

        if (trucks[2].GetComponent<Damage_Script8>().count == 5)
        {
            currentHealth += 2.0f;
        }

        if (trucks[1].GetComponent<Damage_Script9>().count == 5)
        {
            currentHealth += 2.0f;
        }

        if (trucks[0].GetComponent<Damage_Script10>().count == 5)
        {
            currentHealth += 2.0f;
        }*/

    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0.0f)
        {
            currentHealth = 0.0f;
            Debug.Log("Dead");
            Application.Quit();
        }

        healthbar.sizeDelta = new Vector2(currentHealth, healthbar.sizeDelta.y);
    }






}
