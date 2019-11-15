using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Plugin.Sample.VariantProperties.Pipelines.Blocks;
using Sitecore.Commerce.Core;
using Sitecore.Commerce.EntityViews;
using Sitecore.Commerce.Plugin.Catalog;
using Sitecore.Framework.Configuration;
using Sitecore.Framework.Pipelines.Definitions.Extensions;

namespace Plugin.Sample.VariantProperties
{
    public class ConfigureSitecore : IConfigureSitecore
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            services.Sitecore().Pipelines(p => p
                .ConfigurePipeline<IGetEntityViewPipeline>(c => c
                    .Add<GetSellableItemVariantPropertiesViewBlock>().Before<IFormatEntityViewPipeline>())

                .ConfigurePipeline<IGetSellableItemConnectPipeline>(c => c
                    .Add<ExtendSellableItemVariantPropertiesBlock>().After<FormatComposerViewPropertyBlock>()
                )

                .ConfigurePipeline<IGetSellableItemsConnectPipeline>(c => c
                    .Add<ExtendSellableItemVariantPropertiesBlock>().After<FormatComposerViewPropertyBlock>()
                ));
        }
    }
}
