using System;
using Ticket.Application.Interfaces;
using Ticket.Application.Request;
using Xunit;
using Moq;
using Ticket.Integrations.Interfaces;
using Ticket.Domain.Models;

namespace Ticket.IntegrationTest
{
    public  class UserIntegrationTest
    {
        private readonly IApplicationServiceUser _applicationServiceUser;
        private readonly IApplicationServiceAddress _applicationServiceAddress;

        public UserIntegrationTest(IApplicationServiceUser applicationServiceUser,
            IApplicationServiceAddress applicationServiceAddress)
        {
            try
            {
                _applicationServiceUser = applicationServiceUser;
                _applicationServiceAddress = applicationServiceAddress;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
        }

        [Fact]
        public void CreateNewUser()
        {
            try
            {
                RequestUser user = new RequestUser();

                user.Name = "Teste";
                user.BirthDate = DateTime.Now;
                user.Email = "teste@teste.com";
                user.Phone = "(11) 1234-5678";
                user.Address.Add(new RequestAddress() { Category = "Commercial", ZipCode = "08588-420" });

                //Arrange
                Mock<IServiceViaCep> mockViaCep = new Mock<IServiceViaCep>();
                mockViaCep.Setup(x => x.Search(It.IsAny<string>())).Returns(new Address() { ZipCode = "08588-420" });

                var result = _applicationServiceUser.Add(user);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
    }
}
