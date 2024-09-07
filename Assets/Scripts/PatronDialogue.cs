using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PatronDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] lines;
    public float typingSpeed;
    public GameObject globe; // Globe objesi referansý
    public Transform player; // Karakterin referansý
    public float moveSpeed = 2f; // Globe objesinin hareket hýzý

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textDisplay.text = string.Empty;
        StartDialogue();
        globe.SetActive(false); // Globe baþlangýçta gizli
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textDisplay.text == lines[index])
            {
                NextLines();
            }
            else
            {
                StopAllCoroutines();
                textDisplay.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void NextLines()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textDisplay.text = string.Empty;
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = string.Empty;
            globe.SetActive(true); // Globe objesini aktif hale getir
            StartCoroutine(MoveGlobeToPlayer()); // Globe objesini player'a yönlendir
        }
    }

    IEnumerator MoveGlobeToPlayer()
    {
        globe.transform.DOMove(player.position, moveSpeed); // Globe objesini player'a doðru hareket ettir
        yield return new WaitForSeconds(moveSpeed); // Hareket süresi kadar bekle
        SceneManager.LoadScene(1); // Bir sonraki sahneye geç
    }
}
