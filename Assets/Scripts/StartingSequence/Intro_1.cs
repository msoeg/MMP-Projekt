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

    public Sprite bored, happy; 

    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        SceneManager.LoadScene("Intro_2");
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

            if (textComponent.text == lines[0] || textComponent.text == lines[1] || textComponent.text == lines[2] || textComponent.text == lines[3])
            {
                GetComponent<SpriteRenderer>().sprite = happy;
            }
            if (textComponent.text == lines[4] || textComponent.text == lines[5] || textComponent.text == lines[6])
            {
                GetComponent<SpriteRenderer>().sprite = bored;
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
            SceneManager.LoadScene("Intro_2");

        }
    }
}