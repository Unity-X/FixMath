using System;
using System.Linq;
using UnityEngine;
using UnityEngineX;

namespace UnityEngineX.FixMath
{
    public class ScriptTemplateAdditionalIncludes
    {
        [DefaultSmartScriptResolver.AdditionalUsingsProvider]
        public static string[] GetAdditionalIncludes(DefaultSmartScriptResolver.Info info)
        {
            if (info.Assembly.GetReferencedAssemblies().Any((asm) => asm.Name == "CCC.FixMath"))
            {
                return new string[]
                {
                    $"using static {typeof(fixMath).GetPrettyFullName()};"
                };
            }

            return null;
        }
    }
}