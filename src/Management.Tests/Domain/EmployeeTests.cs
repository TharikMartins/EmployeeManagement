using Management.Domain;
using Shouldly;
using System;
using Xunit;
using Gender = Management.Domain.Enum.Gender;

namespace Management.Tests.Domain
{
   public class EmployeeTests
    {

        [Fact]
        public void SHOULD_THROW_EXCEPTION_ID()
        {
            Should.Throw<ArgumentException>(() => new Employee(0 ,"Felipe", new DateTime(), Gender.Male, "11111111111", "119567890987", "Street one", true, null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void SHOULD_THROW_EXCEPTION_NAME(string name)
        {
            Should.Throw<ArgumentException>(() => new Employee(0, name, new DateTime(), Gender.Male, "75111963511", "119567890987", "Street one", true, null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void SHOULD_THROW_EXCEPTION_ADDRESS(string address)
        {
            Should.Throw<ArgumentNullException>(() => new Employee(2, "Angelina", new DateTime(), Gender.Female, "19111451111", "119567890987", address , true, null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void SHOULD_THROW_EXCEPTION_PHONE_NUMBER(string phoneNumber)
        {
            Should.Throw<ArgumentNullException>(() => new Employee(3, "Steve", new DateTime(), Gender.Male, "11691111111", phoneNumber, "Street 5", true, null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("0000000000000000000000000")]
        [InlineData("123456")]
        public void SHOULD_THROW_EXCEPTION_CPF(string cpf)
        {
            Should.Throw<ArgumentException>(() => new Employee(5, "Suzie", new DateTime(), Gender.Female, cpf, "119567890987", "Street 5", true, null));
        }
    }
}
