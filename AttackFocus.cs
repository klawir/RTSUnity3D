using UnityEngine;

namespace Unit
{
    namespace Maneuvers
    {
        public class AttackFocus : Focus
        {
            protected override void Start()
            {
                base.Start();
            }
            public override void Order()
            {
                base.Order();
            }
            public override void DoAttack()
            {
                if (DoesntTargetExist)
                {
                    if (wasTarget)
                        Reset();
                }
                else
                {
                    if (!IsTargetDead)
                    {
                        if (IsUnitClose)
                            Hit(target);
                        else
                            GoToTarget();
                    }
                    else
                    {
                        RemeberCombat();
                        AbandonTarget();
                    }
                }
            }
            public override void Hit(GameObject target)
            {
                base.Hit(target);
                unitAttackType.DealDamage(target);
            }
            protected override void GoToTarget()
            {
                baseNavigation.SetPos(target.transform.position);
            }
            private void Reset()
            {
                AbandonTarget();
                baseNavigation.Stop();
                RestoreDefaultStatOfTarget();
            }
        }
    }
}