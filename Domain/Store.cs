using System;

namespace Domain
{
    public class Store
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
    }
}