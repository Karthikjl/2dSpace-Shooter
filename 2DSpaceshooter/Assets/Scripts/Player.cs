using UnityEngine;
using UnityEngine.UI;
 
public class Player : MonoBehaviour {

    Rigidbody2D rb;
    public Vector2 moveAmount;
    public float speed;

    public float minX,maxX;
    public float minY,maxY;

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
        // transform.position = new Vector2(0f,-7f);
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {

        
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        moveAmount = moveInput.normalized * speed;

        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(minX,transform.position.y);
        }
        else if (transform.position.x < minX)
        {
            transform.position = new Vector2(maxX,transform.position.y);
        }

        if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x,maxY);
        }
        else if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x,minY);
        }
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

       
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void Damage(int DamageAmt){
        health -= DamageAmt;
        // healthTxt.text = "Health : " + health;
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
