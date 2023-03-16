using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    
    public float speed;
    public float lifeTime;
    private ScoreManager scoreManager;
    public GameObject[] astroids;                                                                                                                                                                                                                                                                                                                                                                                                                                 
    
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
        if (other.tag == "BigAstroid")
        {
            other.GetComponent<BigAstroid>().destroyBigAstroid();
            scoreManager.scoreIncreaser();
            Destroy(this.gameObject);
        }
        if (other.tag == "MegaAstroid")
        {
            other.GetComponent<MegaAstroid>().DestroyMegaAstroid();           
            int randAstroid = Random.Range(0,astroids.Length);
            Instantiate(astroids[randAstroid],transform.position + new Vector3(0,other.transform.position.y,0),Quaternion.identity);
            Destroy(this.gameObject);
        }
    }


}
