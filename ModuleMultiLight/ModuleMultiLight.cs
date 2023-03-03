using KSP.UI.Screens;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using Expansions.Missions.Adjusters;
using UnityEngine;

public class ModuleMultiLight : ModuleLight
{
    [KSPField(guiActive = true, guiActiveEditor = true, guiName = "Light Range", isPersistant = true)]
    [UI_FloatRange(maxValue = 300, minValue = 1, stepIncrement = 1f)]
    public float lightRange = 60;

    public override void OnAwake()
    {
        base.OnAwake();
        //TODO Fix the lights to turn them on when switching to vessel or starting flight again from space center
        //GameEvents.onVesselLoaded.Add(_ => FixLightStates());
        //GameEvents.onVesselChange.Add(_ => FixLightStates());
        //GameEvents.onLaunch.Add(_ => FixLightStates());
        Fields["lightRange"].OnValueModified += (_ => UpdateRange());
    }

    public override void OnStart(PartModule.StartState state)
    {
        base.OnStart(state);
        GetLightObjects();
    }

    private void GetLightObjects()
    {
        lights = new List<Light>();
        string[] temp = lightName.Replace(" ", "").Split(',');

        if (temp.Length < 1)
            return;

        if (temp.Length == 1)
        {
            var count = part.FindModelTransform(lightName).childCount;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    Transform obj = part.FindModelTransform(lightName).GetChild(i);
                    string nam = obj.name;
                    this.lights.AddRange(part.FindModelComponents<Light>(nam));
                }
            }
        }
        else
        {
            foreach (var name in temp)
                this.lights.AddRange(part.FindModelComponents<Light>(name));
        }
        foreach (var light in lights)
        {
            light.range = lightRange;
            brightnessLevels.Add(light.intensity);
            light.color = (Color)typeof(ModuleLight).GetField("lightColor").GetValue(this);
        }
        this.SetLightState(isOn, true);
    }

    public virtual void UpdateRange()
    {
        brightnessLevels.Clear();
        foreach (var light in lights)
        {
            light.range = lightRange;
            brightnessLevels.Add(light.intensity);
        }
    }

    public virtual void FixLightStates()
    {
        //TODO Fix the lights to turn them on when switching to vessel or starting flight again from space center
    }
}
