using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]// Makes Sure To Add SpriteRenderer to GameObject If None.
public class Enemy : MonoBehaviour
{
    [SerializeField] private int currentHealth; //Enemies Current Health.
    [SerializeField] private Color damageColor; //The Color You Want The Enemy To Turn.
    [SerializeField] private float secondsDamaged; //Seconds You Want The Enemy To Turn Colors

    private SpriteRenderer enemySpriteRenderer; //Enemies SpriteRenderer Used To Change Sprites Color When Damaged.
    private int maxHealth; //Enemies Max Health.

    //This Function Runs As Soon As The Game Starts and The GameObject is Activated.
    void Awake()
    {
        currentHealth = maxHealth; // Sets Current Health To Be Equal To MaxHealth
        enemySpriteRenderer = GetComponent<SpriteRenderer>(); //Gets the SpriteRenderer Component of the GameObject
    }

    //This Function Is Called To Have Enemy Take Damage.
    public void TakeDamage(int damage)
    {        
        //Starts The Coroutine Function Called "DamageColor"
        StartCoroutine("DamageColor");
        //The Amount of Damage is Subtracted from the Current Health.
        currentHealth -= damage;

        //If the Current Health Equals Zero.
        if (currentHealth <= 0)
        {
            //We Call the Die Function.
            Die();
        }
    }
    
    //This Fuction is called when The Enemy Needs To Die.
    void Die()
    {
        //Makes A Clone To Make Sure To Destroy This GameObject and Not Another One With The Same Name.
        GameObject enemyClone = this.gameObject;
        //Destroys The EnemyClone
        Destroy(enemyClone);
    }

    //Change Enemy Color When Shot
    IEnumerator DamageColor()
    {

        enemySpriteRenderer.color = damageColor;
        yield return new WaitForSeconds(secondsDamaged);
        enemySpriteRenderer.color = new Color(255, 255, 255);
    }
}
