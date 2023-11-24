using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    [SerializeField]
    private string searchText;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            scoreText = GameObject.Find(searchText).GetComponent<TextMeshProUGUI>();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = PlayerController.score.ToString();
    }
}
