using System.Collections.Generic;
using Sitecore.Commerce.Core;

namespace Plugin.Sample.VariantProperties.Components
{
    public class VariantPropertiesComponent : Component
    {
        public VariantPropertiesComponent()
        {
            Colors = new List<string>();
            Sizes = new List<string>();
            Styles = new List<string>();
        }

        public List<string> Colors { get; set; }
        public List<string> Sizes { get; set; }
        public List<string> Styles { get; set; }
    }
}
