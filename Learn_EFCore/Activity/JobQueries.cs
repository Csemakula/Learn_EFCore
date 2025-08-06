using Learn_EFCore.Data;
using Learn_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Learn_EFCore.Activity
{
    public static class JobQueries
    {
        public static IQueryable<T> GetAllJobs<T>(AppDbContext context, Expression<Func<Job, T>> selector)
        {
            var today = DateTime.UtcNow;

            return context.Jobs
            .Include(j => j.AssignedTo)
            .Select(selector);
        }

        public static IQueryable<T> GetJobsByStatus<T>(AppDbContext context, JobStatus status, Expression<Func<Job, T>> selector)
        {
            return context.Jobs
            .Include(j => j.AssignedTo)
            .Where(j => j.Status == status)
            .Select(selector);
        }

        public static IQueryable<T> GetJobsByEmployee<T>(AppDbContext context, Guid employeeId, Expression<Func<Job, T>> selector)
        {
            return context.Jobs
            .Include(j => j.AssignedTo)
            .Where(j => j.AssignedToId == employeeId)
            .Select(selector);
        }

        public static IQueryable<T> GetOverdueJobs<T>(AppDbContext context, Expression<Func<Job, T>> selector)
        {
            var today = DateTime.UtcNow;

            return context.Jobs
            .Include(j => j.AssignedTo)
            .Where(j => j.DueDate != null && j.DueDate < today && j.Status != JobStatus.Completed)
            .Select(selector);
        }

        public static IQueryable<T> GetUnassignedJobs<T>(AppDbContext context, Expression<Func<Job, T>> selector)
        {
            return context.Jobs
            .Where(j => j.AssignedToId == null)
            .Select(selector);
        }

        public static IQueryable<T> GetTopEmployeesByHours<T>(AppDbContext context, Expression<Func<IGrouping<string, WorkEntry>, T>> selector, int count = 10)
        {
            return context.WorkEntries
                .GroupBy(w => w.Employee.Name)
                .Select(selector)
                .OrderByDescending(x => (x)) // or replace with strongly typed property if using DTO
                .Take(count);
        }

        public static IQueryable<T> GetRecentJobs<T>(AppDbContext context, Expression<Func<Job, T>> selector, int days = 7)
        {
            var since = DateTime.UtcNow.AddDays(-days);

            return context.Jobs
                .Include(j => j.AssignedTo)
                .Where(j => j.CreatedAt >= since)
                .Select(selector);
        }

        public static IQueryable<T> GetAverageHoursPerJob<T>(AppDbContext context, Expression<Func<IGrouping<string, WorkEntry>, T>> selector)
        {
            return context.WorkEntries
                .GroupBy(w => w.Job.Title)
                .Select(selector)
                .OrderByDescending(x => EF.Property<decimal>(x, "AvgHours"));
        }
    }

}
