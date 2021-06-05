Programozási Technológiák Gyakorlat

Kovács Máté(bjk9px) - Gazdinfó



Feladat: Tetszőlegesen választott tervezési minta rövid bemutatása



Prototípus:



A prototípus tervezési minta egy, a gyakorlatban gyakran használt módszer. Akkor használjuk amikor több hasonló objektumot szükséges előállítanunk a lehető legkevesebb ráfordítással. A minta egy már létező objektumot másol, és módosítja, kiegészíti attribútumait. 

Két fő fajtáját különböztetjük meg, a sekély és mély (shallow/deep) klónozási technológiát. 

A különbség, hogy sekély esetben az osztály referenciáit ugyanúgy másoljuk, mint az elemi típusait. Mély klónozásnál az osztály referenciái által mutatott objektumokat is klónozzuk.



Feladatomban az "olvasnivalók" kategórián belül a könyveket és újságokat kezelem. 

A publikus interfész az alábbi eljárásokat tartalmazza:

```c#
 IPapers Clone();
 string GetDetails();
```



A Clone eljárás a klónozásért felel, a GetDetails csak az adatok kinyerését szolgálja.

A könyv publikus osztályban (public class Books : IPapers) a négy konstruktoron felül tartalmazza klónozást és a GetDetails-t is. 

Konstruktorok:

```c#
 public int Price { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public string Genre { get; set; }
```
Klónozás:

```c#
public IPapers Clone()
    {
        //shallow copy
        return (IPapers)MemberwiseClone();

        // Deep Copy
        //return (IPapers)this.Clone();
    }
```



Az újság osztály hasonló struktúrában épül fel, tartalmazza  a klónozási eljárásokat és a GetDetails függvényt is. 

```C#
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
```



Main:

A megadott adatok mintaként szolgálnak, és használjak a korábban megírt eljárásokat az alábbi módon:

```
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
```





Látható, hogy az Állatfarm című könyv esetén már nem került megadásra a kiadó és a műfaj, míg az újságok esetén a "PC GURU" esetében sem adtam meg kiadót.

A kódot futtatva az alábbiakat adja vissza:

***1984 - Helikon - Novel***
***Animal Farm - Helikon - Novel***
***HVG - HVG Kiado - 499HUF***
***PC GURU - HVG Kiado - 999HUF***



A klónozást használva felgyorsítható az egyes példányok létrehozása, rövidebb ideig tart az adatbevitel. 





