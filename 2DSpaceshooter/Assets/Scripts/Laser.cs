﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
   
   public float speed;
   public float lifeTime;
   private ScoreManager scoreManager;

   private void Start()
   {
       scoreManager = FindObjectOfType<ScoreManager>();
       Destroy(gameObject,lifeTime);       
   }

   private void Update()
   {
       transform.Translate(Vector2.up * speed * Time.deltaTime);
   }

   private void OnTriggerEnter2D(Collider2D other) {
       if (other.tag == "Astroid")
       {
           other.GetComponent<Astroids>().destroyAstroid();
           scoreManager.scoreIncreaser();
           Destroy(this.gameObject);
       }
       if (other.tag == "Metorids")
       {
           other.GetComponent<Metorids>().destroyMetorids();
           scoreManager.scoreIncreaser();
           Destroy(this.gameObject);
       }
   }


}