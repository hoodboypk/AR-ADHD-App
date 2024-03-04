using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShapeReloader : MonoBehaviour
{
    public void SceneReloader()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
