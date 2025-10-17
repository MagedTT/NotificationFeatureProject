using NotificationFeatureProject.Models;

namespace NotificationFeatureProject.Repositories.Interfaces;

public interface IPetRepository
{
    Pet GetById(int id);
    List<Pet> GetAllPets();
    void Create(Pet pet);
    void Edit(Pet pet);
    void Delete(int id);
}