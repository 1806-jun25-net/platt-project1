using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace MainLibrary.Models
{
    public class Serializer
    {
  

        public static void SerializeToFile(string fileName, List<Order> listoforders)
        {
            var serializer = new XmlSerializer(typeof(List<Order>));
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);
                serializer.Serialize(fileStream, listoforders);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine($"Path {fileName} was too long! {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Some other error with file I/O: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
               throw; // re-throws the same exception
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Dispose();
                }
            }
        }

        public static List<Order> DeserializeFromFile(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Order>));


            //we CAN do try/finally like this, but the using statement is easier
           FileStream fileStream = null;
                try
                {
                    fileStream = new FileStream(fileName, FileMode.Open);

                    var result = (List<Order>)serializer.Deserialize(fileStream);
                    return result;
                }
                finally
                {
                    fileStream.Dispose();
                }

                //using (var memoryStream = new MemoryStream())
                //{
                //    using (var fileStream = new FileStream(fileName, FileMode.Open))
                //    {
                //        fileStream.CopyToAsync(memoryStream);
                //    }
                //    memoryStream.Position = 0; // reset "cursor" of stream to beginning
                //    return (List<Order>)serializer.Deserialize(memoryStream);
                //}
                }
    }
}
