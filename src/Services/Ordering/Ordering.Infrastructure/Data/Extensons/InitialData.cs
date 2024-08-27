namespace Ordering.Infrastructure.Data.Extensons;

internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),"people.xie","people.xie@163.com"),
            Customer.Create(CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),"people.xie","people.xie@gmail.com")
         };

    public static IEnumerable<Product> Products => new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")),"IPhone X", 500),
        Product.Create(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")),"Samsung 10",400),
        Product.Create(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")),"Huawei Plus",650),
        Product.Create(ProductId.Of(new Guid("6ec1297b-ec02-4aa1-be25-6726e3b51a27")),"Xiaomi Mi",450)
    };

    public static IEnumerable<Order> OrdersWithItems  
    {
        get
        {
            var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler No:4","Turkey","Istanbul","38050");
            var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1","England", "Nottingham","08050");

            var payment1 = Payment.Of("mehmet", "55555555555444", "12/28", "355",1);
            var payment2 = Payment.Of("john", "8888999933323", "06/30", "222",2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
                OrderName.Of("Order 1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);
            order1.Add(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), 100, 500);
            order1.Add(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), 150, 400);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),
                OrderName.Of("Order 2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);
            order2.Add(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), 99, 650);
            order2.Add(ProductId.Of(new Guid("6ec1297b-ec02-4aa1-be25-6726e3b51a27")), 59, 450);

            return new List<Order> { order1,order2 };
        }
    }

   

}
