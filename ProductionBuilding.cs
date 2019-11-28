using Building.Core;
using Building.Production.TrainingSuggestion;
using GraphicalUserInterface;
using System.Collections.Generic;
using Unit;
using UnityEngine;

namespace Building
{
    namespace Type
    {
        public class ProductionBuilding : BaseBuilding
        {
            protected Spawner spawner;
            private Production.Training progress;
            public Items trainingSuggestion;

            public override void Start()
            {
                base.Start();
                progress = GetComponent<Production.Training>();
                spawner = GetComponent<Spawner>();
            }
            protected override void Update()
            {
                base.Update();
                if (IsSelected)
                {
                    spawner.RenderPoint();
                    if (Input.GetMouseButtonUp(0))
                    {
                        if (beenBuilt)
                        {
                            MainProgress.instance.Load(progress);
                            trainingSuggestion.Load();
                        }
                    }
                    if (Input.GetMouseButtonDown(1))
                        spawner.InitPointPos();
                }
                else
                    spawner.StopRenderPoint();
            }
            public override void OnConstructionComplete()
            {
                base.OnConstructionComplete();
                if (IsSelected)
                {
                    MainQueue.instance.DeleteAll();
                    if (IsOtherGUIExists)
                        ClearGUI();
                    trainingSuggestion.Load();
                }
            }
        }
    }
}