using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using NotificationFeatureProject.Data;
using NotificationFeatureProject.Models;
using NotificationFeatureProject.Repositories.Interfaces;

namespace NotificationFeatureProject.Repositories.Implementaions;

public class PetRepository : IPetRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public PetRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Create(Pet pet)
    {
        _context.Pets.Add(pet);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var pet = _context.Pets.Find(id);
        if (pet is null)
            throw new KeyNotFoundException($"Pet with Id: {id} is not found");

        _context.Pets.Remove(pet);
        _context.SaveChanges();
    }

    public void Edit(Pet pet)
    {
        Pet petFromDb = _context.Pets.FirstOrDefault(x => x.Id == pet.Id)!;

        if (petFromDb is null)
            throw new KeyNotFoundException($"Pet with Id: {pet.Id} is not found!");

        _mapper.Map(pet, petFromDb);

        _context.SaveChanges();
    }

    public List<Pet> GetAllPets()
    {
        return _context.Pets.ToList();
    }

    public Pet GetById(int id)
    {
        return _context.Pets.FirstOrDefault(x => x.Id == id)!;
    }
}