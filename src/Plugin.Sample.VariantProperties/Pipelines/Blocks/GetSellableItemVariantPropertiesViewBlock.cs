using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Sample.VariantProperties.Components;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Pipelines;

namespace Plugin.Sample.VariantProperties.Pipelines.Blocks
{
    public class GetSellableItemVariantPropertiesViewBlock : PipelineBlock<EntityView, EntityView, CommercePipelineExecutionContext>
    {
        private readonly ViewCommander _viewCommander;

        public GetSellableItemVariantPropertiesViewBlock(ViewCommander viewCommander)
        {
            _viewCommander = viewCommander;
        }

        public override Task<EntityView> Run(EntityView arg, CommercePipelineExecutionContext context)
        {
            var catalogViewsPolicy = context.GetPolicy<KnownCatalogViewsPolicy>();
            var request = _viewCommander.CurrentEntityViewArgument(context.CommerceContext);

            if (arg.Name != catalogViewsPolicy.ConnectSellableItem
                || !(request.Entity is SellableItem))
                return Task.FromResult(arg);

            var detailsView = new EntityView
            {
                EntityId = arg.EntityId,
                EntityVersion = arg.EntityVersion,
                Name = Constants.ViewNames.VariantProperties,
                DisplayName = "Variant Properties",
                Action = request.ForAction,
                Properties = new List<ViewProperty>
                {
                    new ViewProperty
                    {
                        Name = nameof(VariantPropertiesComponent.Colors),
                        DisplayName = nameof(VariantPropertiesComponent.Colors),
                        IsReadOnly = true,
                        OriginalType = "System.String"
                    },
                    new ViewProperty
                    {
                        Name = nameof(VariantPropertiesComponent.Sizes),
                        DisplayName = nameof(VariantPropertiesComponent.Sizes),
                        IsReadOnly = true,
                        OriginalType = "System.String"
                    },    new ViewProperty
                    {
                        Name = nameof(VariantPropertiesComponent.Styles),
                        DisplayName = nameof(VariantPropertiesComponent.Styles),
                        IsReadOnly = true,
                        OriginalType = "System.String"
                    }
                }
            };

            arg.ChildViews.Add(detailsView);

            return Task.FromResult(arg);
        }
    }
}
