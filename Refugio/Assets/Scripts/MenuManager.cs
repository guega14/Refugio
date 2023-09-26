using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject painelMainMenu, painelCredits;
    public AudioSource Jukebox;
    public AudioClip musica, efeito;
    private void Awake()
    {
        painelMainMenu.SetActive(true);
        painelCredits.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Jukebox.Play();
    }

    // Update is called once per frame
    public void GoToCredits()
    {
        Jukebox.PlayOneShot(efeito);
        painelMainMenu.SetActive(false);
        painelCredits.SetActive(true);
    }
    public void GoToMenu()
    {
        Jukebox.PlayOneShot(efeito);
        painelMainMenu.SetActive(true);
        painelCredits.SetActive(false);
    }

    public void Website()
    {
        Application.OpenURL("https://miguelviana.notion.site/Website-Grupo-33d76e09044e483ca5987605fa96dc88?pvs=4");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
