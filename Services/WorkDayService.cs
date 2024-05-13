using CRM.Db;
using CRM.Models.Entities;
using CRM.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Services
{
    public class WorkDayService
    {
        private WorkDayRepository _repository;

        public WorkDayService(CrmDbContext dbContext)
        {
            _repository = new WorkDayRepository(dbContext);
        }

        public async Task<List<WorkDayEntity>> GetWorkDaysOfUser(int userId)
        {
            return await _repository.GetWorkDaysOfUser(userId);
        }

        public async Task<bool> CreateWorkDay(WorkDayEntity workDay)
        {
            var fixedWorkDay = new WorkDayEntity()
            {
                Count = workDay.Count,
                Day = workDay.Day.ToUniversalTime(),
                Description = workDay.Description,
                UserId = workDay.UserId,
            };
            bool created = await _repository.CreateWorkDay(fixedWorkDay);
            return created;
        }
    }
}
