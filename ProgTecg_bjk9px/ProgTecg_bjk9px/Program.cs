using System;


    
    // Prototipus IF
    
    public interface IPapers
    {
        IPapers Clone();
        string GetDetails();
    }

   
    public class Books : IPapers
    {
        public int Price { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }

        public IPapers Clone()
        {
            //shallow copy
            return (IPapers)MemberwiseClone();

        // Deep Copy
        //return (IPapers)this.Clone();
    }

    public string GetDetails()
        {
            return string.Format("{0} - {1} - {2}", Title, Publisher, Genre);
        }
    }

    
    /// 'Prototipus' class
    
    public class Newspapers : IPapers
    {
        public int Price { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        public IPapers Clone()
        {
            //shallow copy
            return (IPapers)MemberwiseClone();
        //deep copy  
        //return (IPapers)this.Clone()
    }

    public string GetDetails()
        {
            return string.Format("{0} - {1} - {2}HUF", Title, Publisher, Price);
        }
    }

    /// adatbevitel mainben, 

    class Program
    {
        static void Main(string[] args)
        {
            Books dev = new Books();
            dev.Title = "1984";
            dev.Publisher = "Helikon";
            dev.Genre = "Novel";

            Books devCopy = (Books)dev.Clone();
            devCopy.Title = "Animal Farm"; //Kiadó és múfaj nem klerült megadásra

            Console.WriteLine(dev.GetDetails());
            Console.WriteLine(devCopy.GetDetails());

            Newspapers newspapers = new Newspapers();
            newspapers.Title = "HVG";
            newspapers.Publisher = "HVG Kiado";
            newspapers.Price = 499;

            Newspapers newspapersCopy = (Newspapers)newspapers.Clone();
            newspapersCopy.Title = "PC GURU";
            newspapersCopy.Price = 999;//KIadó nem került megadásra

            Console.WriteLine(newspapers.GetDetails());
            Console.WriteLine(newspapersCopy.GetDetails());

            Console.ReadKey();

        }
    }