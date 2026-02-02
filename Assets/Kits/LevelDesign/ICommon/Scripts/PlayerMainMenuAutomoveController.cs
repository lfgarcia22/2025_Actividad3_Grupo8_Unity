using System.Collections;
using Assets.Kits.Characters.ICommon.Scripts;
using UnityEngine;

namespace Assets.Kits.LevelDesign.ICommon.Scripts
{
    public class PlayerMainMenuAutomoveController : MovementController
    {
        [SerializeField] private float delayInSeconds = 5f;

        protected override void Awake()
        {
            base.Awake();
            DesiredMove = new(0, -1);
        }

        void Start()
        {
            StartCoroutine(AutoMoveCoroutine());
        }

        IEnumerator AutoMoveCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(delayInSeconds);
                DesiredMove = new(Random.Range(-1, 2), Random.Range(-1, 2));
            }
        }

    }
}
