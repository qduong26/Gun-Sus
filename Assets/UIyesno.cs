using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIyesno : MonoBehaviour
{
    // Start is called before the first frame update
    public void thanhyesno()
    {
        GameObject menu = GameObject.Find("Canvas");
        GameObject menupau = menu.transform.Find("yes/no").gameObject;

        menupau.SetActive(true);

    }
    public void yesmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void nomenu()
    {
        GameObject menu = GameObject.Find("Canvas");
        GameObject menupau = menu.transform.Find("yes/no").gameObject;

        menupau.SetActive(false);
    }
}
