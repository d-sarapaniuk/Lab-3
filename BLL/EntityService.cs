using DAL;
using System.ComponentModel;

namespace BLL
{
    public enum FileExtension
        {
            Binary,
            JSON,
            XML
        }
    public class EntityService
    {
        private string filePath = "C:\\Users\\user\\Desktop\\НАУ\\OOP 2\\Laboratory 3\\";
        private EntityContext context;
        public EntityService(string fileName, FileExtension fileExtension) 
        {
            context = new EntityContext(fileName, filePath);
            switch (fileExtension)
            {
                case FileExtension.Binary: context.SetDataProvider(new BinaryProvider<List<Person>>()); break;
                case FileExtension.JSON: context.SetDataProvider(new JSONProvider<List<Person>>()); break;
                case FileExtension.XML: context.SetDataProvider(new XMLProvider<List<Person>>()); break;
            }
            context.GetDataFromFile();
        }
        public List<Person> GetEntities()
        {
            if (context.Entities == null) return new List<Person>();
            return context.Entities;
        }
        public void Add(Person obj)
        {
            context.AddIntoFile(obj);
        }
        public void Remove(Person obj)
        {
            context.RemoveFromFile(obj);                
        }
    }
}