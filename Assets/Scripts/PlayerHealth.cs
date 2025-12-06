using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public TMP_Text healthText;
    public Animator anim;

    private void Start()
    {
        healthText.text = "Health: " + currentHealth + "/" + maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        anim.Play("Hurt");
        healthText.text = "Health: " + currentHealth + "/" + maxHealth;
        if (currentHealth <= 0)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            anim.Play("Dead");
            gameObject.tag = "Untagged";
            GetComponent<Collider2D>().enabled = false;
        }
    }
}