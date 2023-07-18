using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AlternativeEnding : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public Sprite bored, happy, scared, semi_scared, ghost;
    public SpriteRenderer spriteRenderer;

    public AudioSource ghostSound, jumpscare;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];

            }
            // Portraits for lines
            if (index == 4)
            {
                spriteRenderer.sprite = scared;
            } 
            else if (index == 5)
            {
                spriteRenderer.sprite = ghost;
            }      
            else
            {
                spriteRenderer.sprite = semi_scared;
            }

            // Audio files
            if (index == 4)
            {
                ghostSound.Play();             
            }
            if (index == 5)
            {
                jumpscare.Play();
            }
        }
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            SceneManager.LoadScene(8);

        }
    }
}
