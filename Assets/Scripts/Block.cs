using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config
    [SerializeField] AudioClip onDestroySound;
    [SerializeField] GameObject blockVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached references
    Level level;
    GameStatus gameStatus;

    // State variables
    [SerializeField] int timesHit; // TODO: Serialized for debug purposes

    private void Start()
    {
        level = GameObject.FindObjectOfType<Level>();
        gameStatus = GameObject.FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        {
            HandleBreakableHit();
        }
    }

    private void HandleBreakableHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            TriggerSparklesVFX();
            TriggerBlockSFX();
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void TriggerBlockSFX()
    {
        AudioSource.PlayClipAtPoint(onDestroySound, Camera.main.transform.position);
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else
        {
            Debug.LogError("Block sprite is missing from array: " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        gameStatus.addPointsToScore();
        level.BlockWasBroken();
        Destroy(gameObject);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
