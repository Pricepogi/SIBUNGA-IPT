using System;
using SibungaAPI.Models;

namespace SibungaAPI.Services
{
    // Simple in-memory student store for the Blazor app
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
