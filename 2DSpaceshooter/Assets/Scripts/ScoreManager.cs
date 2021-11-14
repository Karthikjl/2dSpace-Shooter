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
   public bool level3 = false;


    private void Start()
    {
        if(level3 == true){
            print("Level3");
        }
        else{
            if (scoreTxt != null)
            {
                scoreTxt.text = "Score " + score + " / " + maxScore;               
            }
            player = FindObjectOfType<Player>();
        }
        
    }

    
   public void scoreIncreaser(){
       if(level3 == true)
       {
           print("Level3");
       }
       else
       {
            if (player != null)
            {
                score++;       
                scoreTxt.text = "Score " + score + " / " + maxScore;  
                if (score >= maxScore)
                {
                    SceneManager.LoadScene(sceneName);   
                }                     
            }
            else{
                print("player died.");
            }
       }
   }


}
