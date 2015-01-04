using ServiceStack;
using StudentReports.DTOs;
using StudentReports.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentReports.Services
{
    public class StudentService : Service
    {
        StudentDbRepository repository;

        public StudentService(StudentDbRepository _repository)
        {
            repository = _repository;
        }

        public object Get(StudentRequestDto studentDto)
        {
            var username = this.GetSession().UserName == null ? "" : this.GetSession().UserName.ToTitleCase();

            if (studentDto.Id == default(int))
            {
                return new StudentResponseDto { Students = repository.GetStudents(), Username = username };
            }
            else
            {
                return new StudentResponseDto { Students = new List<Student> { repository.GetStudentById(studentDto.Id) }, Username = username };
            }
        }
    }    

}