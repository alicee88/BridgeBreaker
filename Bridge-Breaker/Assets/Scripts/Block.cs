using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockEffects;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameStatus gameStatus;
    int hitsTaken = 0;

    private void Start()
    {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.AddBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            hitsTaken++;
            if(hitsTaken >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
        
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = hitsTaken - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
        if (tag == "Breakable")
        {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            level.RemoveBlock();
            gameStatus.AddPointsToScore();
            TriggerEffects();
            Destroy(gameObject);
        }
    }

    private void TriggerEffects()
    {
        GameObject effects = Instantiate(blockEffects, transform.position, transform.rotation);
        Destroy(effects, 2f);
    }
}
