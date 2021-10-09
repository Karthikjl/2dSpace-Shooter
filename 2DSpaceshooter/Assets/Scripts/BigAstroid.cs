using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAstroid : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int DamageAmount;

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
           destroyBigAstroid();
       }
   }

    public void destroyBigAstroid(){
        Destroy(this.gameObject);
    }


}
