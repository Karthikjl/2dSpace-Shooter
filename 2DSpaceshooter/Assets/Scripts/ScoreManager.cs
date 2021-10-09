using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
   public int score;
   public int maxScore;
   public Text scoreTxt;
   private Player player;
   public string sceneName;

   public bool level2 = false;

   private void Start()
   {
       if (level2 == false)
       {
            scoreTxt.text = "Score " + score + " / " + maxScore;           
       }
       player = FindObjectOfType<Player>();
   }

    
   public void scoreIncreaser(){

       if (player != null)
       {
           if (level2 == false)
           {
                score++;       
                scoreTxt.text = "Score " + score + " / " + maxScore;  
                if (score >= maxScore)
                {
                    SceneManager.LoadScene(sceneName);                    
                }   
           }       
       }
       else{
           print("player died.");
       }
   }


}
