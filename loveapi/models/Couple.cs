using System;

namespace LoveApi.Models
{
    public class Couple
    {
        public int Id { get; set; }
        public string Person1 { get; set; } = "";
        public string Person2 { get; set; } = "";
        public int Percentage { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
