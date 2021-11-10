using System;
using System.Collections.Generic;
using Ticket.Domain.Models;
using Xunit;

namespace Ticket.UnitTest
{
    public class UserTest
    {
        [Fact]
        public void NameInvalid()
        {
            User user = new User();

            user.Name =  String.Empty;
            user.Email = "teste@teste.com.br";
            user.BirthDate = DateTime.Now;
            user.Phone = "(11) 1234-5678";
            user.Address = new List<Address>();

            try
            {
                user.Validate(user);
            }
            catch (Exception ex)
            {

                Assert.Contains("Name is required", ex.Message);
            }
                     
        }

        [Fact]
        public void EmailInvalid()
        {
            User user = new User();

            user.Name = "Teste";
            user.Email = "teste.com.br";
            user.BirthDate = DateTime.Now;
            user.Phone = "(11) 1234-5678";
            user.Address = new List<Address>();

            try
            {
                user.Validate(user);
            }
            catch (Exception ex)
            {

                Assert.Contains("A valid email is required", ex.Message);
            }
        }

        [Fact]
        public void EmailNotFound()
        {
            User user = new User();

            user.Name = "Teste";
            user.Email = String.Empty;
            user.BirthDate = DateTime.Now;
            user.Phone = "(11) 1234-5678";
            user.Address = new List<Address>();

            try
            {
                user.Validate(user);
            }
            catch (Exception ex)
            {

                Assert.Contains("Email address is required", ex.Message);
            }
        }
    }
}
