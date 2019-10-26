using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor.ShaderGraph;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


namespace UnityEditor.VFX
{
    class VFXShaderGraphPostProcessor : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            var modifiedShaderGraphs = new HashSet<ShaderGraphVfxAsset>();

            foreach (var asset in importedAssets.Concat(deletedAssets))
            {
                if (asset.EndsWith(".shadergraph", StringComparison.InvariantCultureIgnoreCase))
                {
                    var ass = AssetDatabase.LoadAssetAtPath<ShaderGraphVfxAsset>(asset);
                    if( ass != null)
                        modifiedShaderGraphs.Add(ass);
                }
                    
            }

            if (modifiedShaderGraphs.Count > 0)
            {
                string[] guids = AssetDatabase.FindAssets("t:VisualEffectAsset");
                var assetsToReimport = new HashSet<VFXGraph>();

                foreach (var vfxPath in guids.Select(t => AssetDatabase.GUIDToAssetPath(t)))
                {
                    var resource = VisualEffectResource.GetResourceAtPath(vfxPath);
                    if (resource != null)
                    {
                        VFXGraph graph = resource.GetOrCreateGraph();

                        if (graph != null)
                        {
                            if (graph.children.OfType<VFXShaderGraphParticleOutput>().Any(t => modifiedShaderGraphs.Contains(t.shaderGraph)))
                                assetsToReimport.Add(graph);
                        }
                    }
                }

                foreach (var graph in assetsToReimport)
                {
                    foreach (var sgOutput in graph.children.OfType<VFXShaderGraphParticleOutput>().Where(t => modifiedShaderGraphs.Contains(t.shaderGraph)))
                    {
                        int instanceID = sgOutput.shaderGraph.GetInstanceID();

                        // This is needed because the imported invalidate the object
                        sgOutput.shaderGraph = EditorUtility.InstanceIDToObject(instanceID) as ShaderGraphVfxAsset;

                        sgOutput.ResyncSlots(true);
                    }

                    graph.SetExpressionGraphDirty();
                    graph.RecompileIfNeeded();
                }
            }
        }
    }
}
