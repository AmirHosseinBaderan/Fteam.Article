namespace Fteam.Article.Services.Implementation;

public static class KeyGenerator
{
    public static string StoreSettings(Guid storeId) => $"Store-Settings-{storeId}";

    public static string ProductsViewModel(int page, int count, double lat, double lon, Guid? groupId) => $"products-view-model-{page}-{count}-{lat}-{lon}-{groupId}";

    public static string StoreProductsViewModel(Guid storeId, int page, int count, Guid? groupId) => $"Store-Products-View-Model-{storeId}-{page}-{count}-{groupId}";
}
