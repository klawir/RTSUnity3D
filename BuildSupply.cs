using System.Collections;
using System.Collections.Generic;
using GraphicalUserInterface.Player.Resources;
using GraphicalUserInterface.Production;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GraphicalUserInterface
{
    namespace Unit
    {
        namespace Worker
        {
            namespace Creating
            {
                public class BuildSupply : Button
                {
                    protected override void Start()
                    {
                        base.Start();
                        PreInstantiateManager.instance.InitBuildSupplyButton(obj);
                    }

                    public override void OnPointerClick(PointerEventData eventData)
                    {
                        base.OnPointerClick(eventData);
                        if (Minerals.instance.IsEnough(obj))
                            PreInstantiateManager.instance.SpawnPreSupply();
                    }

                    public override void OnPointerEnter(PointerEventData eventData)
                    {
                        base.OnPointerEnter(eventData);
                    }

                    public override void OnPointerExit(PointerEventData eventData)
                    {
                        base.OnPointerExit(eventData);
                    }
                }
            }
        }
    }
}