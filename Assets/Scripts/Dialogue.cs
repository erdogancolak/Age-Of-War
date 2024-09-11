using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] lines;
    public float typingSpeed;
    public GameObject portal; // Portal objesi referansý
    public GameObject enemyPrefabObject;
    public Transform player; // Karakterin referansý
    public Transform portalPosition; // Portalýn pozisyonu
    public float moveSpeed = 2f; // Karakterin hareket hýzý
    private Animator animator;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
        textDisplay.text = string.Empty;
        StartDialogue();
        portal.SetActive(false); // Portal baþlangýçta gizli
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
            portal.SetActive(true); // Portalý aktif hale getir
            StartCoroutine(MoveToPortal()); // Karakteri portala yönlendir
        }
    }

    IEnumerator MoveToPortal()
    {
        animator.SetBool("isRun", true); // Karakterin koþma animasyonunu baþlat
        player.DOMove(portalPosition.position, moveSpeed); // Karakteri portala doðru hareket ettir
        yield return new WaitForSeconds(moveSpeed); // Hareket süresi kadar bekle
        BattleSystem.enemyPrefab = enemyPrefabObject;
        SceneManager.LoadScene(2); // Bir sonraki sahneye geç
    }
}
