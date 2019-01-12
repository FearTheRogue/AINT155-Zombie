using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    public static SceneFader instance;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAnim;

	void Awake () {
        MakeSingleton();
	}
	
	void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);
        fadeAnim.Play("FadeInScene");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(level);

        fadeAnim.Play("FadeOutScene");

        yield return new WaitForSeconds(0.7f);

        fadePanel.SetActive(false);
    }

}
