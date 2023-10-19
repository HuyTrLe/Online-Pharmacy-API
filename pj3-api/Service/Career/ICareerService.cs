﻿using pj3_api.Model;
using pj3_api.Model.Career;
using pj3_api.Model.User;

namespace pj3_api.Service.User
{
    public interface ICareerService
    {
        Task<IEnumerable<CareerModel>> GetCareer();

        Task<CareerModel> GetCareerByID(CareerGet CareerGet);

        Task<int> InsertCareer(CareerModel CareerModel);
        Task<int> UpdateCareer(CareerModel CareerModel);
        Task<int> DeleteCareer(CareerModel CareerModel);

        Task<IEnumerable<CareerJobModel>> GetCareerJobWithUser(CareerJobGet CareerJobGet);
        Task<int> InsertCareerJob(CareerJobModel CareerJobModel);
        Task<int> UpdateCareerJob(CareerJobModel CareerJobModel);
    }
}
