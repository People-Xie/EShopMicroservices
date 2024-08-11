using Marten.Schema;
using System.Collections.Generic;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();
        if (await session.Query<Product>().AnyAsync()) return;

        session.Store<Product>(GetPreconfiguredProducts());

        await session.SaveChangesAsync(); 
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
    {
        new Product()
        {
            Id = new Guid("5334c996-8457-4c40-815c-ed2b77c4ff61"),
            Name = "IPhone X",
            Description = "This phone is the company's biggest change to its",
            ImageFile = "product-1.png",
            Price = 950.00M,
            Category = new List<string>{"Smart phone" }
        },
         new Product()
        {
            Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
            Name = "Samsung 10",
            Description = "This Samsung is the company's biggest change to its",
            ImageFile = "product-2.png",
            Price = 840.00M,
            Category = new List<string>{"Smart phone"}
        },
        new Product()
        {
            Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
            Name = "Samsung 10",
            Description = "This Samsung is the company's biggest change to its",
            ImageFile = "product-2.png",
            Price = 840.00M,
            Category = new List<string>{"Smart Samsung"}
        },
        new Product()
        {
            Id = new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),
            Name = "Huawei Plus",
            Description = "This Samsung is the company's biggest change to its",
            ImageFile = "product-3.png",
            Price = 650.00M,
            Category = new List<string>{"White Appliccations"}
        },
         new Product()
        {
            Id = new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27"),
            Name = "Xiaomi Mi 9",
            Description = "This Samsung is the company's biggest change to its",
            ImageFile = "product-5.png",
            Price = 470.00M,
            Category = new List<string>{"White Appliances"}
        },
        new Product()
        {
            Id = new Guid("7b86103d-c621-4f52-b498-23452610f88c"),
            Name = "HTC U11+ Plus",
            Description = "This Samsung is the company's biggest change to its",
            ImageFile = "product-5.png",
            Price = 380.00M,
            Category = new List<string>{"Smart Samsung"}
        },
        new Product()
        {
            Id = new Guid("c4bbc4a2-4555-45d8-97cc-2a99b2167bff"),
            Name = "LG G7 ThinQ",
            Description = "This Samsung is the company's biggest change to its",
            ImageFile = "product-6.png",
            Price = 240.00M,
            Category = new List<string>{"Home Kitchen"}
        },
        new Product()
        {
            Id = new Guid("93170c85-7795-489c-8e8f-7dcf3b4f4188"),
            Name = "Panasonic Lumix",
            Description = "This Samsung is the company's biggest change to its",
            ImageFile = "product-7.png",
            Price = 240.00M,
            Category = new List<string>{"Camera"}
        }
    };
}


