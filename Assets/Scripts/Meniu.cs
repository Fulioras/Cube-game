using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meniu : MonoBehaviour
{
    public void play() {
        SceneManager.LoadScene(0);
    }
}
