using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector2 movement = new Vector2();
    Rigidbody2D rb2d;
    public float SpeedUp;
    public float SpeedLeft;
    public float SpeedDown;
    public float SpeedRight;
    [SerializeField] Sprite BackSprite;
    [SerializeField] Sprite FrontSprite;
    [SerializeField] Sprite RightSprite;
    [SerializeField] Sprite LeftSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = FrontSprite;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * SpeedUp);
            Debug.Log("Forward!");
            gameObject.GetComponent<SpriteRenderer>().sprite = BackSprite;
        }        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * SpeedRight);
            Debug.Log("Right!");
            gameObject.GetComponent<SpriteRenderer>().sprite = RightSprite;

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.up * Time.deltaTime * -SpeedDown);
            Debug.Log("Down!");
            gameObject.GetComponent<SpriteRenderer>().sprite = FrontSprite;

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * SpeedLeft);
            Debug.Log("Left!");
            gameObject.GetComponent<SpriteRenderer>().sprite = LeftSprite;

        }
    }
}
