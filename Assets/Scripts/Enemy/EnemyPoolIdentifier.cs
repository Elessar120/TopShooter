using UnityEngine;
    public class EnemyPoolIdentifier : Element, IReturnToPool
    {
        public Pool currentPool;
        /// <summary>
        /// returns dead enemy to related object pool
        /// </summary>
        public void ReturnToPool()
        {
            gameObject.SetActive(false);
            GetComponent<ItakeDamage>().OnDeath -= TopShooterApplication.topShooterController.scoreController.DecreaseScore;
            currentPool.Return(gameObject);
        }
    }
