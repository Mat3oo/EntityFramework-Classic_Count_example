using EntityFramework_Classic_Count_example.DALs;
using EntityFramework_Classic_Count_example.DTOs;
using EntityFramework_Classic_Count_example.Models;
using System.Linq;

namespace EntityFramework_Classic_Count_example.Repository
{
    public class ElementRepository
    {
        private readonly TestContext _dbContext;

        public ElementRepository(TestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(ElementDTO element)
        {
            var elementDb = new Element {
                Id = element.Id,
                Active = element.Active,
                Code = element.Code,
                Name = element.Name
            };

            _dbContext.Set<Element>().Add(elementDb);
            _dbContext.SaveChanges();
        }

        public IQueryable<ElementDTO> GetAllElements()
        {
            return _dbContext.Set<Element>().Select(p => new ElementDTO {
                Id = p.Id,
                Value = p.Value,
                Active = p.Active,
                Code = p.Code,
                Name = p.Name
            }).AsQueryable();
        }
    }
}
