using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metorids : MonoBehaviour
{
    private Player player;
    private Vector2 targetpos;
    public float speed;
    public int DamageAmount;
    public GameObject deathParticle;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        targetpos = player.transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,targetpos,speed * Time.deltaTime);   

        Vector3 reachpos = new Vector3(targetpos.x,targetpos.y,transform.position.z);
        
        if(transform.position == reachpos)
        {
            destroyMetorids();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "Player")
       {
           other.GetComponent<Player>().Damage(DamageAmount);
           destroyMetorids();
       }
   }

   public void destroyMetorids(){
       Instantiate(deathParticle,transform.position,Quaternion.identity);
       Destroy(this.gameObject);
   }

}
