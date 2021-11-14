using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAstroid : MonoBehaviour
{
    public int health;
    public float speed;
    public float lifetime;
    public int DamageAmount;
    public GameObject deathFx;

    private void Start()
    {
        Destroy(this.gameObject,lifetime);
    }


    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "Player")
       {
           other.GetComponent<Player>().Damage(DamageAmount);
           Destroy(this.gameObject);
       }
   }

    public void destroyBigAstroid(){
        health--;
        if (health <= 0)
        {
            Instantiate(deathFx,transform.position,Quaternion.identity);
            Destroy(this.gameObject);            
        }
    }


}
