﻿using DemoShared.Entities;

namespace DemoProject.Repositories
{
    public interface ICarTypeRepository
    {
        Task<IEnumerable<CarType>> GetAllAsync();
    }
}