using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockEffects;

    Level level;
    GameStatus gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.AddBlock();

        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.RemoveBlock();
        gameStatus.AddPointsToScore();
        TriggerEffects();
        Destroy(gameObject);
    }

    private void TriggerEffects()
    {
        GameObject effects = Instantiate(blockEffects, transform.position, transform.rotation);
        Destroy(effects, 2f);
    }
}
