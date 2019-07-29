using System;
using System.Collections.Generic;
using System.Linq;
using Arch.Domain.Core;
using Arch.Domain.ValueObjects;

namespace Arch.Domain
{
    public class Customer: Entity
    {
       public Customer() {}
       public Customer(
        string firstName, string lastName,
        string email,
        string number, string street, string zipCode, string city,
        DateTime birthDate)
       {
           Name = new Name {FirstName = firstName, LastName = lastName};
           Email = email;
           Address = new Address {Number = number, Street = street, ZipCode = zipCode, City = city};
           BirthDate = birthDate;
       }
       public Name Name { get; set; }
       public string Email { get; set; }
       public Address Address { get; set; }
       public DateTime BirthDate { get; set; }
       public ICollection<Product> Products {get;set;}

       public void AddProduct(Product product) => 
            Products.Add(product);
       public void AddProducts(IEnumerable<Product> products) 
       {
           foreach(var product in products)
               AddProduct(product);
       }
    }
}