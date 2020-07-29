﻿using CoreLMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreLMS.Persistence
{
    public partial class AppDbContext
    {
        DbSet<Course> Courses { get; set; }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            EntityEntry<Course> courseEntry = await this.Courses.AddAsync(course);
            await this.SaveChangesAsync();
            return courseEntry.Entity;
        }

        public async Task<Course> SelectCourseByIdAsync(int id) => await this.Courses.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<Course>> SelectCoursesAsync()
        {
            return await this.Courses.ToListAsync();
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
            EntityEntry<Course> courseEntry = this.Courses.Update(course);
            await this.SaveChangesAsync();
            return courseEntry.Entity;
        }
        public async Task<Course> DeleteCourseAsync(Course course)
        {
            EntityEntry<Course> courseEntry = this.Courses.Remove(course);
            await this.SaveChangesAsync();
            return courseEntry.Entity;
        }
    }
}
