using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreUI;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
    }

    private void OnGUI()
    {
        scoreUI.text = gm.PrettyScore();
    }
}
