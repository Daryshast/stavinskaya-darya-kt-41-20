using Microsoft.EntityFrameworkCore;
using stavinskaya_darya_kt_41_20.Data;
using stavinskaya_darya_kt_41_20.Filters.DisciplineFilter;
using stavinskaya_darya_kt_41_20.Models;
using System.Text.RegularExpressions;

namespace stavinskaya_darya_kt_41_20.Interfaces.DisciplineInterfaces
{
    public interface IDisciplineServices
        {
            public Task<Discipline[]> GetDisciplinesByDirectionAsync(DisciplineFilter filter, CancellationToken cancellationToken);
        }

        public class DisciplineServices : IDisciplineServices
    {

            private readonly DbContext _dbContext;

            public DisciplineServices(DisciplineDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public Task<Discipline[]> GetDisciplinesByDirectionAsync(DisciplineFilter filter, CancellationToken cancellationToken = default)
            {
                var grades = _dbContext.Set<Discipline>().Where(d => d.Direction.DirectionName == filter.DirectionName &&
                d.DoesExist == filter.DoesExist).Select(d=> new
                Discipline
                { 
                DisciplineId = d.DisciplineId,
                DisciplineName = d.DisciplineName,
                DoesExist = d.DoesExist,
                DirectionId = d.DirectionId
                }
                ).
                ToArrayAsync(cancellationToken);
                return grades;
            }
        }
    }
