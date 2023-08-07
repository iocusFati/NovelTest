using Naninovel;
using UnityEngine;

namespace Configs
{
    public class ResourceConfiguration : Configuration
    {
        public const string DefaultPathPrefix = "Artifact";

        [Tooltip("Configuration of the resource loader used with inventory resources.")]
        public ResourceLoaderConfiguration Loader = new ResourceLoaderConfiguration { PathPrefix = DefaultPathPrefix };
    }
}
