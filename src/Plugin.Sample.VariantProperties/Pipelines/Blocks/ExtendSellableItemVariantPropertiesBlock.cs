using System.Linq;
using System.Threading.Tasks;
using Plugin.Sample.VariantProperties.Components;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Pipelines;

namespace Plugin.Sample.VariantProperties.Pipelines.Blocks
{
    public class ExtendSellableItemVariantPropertiesBlock : PipelineBlock<SellableItem, SellableItem, CommercePipelineExecutionContext>
    {
        public override Task<SellableItem> Run(SellableItem arg, CommercePipelineExecutionContext context)
        {

            if (arg.HasComponent<ItemVariationsComponent>())
            {
                var variants = arg.GetComponent<ItemVariationsComponent>()
                    .ChildComponents
                    .OfType<ItemVariationComponent>()
                    .Where(c => c.HasComponent<DisplayPropertiesComponent>())
                    .ToArray();

                var component = arg.GetComponent<VariantPropertiesComponent>();

                //Colors
                component.Colors = variants
                    .Select(v => v.GetComponent<DisplayPropertiesComponent>())
                    .Select(d => d.Color)
                    .Distinct()
                    .ToList();

                //Sizes
                component.Sizes = variants
                    .Select(v => v.GetComponent<DisplayPropertiesComponent>())
                    .Select(d => d.Size)
                    .Distinct()
                    .ToList();

                //Styles
                component.Styles = variants
                    .Select(v => v.GetComponent<DisplayPropertiesComponent>())
                    .Select(d => d.Style)
                    .Distinct()
                    .ToList();
            }

            return Task.FromResult(arg);
        }
    }
}
