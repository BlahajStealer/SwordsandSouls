using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Animator GateAnimator;
    public GameObject ButtonObj;
    Button sc;

    private void Awake()
    {
        Button sc = ButtonObj.GetComponent<Button>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GateAnimator.SetBool("Open", false);
    }

    // Update is called once per frame
    void Update()
    {

        if (sc.pressed == true)
        {
            GateAnimator.SetBool("Open", true);
        }
    }
}
