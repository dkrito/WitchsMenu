using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Startbutton : MonoBehaviour
{
    private AudioSource startSequence;
    private Button startButton;
    public AudioClip runSound;
    public AudioClip screamSound;
    public AudioClip doorSound;
    public Text message;

    // Start is called before the first frame update
    void Start()
    {
        startSequence = GetComponent<AudioSource>();
        startButton = GameObject.Find("Start button").GetComponent<Button>();
        message = GameObject.Find("Message").GetComponent<Text>();
        startButton.onClick.AddListener(StartGame);
    }

    IEnumerator PlaySequence()
    {   
        startSequence.PlayOneShot(runSound, 1f);
        yield return new WaitForSeconds(runSound.length);
        startSequence.PlayOneShot(screamSound, 1f);
        yield return new WaitForSeconds(screamSound.length);
        startSequence.PlayOneShot(doorSound, 1f);
        yield return new WaitForSeconds(doorSound.length);
        message.GetComponent<Text>().enabled = true;
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Witch kitchen", LoadSceneMode.Single);

    }
    private void StartGame()
    {
        StartCoroutine(PlaySequence());
        startButton.gameObject.SetActive(false);
    }
}
