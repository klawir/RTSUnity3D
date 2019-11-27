using System.Collections;
using System.Collections.Generic;
using Unit.Maneuvers;
using UnityEngine;

namespace Unit
{
    namespace CoreType
    {
        namespace Elite
        {
            namespace Enemy
            {
                public class Boss : CoreType.Enemy.CombatUnit
                {
                    private Vector3 originalPos;
                    public Avoidance avoid;
                    private bool backingToOriginalPos;
                    private Core.Enemy.Navigation navigation;
                    public EnemyHealth health;
                    public Unit.Enemy.Elite.Combat combat;

                    protected override void Awake()
                    {
                        base.Awake();
                    }
                    public override void Start()
                    {
                        base.Start();
                        InitStartPos();
                        navigation = GetComponent<Core.Enemy.Navigation>();
                    }
                    protected override void Update()
                    {
                        if (!backingToOriginalPos)
                            base.Update();
                        if (IsOutOfRange || DetectUnitsManager.IsEnemyIsNotInRange && health.IsUnitHearted)
                            BackToOriginalPos();
                        if (HasBeenReturnToTheStartPos)
                            Restart();
                    }
                    private void Restart()
                    {
                        backingToOriginalPos = false;
                        navigation.Stop();
                        health.RestoreInstantly();
                        ColorLevel.instance.SetToHight();
                    }
                    private void InitStartPos()
                    {
                        originalPos = transform.position;
                    }
                    private bool IsOutOfRange
                    {
                        get { return Vector3.Distance(transform.position, originalPos) > combat.maxRange; }
                    }
                    private bool HasBeenReturnToTheStartPos
                    {
                        get { return Vector3.Distance(transform.position, originalPos) < range && backingToOriginalPos; }
                    }
                    private void BackToOriginalPos()
                    {
                        backingToOriginalPos = true;
                        avoid.TurnOnNav(originalPos);
                    }
                    public bool IsBackingToOriginalPos
                    {
                        get { return backingToOriginalPos; }
                    }
                }
            }
        }
    }
}