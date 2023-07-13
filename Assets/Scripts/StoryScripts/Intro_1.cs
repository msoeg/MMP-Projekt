using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Intro_1 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public Sprite bored, happy, scared, semi_scared;
    public SpriteRenderer spriteRenderer;

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        //SceneManager.LoadScene("Intro_2");
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
            // What portrait is being shown
            if (index <= 3)
            {
                spriteRenderer.sprite = happy;
            }
            else if (index == 7)
            {
                spriteRenderer.sprite = scared;
            }
            else if (index == 8 || index == 11)
            {
                spriteRenderer.sprite = semi_scared;
            }
            else
            {
                spriteRenderer.sprite = bored;
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
        if (index < lines.Length-1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            SceneManager.LoadScene(2);

        }
    }
}