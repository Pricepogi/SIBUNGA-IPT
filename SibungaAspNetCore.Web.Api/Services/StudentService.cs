using System;
using SibungaAspNetCore.Web.Api.Models;

namespace SibungaAspNetCore.Web.Api.Services
{
    // Simple thread-safe in-memory store for a single student record used for demo/testing
    public class StudentService
    {
        private readonly object _lock = new();
        private Student _student = new Student
        {
            FullName = "John Doe",
            IdNo = "0000",
            Program = "Undeclared",
            BirthDate = null,
            FullTime = true
        };

        public Student Get()
        {
            lock (_lock)
            {
                // return a copy to avoid external mutation
                return new Student
                {
                    FullName = _student.FullName,
                    IdNo = _student.IdNo,
                    Program = _student.Program,
                    BirthDate = _student.BirthDate,
                    FullTime = _student.FullTime
                };
            }
        }

        public void SetFullTime(bool fullTime)
        {
            lock (_lock)
            {
                _student.FullTime = fullTime;
            }
        }

        public void SetIdNo(string idno)
        {
            lock (_lock)
            {
                _student.IdNo = idno ?? string.Empty;
            }
        }

        public void SetProgram(string program)
        {
            lock (_lock)
            {
                _student.Program = program ?? string.Empty;
            }
        }

        public void SetBirthDate(DateOnly? birthDate)
        {
            lock (_lock)
            {
                _student.BirthDate = birthDate;
            }
        }

        public void SetFullName(string fullName)
        {
            lock (_lock)
            {
                _student.FullName = fullName ?? string.Empty;
            }
        }
    }
}
