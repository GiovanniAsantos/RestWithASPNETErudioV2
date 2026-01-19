using FluentAssertions;
using RestWithASPNET10Erudio.Rest.Data.Converter.Impl;
using RestWithASPNET10Erudio.Rest.Data.DTO.V2;
using RestWithASPNET10Erudio.Rest.Model;

namespace RestWithASPNET10Erudio.Test;

public class PersonConverterTests
{
    private readonly PersonConverter _converter;

    public PersonConverterTests()
    {
        _converter = new PersonConverter();
    }

    // PersonDTO to Person conversion tests
    [Fact]
    public void Parse_ShouldConvertPersonDTOToPerson()
    {
        // Arrange: prepare the data, objects and dependencies required for the test
        var dto = new PersonDTO()
        {
            Id = 1,
            FirstName = "Mahatma",
            LastName = "Gandhi",
            Address = "Porbandar - India",
            Gender = "Male",
            BirthDay = new DateTime(1869, 10, 2),
        };

        var expectedPerson = new Person()
        {
            Id = 1,
            FirstName = "Mahatma",
            LastName = "Gandhi",
            Address = "Porbandar - India",
            Gender = "Male",
        };

        // Act: execute the method being tested
        var person = _converter.Parse(dto);

        // Assert: verify that the method behaved as expected
        person.Should().NotBeNull();
        person.Id.Should().Be(expectedPerson.Id);
        person.FirstName.Should().Be(expectedPerson.FirstName);
        person.LastName.Should().Be(expectedPerson.LastName);
        person.Address.Should().Be(expectedPerson.Address);
        person.Gender.Should().Be(expectedPerson.Gender);
        person.Should().BeEquivalentTo(expectedPerson);
    }

    [Fact]
    public void Parse_NullPersonDTOShouldReturnNull()
    {
        PersonDTO dto = null;
        var person = _converter.Parse(dto);
        person.Should().BeNull();
    }

    // Person to PersonDTO conversion tests
    [Fact]
    public void Parse_ShouldConvertPersonToPersonDTO()
    {
        // Arrange: prepare the data, objects and dependencies required for the test
        var entity = new Person()
        {
            Id = 1,
            FirstName = "Mahatma",
            LastName = "Gandhi",
            Address = "Porbandar - India",
            Gender = "Male",
        };

        var expectedPerson = new PersonDTO()
        {
            Id = 1,
            FirstName = "Mahatma",
            LastName = "Gandhi",
            Address = "Porbandar - India",
            Gender = "Male",
            BirthDay = new DateTime(1869, 10, 2),
        };

        // Act: execute the method being tested
        var person = _converter.Parse(entity);

        // Assert: verify that the method behaved as expected
        person.Should().NotBeNull();
        person.Id.Should().Be(expectedPerson.Id);
        person.FirstName.Should().Be(expectedPerson.FirstName);
        person.LastName.Should().Be(expectedPerson.LastName);
        person.Address.Should().Be(expectedPerson.Address);
        person.Gender.Should().Be(expectedPerson.Gender);
        person.Should().BeEquivalentTo(expectedPerson, options => options.Excluding(person => person.BirthDay));
        person.BirthDay.Should().NotBeNull();
    }

    [Fact]
    public void Parse_NullPersonShouldReturnNull()
    {
        Person dto = null;
        var person = _converter.Parse(dto);
        person.Should().BeNull();
    }

    [Fact]
    public void ParseList_ShouldConvertPersonDTOListToPersonList()
    {
        // Arrange
        var dtoList = new List<PersonDTO>
        {
            new PersonDTO
            {
                Id = 1,
                FirstName = "Mahatma",
                LastName = "Gandhi",
                Address = "Porbandar - India",
                Gender = "Male",
                BirthDay = new DateTime(1869, 10, 2),
            },

            new PersonDTO
            {
                Id = 2,
                FirstName = "Martin",
                LastName = "Luther King",
                Address = "Atlanta - USA",
                Gender = "Male",
                BirthDay = new DateTime(1929, 1, 15),
            }
        };

        // Act
        var personList = _converter.ParseList(dtoList);

        // Assert
        personList.Should().NotBeNull();
        personList.Should().HaveCount(2);
        personList[0].Should().BeEquivalentTo(new Person
        {
            Id = 1,
            FirstName = "Mahatma",
            LastName = "Gandhi",
            Address = "Porbandar - India",
            Gender = "Male",
            // BirthDay = new DateTime(1869, 10, 2),
        });
        personList[1].Should().BeEquivalentTo(new Person
        {
            Id = 2,
            FirstName = "Martin",
            LastName = "Luther King",
            Address = "Atlanta - USA",
            Gender = "Male",
            // BirthDay = new DateTime(1929, 1, 15),
        });
        personList[0].FirstName.Should().Be("Mahatma");
        personList[1].FirstName.Should().Be("Martin");
        personList[0].LastName.Should().Be("Gandhi");
        personList[1].LastName.Should().Be("Luther King");
        personList[0].Address.Should().Be("Porbandar - India");
        personList[1].Address.Should().Be("Atlanta - USA");
        personList[0].Gender.Should().Be("Male");
        personList[1].Gender.Should().Be("Male");
    }
    
    [Fact]
    public void ParseList_NullListPersonShouldReturnNull()
    {
        List<PersonDTO> dto = null;
        var listPerson = _converter.ParseList(dto);
        listPerson.Should().BeNull();
    }
};