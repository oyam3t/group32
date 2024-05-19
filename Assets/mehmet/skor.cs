using UnityEngine;
using TMPro;

public class skor : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 

    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Collectible"))
        {
            
            score ++;

           
            UpdateScoreText();

          
            Destroy(other.gameObject);
        }
    }

    
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
