// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using TodoItems.Domain;
using TodoItems.Infrastructure;
using TodoItems.Infrastructure.Entities;

var serviceProvider = new ServiceCollection()
              .AddScoped<IRepository<TodoItem>, TodoItemRepository>()
              .AddSingleton<IUnitOfWork, TodoItemDbContext>()
              .AddDbContext<TodoItemDbContext>()
              .BuildServiceProvider();

var todoItemRepository = serviceProvider.GetService<IRepository<TodoItem>>();

#region Creating some values

string guid = Guid.NewGuid().ToString();

TodoItem todoItem1 = new() { Description = $"TodoItem{guid}", GroupId = 1, Id = 0 };
await todoItemRepository.CreateAsync(todoItem1);

guid = Guid.NewGuid().ToString();
TodoItem todoItem2 = new() { Description = $"TodoItem{guid}", GroupId = 2, Id = 0 };
await todoItemRepository.CreateAsync(todoItem2);

guid = Guid.NewGuid().ToString();
TodoItem todoItem3 = new() { Description = $"TodoItem{guid}", GroupId = 2, Id = 0 };
await todoItemRepository.CreateAsync(todoItem3);

await todoItemRepository.UnitOfWork.SaveChangeAsync();

#endregion

#region Updating one

guid = Guid.NewGuid().ToString();
TodoItem todoItem4 = new() { Description = $"TodoItem{guid}", GroupId = 2, Id = 1 };
await todoItemRepository.UpdateAsync(1, todoItem4);

await todoItemRepository.UnitOfWork.SaveChangeAsync();

#endregion

#region Getting one

var todoItemGet = await todoItemRepository.GetAsync(1);
Console.WriteLine(todoItemGet?.ToString());


#endregion

#region Deleting one

//await todoItemRepository.DeleteAsync(1);

//await todoItemRepository.UnitOfWork.SaveChangeAsync();

#endregion

#region Getting all values

var list = await todoItemRepository.GetAllAsync();

foreach (var item in list)
{ 
    Console.WriteLine(item.ToString());
}
#endregion


