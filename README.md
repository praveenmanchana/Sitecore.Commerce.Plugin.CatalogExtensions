# Variant Properties As Facets

This is a sample solution that can enable the variant properties as facets for product listing and product search in sitecore experience commerce.

## Background

Variants in sitecore commerce are stored as components in a sellableitem and information about the variants is not indexed in sitecore and without customisations it is not posisble to use variant properties to be used for faceting.

## How to use this

1. Integrate the `Plugin.Sample.CatalogExtension` in to your current commerce engine solution. This will enable the variant properties `Sizes`, `Colors` and `Styles` to be available as properties on the sellable item template and maps the distinct variant properties (`Size`, `Color`, `Style`) to the variant properties.
1. Once the customisation is deployed to commerce engine roles. Update the Commerce Data templates in sitecore. This should have created a custom component template with variant properties (`Sizes`, `Colors`, `Styles`)
1. Copy the config file `Project.Sample.VariantProperties.config` to sitecore, this will register the variant properties with the correct data types that will enable the usage of variant property data as facets.
1. Download and install the package `Commerce Variant Properties.zip`, this will setup the facet items in sitecore (`Commerce Colors`, `Commerce Sizes`, `Commerce Styles`).
1. Publish changes and re-build web and master indexes.
1. To enable the variant properties on Product Listing pages. go to `/sitecore/templates/Commerce/Catalog/Commerce Category/__Standard Values` add the required variant properties to `Runtime Search Facets` field. Save and publish changes.
1. To enable the variant properties on Product search page. go to `/sitecore/templates/Commerce/Catalog/CommerceSearchSettings/__Standard Values` add the required variant properties to `Runtime Search Facets` field. Save and publish changes.
