using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   
   public GameObject[] Obsticles;

   public float minX,maxX;
   public float minY,maxY;

   public float timeToRespawn;

   private float timeBtwSpawn;
   public float startTimeBtwSpawn;
   public float decreaseTime;
   public float minTime = .65f;

   Player player;


   private void Start()
   {              
       player = FindObjectOfType<Player>();
    //    InvokeRepeating("SpawnAstroids",1,timeToRespawn);
   }


   private void Update()
   {

       if (player != null)
       {
           if (timeBtwSpawn <= 0)
           {
                Vector2 randpos = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
                int randObs = Random.Range(0,Obsticles.Length);
                Instantiate(Obsticles[randObs],randpos,Quaternion.identity);
                timeBtwSpawn = startTimeBtwSpawn;
                if (startTimeBtwSpawn > minTime)
                {
                    startTimeBtwSpawn -= decreaseTime;
                    
                }
           }
           else
           {
               timeBtwSpawn -= Time.deltaTime;
           }
           
       }
   }

   void SpawnAstroids(){

       if (player != null)
       {
            Vector2 randpos = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
            int randObs = Random.Range(0,Obsticles.Length);
            Instantiate(Obsticles[randObs],randpos,Quaternion.identity);
       }
       else
       {
            CancelInvoke("SpawnAstroids");
       }
       
   }


}
