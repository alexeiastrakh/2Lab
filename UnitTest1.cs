using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceWebApplication.Models;
using SpaceWebApplication.Controllers;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBMissionContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-DMI7F36; Database=DBMissionAPI; Trusted_Connection=True; MultipleActiveResultSets=true");

            var controller = new CitiesController(new DBMissionContext(optionsBuilder.Options));

            // Act
            var result = await controller.GetCity();

            // Assert
            Assert.Contains(result.Value, c => c.Name.Equals("Paris"));

        }
    }
}