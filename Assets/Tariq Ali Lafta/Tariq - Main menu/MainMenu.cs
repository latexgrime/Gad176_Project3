 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TariqAliLafta
{
    public class MainMenu : MonoBehaviour
    {
    //main menua should be first (0), and develop scene should be next (1).
        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }



    }
}
