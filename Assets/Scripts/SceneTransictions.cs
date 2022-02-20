using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransictions : MonoBehaviour
{
    private int nextScene;

    [SerializeField]
    Animator transitionAnim;

    [SerializeField]
    GameObject soundEffect;

    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadScene());
        Instantiate(soundEffect, transform.position, Quaternion.identity);
        Destroy(other.gameObject);
    }

    private IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(nextScene);
    }
}
