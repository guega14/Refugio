using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject painelMenu, painelCreditos;
    public AudioSource Jukebox;
    public AudioClip musica, efeito;
    private void Awake()
    {
        painelMenu.SetActive(true);
        painelCreditos.SetActive(false);
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
        painelMenu.SetActive(false);
        painelCreditos.SetActive(true);
    }
    public void GoToMenu()
    {
        Jukebox.PlayOneShot(efeito);
        painelMenu.SetActive(true);
        painelCreditos.SetActive(false);
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
