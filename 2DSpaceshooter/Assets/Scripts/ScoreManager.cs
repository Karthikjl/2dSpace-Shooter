using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
   public int score;
   public Text scoreTxt;
   private Player player;

   private void Start()
   {
       player = FindObjectOfType<Player>();
   }

   public void scoreIncreaser(){

       if (player != null)
       {
            score++;       
            scoreTxt.text = score.ToString();    
       }
       else{
           print("player died.");
       }
   }


}
