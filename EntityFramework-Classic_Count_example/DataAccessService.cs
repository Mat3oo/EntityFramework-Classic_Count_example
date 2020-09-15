using EntityFramework_Classic_Count_example.DALs;
using EntityFramework_Classic_Count_example.DTOs;
using EntityFramework_Classic_Count_example.Repository;
using System.Linq;

namespace EntityFramework_Classic_Count_example
{
    public class DataAccessService
    {
        private readonly ElementRepository _elementRepository;

        public DataAccessService(TestContext testContext)
        {
            _elementRepository = new ElementRepository(testContext);

            if (_elementRepository.GetAllElements().Count() < 6)
            {
                _elementRepository.Add(new ElementDTO { Code = "Test1", Name = "Name 1" });
                _elementRepository.Add(new ElementDTO { Code = "Test2", Name = "Name 2" });
                _elementRepository.Add(new ElementDTO { Code = "Test3", Name = "Name 3" });
                _elementRepository.Add(new ElementDTO { Code = "Test4", Name = "test", Active = true });
                _elementRepository.Add(new ElementDTO { Code = "Test5", Name = "test", Active = false });
                _elementRepository.Add(new ElementDTO { Code = "Test6", Name = "Name 6", Active = true });
            }
        }

        public IQueryable<ElementDTO> GetAllElements()
        {
            return _elementRepository.GetAllElements();
        }
    }
}
