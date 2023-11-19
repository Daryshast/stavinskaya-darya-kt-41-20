using Microsoft.EntityFrameworkCore;
using stavinskaya_darya_kt_41_20.Data;
using stavinskaya_darya_kt_41_20.Filters.DisciplineFilter;
using stavinskaya_darya_kt_41_20.Interfaces.DisciplineInterfaces;
using stavinskaya_darya_kt_41_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace stavinskaya_darya_kt_41_20.Tests
{
    public class DisciplineIntegrationTest
    {

        public readonly DbContextOptions<DisciplineDbContext> _dbContextOptions;

        public DisciplineIntegrationTest()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DisciplineDbContext>()
                .UseInMemoryDatabase(databaseName: "student2")
                .Options;
        }
        [Fact]
        public async Task GetDisciplinesAsync_KT4120_TwoObjects()
        {
            // Arrange
            var ctx = new DisciplineDbContext(_dbContextOptions);
            var disciplineServices = new DisciplineServices(ctx);
            var disc = new List<Discipline>
            {
                new Discipline
                {
                    DisciplineId = 1,
                    DisciplineName = "Проектный практикум",
                    DoesExist = true,
                    DirectionId = 1
                },
                new Discipline
                {
                    DisciplineId = 2,
                    DisciplineName = "Проектирование информационных систем",
                    DoesExist = true,
                    DirectionId = 1
                },
                new Discipline
                {
                    DisciplineId = 3,
                    DisciplineName = "Философия",
                    DoesExist = true,
                    DirectionId = 2
                },
            };
            await ctx.Set<Discipline>().AddRangeAsync(disc);

            var dir = new List<Direction>
            {
                new Direction
                {
                    DirectionId = 1,
                    DirectionName = "Техническое"
                },
                new Direction
                {
                    DirectionId = 2,
                    DirectionName = "Гуманитарное"
                }
            };
            await ctx.Set<Direction>().AddRangeAsync(dir);

            await ctx.SaveChangesAsync();

            var filter = new DisciplineFilter
            {
                DirectionName = "Техническое",
                DoesExist = true
            };
            var studentsResult = await disciplineServices.GetDisciplinesByDirectionAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(2, studentsResult.Length);
        }
    }
}
