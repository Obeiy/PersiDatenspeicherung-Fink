namespace Persistente_datenspreicherung_Fink_Christoph
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    class Program
    {
        static void Main()
        { 
            Console.WriteLine("Bitte geben sie die ID ein:");
            int itemId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Bitte geben sie den Namen ein:");
            string itemName = Console.ReadLine();


            WriteToTxt(itemId, itemName);

            WriteToCsv(itemId, itemName);
            
            WriteToXml(itemId, itemName);

            Console.WriteLine("Daten gespeichert");
            Console.ReadLine(); 
        }

        static void WriteToTxt(int itemId, string itemName) //Txt Datai 
        { 
         string dataTxt = $"ItemID: {itemId}, ItemName: {itemName}";
            File.WriteAllText("daten.txt", dataTxt);
        }

        static void WriteToCsv(int itemId, string itemName){ //csv Datai  speichan
        
           StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("ItemID,ItemName");
            csvContent.AppendLine($"{itemId},{itemName}");

            File.WriteAllText("daten.csv", csvContent.ToString());
        }

        static void WriteToXml(int itemId, string itemName) //XML speichan
 {
               XmlDocument xmlDoc = new XmlDocument();
             XmlElement dataElement = xmlDoc.CreateElement("Daten");
            xmlDoc.AppendChild(dataElement);

            XmlElement itemElement = xmlDoc.CreateElement("Item");
            itemElement.SetAttribute("ItemID", itemId.ToString());
             itemElement.InnerText = itemName;
            dataElement.AppendChild(itemElement);

            xmlDoc.Save("daten.xml");
        }
    }
}