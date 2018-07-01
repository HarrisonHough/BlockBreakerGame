using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class Brick : MonoBehaviour
    {

        public static int breakableCount = 0;
        public GameObject smoke;

        [SerializeField]
        private Sprite[] hitSprites;
        private int timesHit;

        [SerializeField]
        private int pointsForBreaking = 5;

        private SpriteRenderer spriteRenderer;
        private bool isBreakable ;

        /// <summary>
        /// Use this for initialization
        /// </summary>
        void Start()
        {
            isBreakable = (this.tag == "Breakable");
            timesHit = 0;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            if (isBreakable)
            {
                HandleHits();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleHits() {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                //add score value
                GameManager.Instance.AddToScore(pointsForBreaking);

                //kill block
                KillBlock();

            }
            else
            {
                LoadSprites();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadSprites() {
            int index = timesHit - 1;
            spriteRenderer.sprite = hitSprites[index];
        }

        /// <summary>
        /// 
        /// </summary>
        private void KillBlock()
        {

            SpawnParticles();
            //hide and disable block collisions
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            //Debug.Log("Count before subtraction" + breakableCount);
            breakableCount--;
            //Debug.Log(breakableCount);
            
            GameManager.Instance.BrickDestroyed();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SpawnParticles()
        {
            //Instantiate(smoke, transform.position, Quaternion.identity);
            GameManager.Instance.ParticleControl.SpawnSmokeParticles(transform.position);
        }

    }
}
