using PasantiasTW.Models;
using PasantiasTW.Models.Dtos;
using PasantiasTW.Repositories;

namespace PasantiasTW.Services
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _repo;
        public TutorService(ITutorRepository repo)
        {
            _repo = repo;
        }
        public async Task<Tutor> create(CreateTutorDto dto)
        {
            var tutor = new Tutor
            {
                name = dto.name,
                telephone = dto.telephone
            };
            await _repo.create(tutor);
            return tutor;

        }

        public async Task delete(Guid id)
        {
            var delete = await _repo.getById(id);
            if (delete == null) throw new Exception("Tutor not found");
            await _repo.delete(delete);
        }

        public async Task<IEnumerable<Tutor>> getAll()
        {
            return await _repo.getAll();
        }

        public async Task<Tutor?> getById(Guid id)
        {
            return await _repo.getById(id);
        }

        public async Task<Tutor> update(Guid id, UpdateTutorDto dto)
        {
            Tutor? tutor = await _repo.getById(id);
            if (tutor == null) throw new Exception("Tutor not found");
            tutor.name = dto.name;
            tutor.telephone = dto.telephone;
            await _repo.update(tutor);
            return tutor;
        }
    }
}
