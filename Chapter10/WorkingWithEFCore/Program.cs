﻿using Northwind.EntityModels; // To use Northwind.

ConfigureConsole();
// QueryingCategories();
// FilteredIncludes();
// QueryingProducts();
// GettingOneProduct();
// QueryingWithLike();
// GetRandomProduct();
// LazyLoadingWithNoTracking();
// var resultAdd = AddProduct(categoryId: 6, productName: "Bob's Burgers", price: 500M, stock: 72);
// if (resultAdd.affected == 1)
// {
//     WriteLine($"Add product successful id ID: {resultAdd.productId}.");
// }
// ListProducts(productIdsToHighlight: new[] { resultAdd.productId });
var resultUpdate = IncreaseProductPrice(productNameStartsWith: "Bob", amount: 20M);
if (resultUpdate.affected == 1)
{
    WriteLine($"Increase price success for ID: {resultUpdate.productId}.");
}
ListProducts(productIdsToHighlight: new[] { resultUpdate.productId });