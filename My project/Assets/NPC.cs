using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.Android;
public class NPC : MonoBehaviour
{
    
    public GameObject dialoguePanel;
    public TextMeshProUGUI Dia;
    public string[] dialogue;
    private int index;
    public GameObject MC;
    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;
    public string[] backupdialogue;
    Coroutine typingCoroutine;
    void Start()
    {

        backupdialogue = dialogue;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            } else
            {
                dialoguePanel.SetActive(true);
                Dia.text = "";
                index = 0;

                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                }

                typingCoroutine = StartCoroutine(Typing());
            }
        }
        if (Dia.text == dialogue[index])
        {
            contButton.SetActive(true);
        } 
    }


    public void zeroText()
    {
        Dia.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            Dia.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        Movement s2 = MC.GetComponent<Movement>();

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        if (s2.activeSword && gameObject.tag == "NPC")
        {
            dialogue = new string[] { "AHH, Put that sword away" };
            index = 0;
            Dia.text = "";
            typingCoroutine = StartCoroutine(Typing());
        }
        else
        {
            dialogue = backupdialogue;
            contButton.SetActive(false);

            if (index < dialogue.Length - 1)
            {
                index++;
                Dia.text = "";
                StartCoroutine(Typing());
            }
            else
            {
                zeroText();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            Debug.Log("Player is close");
        }
    }    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
            Debug.Log("Player isn't close");

        }
    }
}
