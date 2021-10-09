using UnityEngine;
using UnityEngine.UI;
 
public class Player : MonoBehaviour {

    Rigidbody2D rb;
    float moveInput;
    public float speed;

    public float minX,maxX;

    public int health = 10;
    public int numOfHearts;
    public Image[] Hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    // public Text healthTxt;
    GameManager gm;

    public GameObject playerdeathfx;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        

        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(maxX,transform.position.y);
        }
        else if (transform.position.x < minX)
        {
            transform.position = new Vector2(minX,transform.position.y);
        }
        
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
       
    }

    private void FixedUpdate()
    {
        
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed,transform.position.y);

    }
    

    public void Damage(int DamageAmt){
        health -= DamageAmt;

        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < health)
            {
                Hearts[i].sprite = fullHeart;
            }
            else
            {
                Hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                Hearts[i].enabled = true;                
            }
            else{
                Hearts[i].enabled = false;
            }
            
        }

        if (health <= 0)
        {
            Instantiate(playerdeathfx,transform.position,Quaternion.identity);
            gm.RestartPannel.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
