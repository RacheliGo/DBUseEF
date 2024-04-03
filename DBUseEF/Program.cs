// See https://aka.ms/new-console-template for more information
using DBUseEF.Models;

Console.WriteLine("Hello, World!");

ShopContext context = new ShopContext();
//הצגת שמות כל הלקוחות
foreach (var item in context.Customers)
{
    Console.WriteLine(item.FirstName);
}

//הוספת לקוח
Customer newCustomer = new Customer()
{
    FirstName = "Racheli",
    LastName = "Gornshtein",
    City = "Recasim",
    Country = "Isral",
    Phone = "0504102187"
};

context.Customers.Add(newCustomer);
context.SaveChanges();

//מחיקת לקוח
var custom = context.Customers.Single(c => c.FirstName == "Racheli");
context.Customers.Remove(custom);
context.SaveChanges();

//עדכון רשומה
var UpdetCustom = context.Customers.Single(c => c.FirstName == "Racheli");
UpdetCustom.Phone = "0556775910";
context.SaveChanges();

//שימוש בפונקציה גינריט
void ChandAnyFeild(Customer Updetcustom, string columName, string newValue)
{
    Type type = Updetcustom.GetType();
    var property = type.GetProperty(columName);
    if (property.PropertyType == typeof(int?))
    {
        int valueAsInt;
        if (int.TryParse(newValue, out valueAsInt))
        {
            property.SetValue(Updetcustom, valueAsInt, null);
        }
        else
        {
            property.SetValue(Updetcustom, newValue, null);
        }
    }
}

var custom = context.Customers.Single(c => c.FirstName == "Racheli");
ChandAnyFeild(custom, "Age", "19");
context.SaveChanges();