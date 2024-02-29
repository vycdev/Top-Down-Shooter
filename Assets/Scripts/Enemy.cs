using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    //variables

    public float health;
    public float startHealth;

    public Image healthBar;

    private void Start()
    {
        health = startHealth;
    }

    //methods
    public void Update () {
		 
        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            Die();
        }
	}

    public void Die()
    {
        Destroy(this.gameObject);
    }


     
}
