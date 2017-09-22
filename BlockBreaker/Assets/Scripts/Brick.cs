using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrickBreaker
{
    public class Brick : MonoBehaviour
    {

        public static int breakableCount = 0;
        public GameObject smoke;

        [SerializeField]
        private Sprite[] hitSprites;
        private int timesHit;

        private LevelManager levelManager;
        private SpriteRenderer spriteRenderer;
        private bool isBreakable ;
        // Use this for initialization
        void Start()
        {
            isBreakable = (this.tag == "Breakable");
            //keep track of breakable bricks
            if (isBreakable)
            {
                breakableCount++;
            }

            levelManager = FindObjectOfType<LevelManager>();

            timesHit = 0;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            if (isBreakable)
            {
                HandleHits();
            }
        }

        private void HandleHits() {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                
                KillBlock();

            }
            else
            {
                LoadSprites();
            }
        }

        private void LoadSprites() {
            int index = timesHit - 1;
            spriteRenderer.sprite = hitSprites[index];
        }

        private void KillBlock()
        {

            SpawnParticles();
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            breakableCount--;

            levelManager.BrickDestroyed();
        }

        private void SpawnParticles()
        {
            Instantiate(smoke, transform.position, Quaternion.identity);
        }

    }
}
