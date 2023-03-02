using System.Collections.Generic;
using UnityEngine;

public class ModuleMultiLight : ModuleLight
{
    [KSPField]
    public float lightRange = 60;

    public override void OnStart(PartModule.StartState state)
    {
        base.OnStart(state);
        lights = new List<Light>();
        string[] temp = lightName.Replace(" ", "").Split(',');

        foreach (var name in temp)
            this.lights.AddRange(part.FindModelComponents<Light>(name));

        foreach (var light in lights)
        {
            light.range = lightRange;
            brightnessLevels.Add(light.intensity);
            // Not sure if the reflection bellow will work or not!
            light.color = (Color) typeof(ModuleLight).GetField("lightColor").GetValue(this);
        }
    }
}

