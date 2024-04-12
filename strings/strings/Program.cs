// See https://aka.ms/new-console-template for more information
// Top-level statements -> top-level program
// Ctrl + K Ctrl + ,

// Imagine this is a full-featured application
// We're adding features

// Task 1: Create a message telling the user to say "help"
// string msg = "Please say "help" for assistance";
// Console.WriteLine(msg);


// Task 2: Create a multiline congratulations message
// bool goodCredit = true;
// bool newVehicle = true;
// if (goodCredit)
// {
//   if (newVehicle)
//   {
//     string congrats = "Congratulations on your new vehicle! \n We hope you enjoy driving it!";
//     Console.WriteLine(congrats);
//   }
// }


// Task 3: Create a JSON file with sample data
// string vehicleJSON = "
//   {
//     "id": 1,
//     "name:": "AT-AT",
//     "price": 1999.99
//   }";

// string vehicleJSON = "{ \n \"id\": 1," +
//  "\n \"name\": \"AT-AT\","+
//  "\n \"price\": 1999.99\n}";
// Console.WriteLine(vehicleJSON);


// Task 4: Use a variable or expression in a string (interpolation)
// string pageTitle = "Vehicle Detail";
// string header = $"Header: {pageTitle}";
// Console.WriteLine(header);


// Task 5: Use a variable or expression in a JSON string (interpolation)
// string vehicleName = "AT-AT";
// decimal price = 1999.99m;
// string vehicleJSON = @"
//   {
//     ""id"": 1,
//     ""name:"": ""AT-AT"",
//     ""price"": 1999.99
//   }";
// Console.WriteLine(vehicleJSON);


// Task 6: Display different text based on the quantity (Switch statement -> Switch expression)
// int quantity = 5;
// string itemText = "";
// switch (quantity)
// {
//   case 0:
//     itemText = "No items";
//     break;
//   case 1:
//     itemText = "One item";
//     break;
//   default:
//     itemText = $"{quantity} items";
//     break;
// }
// Console.WriteLine(itemText);


// Task 7: Display different text based on the quantity with tuple pattern


// Task 8: Display different text based on the quantity with type pattern
// string PrepareMessage<T>(IEnumerable<T> info)
// {
//   string message = info switch
//   {
//     null => "Value is null",
//     List<int> list => $"List has {list.Count} items",
//     List<string> list => string.Join(", ", list),
//     _ => "Value is not a list of integers or strings"
//   };
//   return message;
// }
// Console.WriteLine(PrepareMessage(new List<int>() { 1, 2, 3 }));
// Console.WriteLine(PrepareMessage(new List<string>() { "a", "b", "c" }));
// Console.WriteLine(PrepareMessage(new List<decimal>() { 1.2m, 3.5m, 8.8m }));


// Task 9: Check elements with the list pattern
