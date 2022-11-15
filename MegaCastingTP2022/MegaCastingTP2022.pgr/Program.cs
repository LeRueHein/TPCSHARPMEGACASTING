// See https://aka.ms/new-console-template for more information
using MegaCasting2022.DBLib.Class;
Console.WriteLine("Hello, World!");


MegaCastingContext context = new MegaCastingContext();


/*//Ajout 
Console.WriteLine("renseignez la nouvelle activité");
string Newactivity = Console.ReadLine();

var activityName = new Activity { Name = Newactivity };
context.Activities.Add(activityName);
context.SaveChanges();

//Suppression
Civility civility = context.Civilities
    .OrderByDescending(civility => civility.Identifier)
    .First();*/


// Ajout
context.Activities
    .Add(new Activity() { Name = "Doc"});
context.SaveChanges();

// Suppression
context.Activities.Remove(context.Activities
    .OrderBy(civ => civ.Identifier)
    .Last());

// Modification
Activity activity = context.Activities
    .OrderByDescending(civ => civ.Identifier)
    .First();

activity.Name = "Docteur";
context.SaveChanges();

Console.ReadKey();



context.Activities.ToList().ForEach(activity => Console.WriteLine(activity.Name));

