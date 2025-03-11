using System;
using UnityEngine;
using System.Reflection;
using VehiclePhysics;

namespace Caviation
{
    public class ModuleEngineFlooding : PartModule
    {
        // This class references the stock engine module to turn on the unused squad engine in water check

        private ModuleEngines engineModule;
        private ModuleEnginesFX engineFXModule;

        public override void OnStart(StartState state)
        {
            base.OnStart(state);

            // Find an engine module on the same part
            engineModule = part.FindModuleImplementing<ModuleEngines>();
            engineFXModule = part.FindModuleImplementing<ModuleEnginesFX>();

            if (engineModule == null && engineFXModule == null)
            {
                Debug.LogError($"[KPDynamics] No compatible engine module found on this {part.name}!");
            }

            if (engineModule != null) engineModule.disableUnderwater = true;
            if (engineFXModule != null) engineFXModule.disableUnderwater = true;
        }
    }
}
