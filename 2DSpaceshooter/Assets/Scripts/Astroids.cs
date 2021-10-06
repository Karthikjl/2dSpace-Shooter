using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroids : MonoBehaviour
{
   public float speed;
   public int DamageAmount;
   public int lifeTime;
   public GameObject deathParticle;
   

   private void Start()
   {
       Destroy(this.gameObject,lifeTime);
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
           destroyAstroid();
       }
   }

   public void destroyAstroid(){
       Instantiate(deathParticle,transform.position,Quaternion.identity);
       Destroy(this.gameObject);
   }


}
