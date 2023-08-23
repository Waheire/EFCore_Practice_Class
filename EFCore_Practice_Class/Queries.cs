using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Practice_Class
{
    internal class Queries
    {
        private ApplicationContext context = new ApplicationContext();
        //insert data
        public void AddNewTour() 
        {
            var newTour = new Tour()
            {
                Name = "America Tour",
                Description = "Bikers worldwide tour around America",
                price = 98837390
            };

            //adding to table
            context.Tours.Add (newTour);

            //save
            context.SaveChanges();
           
        }

        public void getAllTours()
        {
            var tours = context.Tours.ToList();
            foreach (var tour in tours) 
            {
                Console.WriteLine($"{tour.Name} -- {tour.Description}--- {tour.price}");
            }
        }

        //get tours where 
        public void GetOneTour() 
        {
            // where
            //var tour = context.Tours.Find();// throw error if there is no matches

            var tours = context.Tours.Where(t => t.price > 50000).ToList();
            foreach (var tour in tours) 
            {
                Console.WriteLine($"{tour.Name} -- {tour.Description}--- {tour.price}");
            }
        }

        //get tours ordered by 
        public void getAndOrderBY()
        {
            // where
            //var tour = context.Tours.Find();// throw error if there is no matches

            var tours = context.Tours.Where(t => t.price > 50000).OrderByDescending(c =>c.price ).ThenBy(c=> c.price).ToList();
            foreach (var tour in tours)
            {
                Console.WriteLine($"{tour.Name} -- {tour.Description}--- {tour.price}");
            }
        }

        //update tour
        public void updtaeTour(int id)
        {
            // where
            //var tour = context.Tours.Find();// throw error if there is no matches

            Tour tour =context.Tours.Find(id);
            if (tour != null)
            {
                tour.Name = "Bomas Tour";
                tour.Description = "Tour around Bomas of Kenya";
                tour.price = 83248493;
                context.SaveChanges();
            }
            else 
            {
                return;
            }

            var tours = context.Tours.ToList();
            foreach (var tour1 in tours)
            {
                Console.WriteLine($"{tour1.Name} -- {tour1.Description}--- {tour1.price}");
            }
        }

        public void deleteTour(int id) 
        {
            //check if tour exists
            try 
            {
                Tour tour = context.Tours.Find(id);

                if (tour != null) 
                {
                    context.Remove(tour);
                    context.SaveChanges();

                    //show remaining tours
                    var tours = context.Tours.ToList();
                    foreach (var tour1 in tours)
                    {
                        Console.WriteLine($"{tour1.Name} -- {tour1.Description}--- {tour1.price}");
                    }
                }

            } catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
