using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MegaAstroid : MonoBehaviour
{
    public float speed;
    public int health;
    public Slider healthSlider;
    public string sceneName;

    private void Start()
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public void DestroyMegaAstroid(){
        health--;
        healthSlider.value = health;
        if (health <= 0)
        {
            SceneManager.LoadScene(sceneName);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            int DamageAmt = other.GetComponent<Player>().health;
            other.GetComponent<Player>().Damage(DamageAmt);            
        }

        if (other.tag == "EndPoint")
        {
            Player player = FindObjectOfType<Player>().GetComponent<Player>();
            int DamageAmt = player.health;
            player.Damage(DamageAmt); 
        }
    }


}
