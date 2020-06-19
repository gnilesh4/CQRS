# MediatR

CQRS using MediatR.

## Command

 ```csharp
public class InsertProductCommand : IRequest
{
    public string Description { get; set; }
}
 ```

## CommandHandler

```csharp
public class InsertProductCommandHandler : AsyncRequestHandler<InsertProductCommand>
{
    private readonly IMediator _mediator;

    public InsertProductCommandHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected override Task Handle(InsertProductCommand command, CancellationToken cancellationToken)
    {
        var entity = ProductFactory.Create(command);

        _mediator.Publish(new ProductInsertedNotification(entity));

        return Task.CompletedTask;
    }
}
```

## Query

```csharp
public class GetByIdProductQuery : IRequest<ProductViewModel>
{
    public long Id { get; set; }
}
```

## QueryHandler

```csharp
public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductViewModel>
{
    public Task<ProductViewModel> Handle(GetByIdProductQuery query, CancellationToken cancellationToken)
    {
        return Task.FromResult(new ProductViewModel { Id = query.Id });
    }
}
```

## Notification

```csharp
public class ProductInsertedNotification : INotification
{
    public ProductInsertedNotification(ProductEntity product)
    {
        Product = product;
    }

    public ProductEntity Product { get; private set; }
}
```

## NotificationHandler

```csharp
public class ProductInsertedNotificationHandler : INotificationHandler<ProductInsertedNotification>
{
    public Task Handle(ProductInsertedNotification notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
```

## Tests

```csharp
[TestClass]
public class ProductTest
{
    private readonly IMediator _mediator;

    public ProductTest()
    {
        var services = new ServiceCollection();

        services.AddMediatR(typeof(InsertProductCommand));

        _mediator = services.BuildServiceProvider().GetService<IMediator>();
    }

    [TestMethod]
    public async Task Delete()
    {
        var command = new DeleteProductCommand { Id = 1 };

        await _mediator.Send(command);
    }

    [TestMethod]
    public async Task GetById()
    {
        var query = new GetByIdProductQuery { Id = 1 };

        var result = await _mediator.Send(query);
    }

    [TestMethod]
    public async Task Insert()
    {
        var command = new InsertProductCommand { Description = "Description" };

        await _mediator.Send(command);
    }

    [TestMethod]
    public async Task Update()
    {
        var command = new UpdateProductCommand { Id = 1, Description = "Description" }; ;

        await _mediator.Send(command);
    }
}
```

## Feature Folders

**Category**

    Delete

        DeleteCategoryCommand.cs

        DeleteCategoryCommandResult.cs

        DeleteCategoryCommandValidator.cs

        DeleteCategoryCommandHandler.cs

    Insert

        InsertCategoryCommand.cs

        InsertCategoryCommandResult.cs

        InsertCategoryCommandValidator.cs

        InsertCategoryCommandHandler.cs

    List

        ListCategoryQuery.cs

        ListCategoryQueryResult.cs

        ListCategoryQueryValidator.cs

        ListCategoryQueryHandler.cs

    Update

        UpdateCategoryCommand.cs

        UpdateCategoryCommandResult.cs

        UpdateCategoryCommandValidator.cs

        UpdateCategoryCommandHandler.cs

**Product**

    Delete

        DeleteProductCommand.cs

        DeleteProductCommandResult.cs

        DeleteProductCommandValidator.cs

        DeleteProductCommandHandler.cs

    Insert

        InsertProductCommand.cs

        InsertProductCommandResult.cs

        InsertProductCommandValidator.cs

        InsertProductCommandHandler.cs

    List

        ListProductQuery.cs

        ListProductQueryResult.cs

        ListProductQueryValidator.cs

        ListProductQueryHandler.cs

    SelectById

        SelectByIdProductQuery.cs

        SelectByIdProductQueryResult.cs

        SelectByIdProductQueryValidator.cs

        SelectByIdProductQueryHandler.cs

    Update

        UpdateProductCommand.cs

        UpdateProductCommandResult.cs

        UpdateProductCommandValidator.cs

        UpdateProductCommandHandler.cs

    UpdateCategory

        UpdateCategoryProductCommand.cs

        UpdateCategoryProductCommandResult.cs

        UpdateCategoryProductCommandValidator.cs

        UpdateCategoryProductCommandHandler.cs

    UpdatePrice

        UpdatePriceProductCommand.cs

        UpdatePriceProductCommandResult.cs

        UpdatePriceProductCommandValidator.cs

        UpdatePriceProductCommandHandler.cs
