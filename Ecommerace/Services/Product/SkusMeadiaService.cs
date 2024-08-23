using Ecommerace.Models;
using Ecommerace.Repositories.Product;

namespace Ecommerace.Services.Product
{
    public class SkusMeadiaService : ISkusMeadiaService
    {
        ISkuMediaRepository MeadiaRepository ;
        public SkusMeadiaService(ISkuMediaRepository mediaRepository ) 
        {
            this.MeadiaRepository = mediaRepository;
        }
        public void Create(SkuMedia entity)
        {
            MeadiaRepository.Create( entity );
            MeadiaRepository.Save();
        }

        public void Delete(int id)
        {
            MeadiaRepository.Delete( id );
            MeadiaRepository.Save();
        }

        public List<SkuMedia> GetAll()
        {
          return  MeadiaRepository.GetAll();
        }

        public SkuMedia GetById(int id)
        {
            return MeadiaRepository.GetById( id );
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(SkuMedia entity)
        {
            MeadiaRepository.Update( entity );
            MeadiaRepository.Save();
        }
    }
}
