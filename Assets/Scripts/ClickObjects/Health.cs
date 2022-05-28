using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int healthPoints = 4;
    [SerializeField] private GameObject particalPrefab;

    void Update()
    {
        if (gameObject.GetComponent<OnMonsterClick>().ClickSum >= healthPoints)
        {
            if (particalPrefab != null)
            {
                Instantiate(particalPrefab, transform.position, Quaternion.identity);
            }

            if (LevelManager.levelManager != null && LevelManager.levelManager.levelState == LevelManager.levelStates.Playing)
            {
                LevelManager.levelManager.CountScore(1);
            }
            else
            {
                if (GameManager.gameManager != null)
                    GameManager.gameManager.CountScore(1);
            }
            Destroy(gameObject);
        }
    }
}
