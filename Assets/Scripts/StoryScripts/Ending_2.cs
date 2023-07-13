using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ending_2 : MonoBehaviour
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
            if (index == 3 || index == 5 || index == 9)
            {
                spriteRenderer.sprite = bored;
            }
            else if (index == 4 || index == 6 || index == 7)
            {
                spriteRenderer.sprite = semi_scared;
            }
            else
            {
                spriteRenderer.sprite = happy;
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
            SceneManager.LoadScene(0);

        }
    }
}
