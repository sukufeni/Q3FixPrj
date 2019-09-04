using System;
using System.Linq;

namespace Q3FixPrj
{
    class Program
    {
        static void Main(string[] args)
        {

            PersonManager manager = new PersonManager();
            manager.AddPerson(new Person("Bruno", DateTime.Parse("06/06/2018").Date));
            manager.AddPerson(new Person("Rodrigo", DateTime.Parse("01/02/2017")));
            manager.AddPerson(new Person("Felipe", DateTime.Parse("01/02/2000")));

            ShowPeopleList(manager);

            Console.WriteLine("Press enter to see the available options");
            Console.ReadLine();
            Console.Clear();
            int loop = 0;
            do
            {

                Console.WriteLine(@"Press 
                                        1- INSERT
                                        2- REMOVE
                                        3- GET BACK TO PEOPLE LIST
                                        4- CLOSE");


                int.TryParse(Console.ReadLine(), out loop);
                switch (loop)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Please fill the name: ");
                        string name = Console.ReadLine();
                        DateTime birthDate;

                        Console.WriteLine("Please fill the birthDate");
                        birthDate = GetBirthDate();

                        manager.AddPerson(new Person(name, birthDate));
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("1- DELETE BY INDEX" +
                            "\n 2- DELETE BY NAME and age");
                        int delOption = int.Parse(Console.ReadLine());


                        // tries to delete the person 
                        try
                        {
                            if (delOption.Equals(1))
                            {

                                int index = -1;
                                do
                                {
                                    Console.WriteLine("Insert the position of the person that will be removed");
                                } while (!int.TryParse(Console.ReadLine(), out index));

                                manager.DeletePerson(index);
                                Console.WriteLine("Person Deleted!");
                            }
                            else
                            {
                                Console.WriteLine("Please fill the name: ");
                                name = Console.ReadLine();

                                birthDate = GetBirthDate();

                                Person aux = manager.FindPerson(name, birthDate);
                                manager.DeletePerson(aux);
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("there was an error while deleting the current person:");
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        ShowPeopleList(manager);
                        break;
                    case 4:
                        return;
                }
            } while (loop != 4);
        }

        private static DateTime GetBirthDate()
        {
            DateTime birthDate;
            while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                Console.Clear();
                Console.WriteLine("Please A valid fill the birthDate - FORMAT: dd/MM/yyyy");
            }

            return birthDate;
        }


        private static void ShowPeopleList(PersonManager manager)
        {
            Console.Clear();
            int index = -1;
            foreach (Person person in manager.Db.AsEnumerable())
            {
                index++;
                Console.WriteLine("Index: " + index + " - " + person.ToString());
            }
        }
    }
}
