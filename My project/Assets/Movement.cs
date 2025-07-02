using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 movement = new Vector2();
    Rigidbody2D rb2d;
    public GameObject SwordUp;
    public GameObject SwordDown;
    public GameObject SwordLeft;
    public GameObject SwordRight;
    public float SpeedUp;
    public float SpeedLeft;
    public float SpeedDown;
    public float SpeedRight;
    bool up;
    bool down;
    bool left;
    bool right;
    public bool activeSword;
    public int Health;
    [SerializeField] Sprite BackSprite;
    [SerializeField] Sprite FrontSprite;
    [SerializeField] Sprite RightSprite;
    [SerializeField] Sprite LeftSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = FrontSprite;
        rb2d = GetComponent<Rigidbody2D>();
        SwordLeft.SetActive(false);
        SwordRight.SetActive(false);
        SwordDown.SetActive(false);
        SwordUp.SetActive(false);
        left = false;
        down = false;
        up = false;
        right = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SwordFunc();
        spriterender();
    }


    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * SpeedUp);
            Debug.Log("Forward!");


        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * SpeedRight);
            Debug.Log("Right!");

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.up * Time.deltaTime * -SpeedDown);
            Debug.Log("Down!");




        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * SpeedLeft);
            Debug.Log("Left!");
            

        }
    }

    private void spriterender()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = LeftSprite;
            left = true;
            down = false;
            up = false;
            right = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = FrontSprite;
            left = false;
            down = true;
            up = false;
            right = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = RightSprite;
            left = false;
            down = false;
            up = false;
            right = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = BackSprite;
            left = false;
            down = false;
            up = true;
            right = false;
        }
    }

    private void SwordFunc()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (activeSword == false)
            {
                activeSword = true;
                if (left)
                {
                    SwordLeft.SetActive(true);
                    SwordRight.SetActive(false);
                    SwordDown.SetActive(false);
                    SwordUp.SetActive(false);
                }
                else if (right)
                {
                    SwordLeft.SetActive(false);
                    SwordRight.SetActive(true);
                    SwordDown.SetActive(false);
                    SwordUp.SetActive(false);

                }
                else if (up)
                {
                    SwordLeft.SetActive(false);
                    SwordRight.SetActive(false);
                    SwordDown.SetActive(false);
                    SwordUp.SetActive(true);
                }
                else if (down)
                {
                    SwordLeft.SetActive(false);
                    SwordRight.SetActive(false);
                    SwordDown.SetActive(true);
                    SwordUp.SetActive(false);
                }
                else
                {
                    SwordLeft.SetActive(false);
                    SwordRight.SetActive(false);
                    SwordDown.SetActive(true);
                    SwordUp.SetActive(false);
                }
            }            
            else if (activeSword == true)
            {
                activeSword = false;
                SwordLeft.SetActive(false);
                SwordRight.SetActive(false);
                SwordDown.SetActive(false);
                SwordUp.SetActive(false);
            }

        }
        if (activeSword)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                //Sword.transform.position = new Vector3(-.897f, -.451f, -6.1f);
                //Sword.transform.Rotate(0, 0, 90);
                SwordLeft.SetActive(true);
                SwordRight.SetActive(false);
                SwordDown.SetActive(false);
                SwordUp.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                //Sword.transform.position = new Vector3(.608f, -1.17f, -6.1f);
                //Sword.transform.Rotate(0, 0, 180);
                SwordLeft.SetActive(false);
                SwordRight.SetActive(false);
                SwordDown.SetActive(true);
                SwordUp.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                //Sword.transform.position = new Vector3(.85f, -.427f, -6.1f);
                //Sword.transform.Rotate(0, 0, 270);
                SwordLeft.SetActive(false);
                SwordRight.SetActive(true);
                SwordDown.SetActive(false);
                SwordUp.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                //Sword.transform.position = new Vector3(.605f, .326f, 0);
                //Sword.transform.Rotate(0, 0, 0);
                SwordLeft.SetActive(false);
                SwordRight.SetActive(false);
                SwordDown.SetActive(false);
                SwordUp.SetActive(true);
            }
        }
    }
}
