using Lab10OOP;
using Lab10OOP.Entity;
using Lab10OOP.Manager;
using Lab10OOP.Manager.Interfaces;
using Lab10OOP.Manager.Services;
using Microsoft.Extensions.DependencyInjection;

Category category1 = new Category("Horror");
Category category2 = new Category("Survival");
Category category3 = new Category("Detective");
Category category4 = new Category("Frictional");

List<Category> categories = new List<Category>();

categories.AddRange([category1,category2]);

User user = new User()
{
    Name = "Anton",
    Age = 20,
    Email = "anton@gmail.com",
    SubscribedCategories = categories
};

var serviceProvider = new ServiceCollection()
    .AddSingleton<IUserManager, UserManager>()
    .AddSingleton<IBookManager, BookManager>()
    .AddSingleton<INotificationService, EmailNotificationService>()
    .AddSingleton<ILoggerManager, LoggerManager>()
    .AddSingleton<ILibraryManager, LibraryManager>()
    .BuildServiceProvider();

var loggerManager = serviceProvider.GetService<ILoggerManager>();
var userManager = serviceProvider.GetService<IUserManager>();
var bookManager = serviceProvider.GetService<IBookManager>();
var notificationManager = serviceProvider.GetService<INotificationService>();


ILibraryManager libraryManager = new LibraryManager(
    userManager, 
    bookManager, 
    loggerManager, 
    notificationManager);

libraryManager.RegisterUser(
    user.Email,
    user.Age, user.Name,
    user.SubscribedCategories);
libraryManager.RegisterUser(
    "romka@gmail.com",
    20,
    "Roma",
    new List<Category>{category3});
libraryManager.RegisterUser(
    "dmytro@gmail.com",
    20,
    "Roma",
    new List<Category>{category4});


libraryManager.SubscribeBookCategory(category1, "romka@gmail.com");
libraryManager.SubscribeBookCategory(category3, "dmytro@gmail.com");


libraryManager.RegisterBook(
    "How to survive in forest", 
    "Benjamin Joe", 
    category2
);
libraryManager.RegisterBook(
    "LoveCraft", 
    "Lovecraft", 
    category1
    );
libraryManager.RegisterBook(
    "Sherlock", 
    "Holmes", 
    category3
);
libraryManager.RegisterBook(
    "Criminal Book", 
    "Criminal", 
    category4
);

Console.WriteLine("Showing all log...");

libraryManager.GetLog();

            