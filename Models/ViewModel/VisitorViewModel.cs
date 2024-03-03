using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.web.Models
{
    public class VisitorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }

    }
}

