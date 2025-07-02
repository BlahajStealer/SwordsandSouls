using UnityEngine;

public class Button : MonoBehaviour
{
    public bool PlayerNear;
    [SerializeField] private Animator Animator;
    public bool pressed;
    void Start()
    {
        Animator.SetBool("isEvil", false);
        pressed = false;
    }

    void Update()
    {
        if (PlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Button Pressed");
            Animator.SetBool("isEvil", true);
            pressed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNear = true;
        }
    }    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerNear = false;
        }
    }


}
