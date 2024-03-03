using System;

namespace WebApp.web.Models
{
    public class Product
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string? Color { get; set; }
        public DateTime? PublishDate{ get; set; }
        public bool IsPublish { get; set; }
        public string Expire { get; set; }
        public string? Describtion { get; set; }
    }
}
