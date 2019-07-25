using System;
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
        DateTime birthDate
       )
       {
        //    Id = Guid.NewGuid();
           Name = new Name {FirstName = firstName, LastName = lastName};
        //    Email = new Email { EmailAddress = email};
            Email = email;
           Address = new Address {Number = number, Street = street, ZipCode = zipCode, City = city};
           BirthDate = birthDate;
       }
       public Name Name { get; set; }
       public string Email { get; set; }
       public Address Address { get; set; }
       public DateTime BirthDate { get; set; }
    }
}