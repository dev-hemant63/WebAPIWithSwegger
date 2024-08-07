﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.AppCode.Interface;
using WebAPI.Models;

namespace WebAPI.AppCode.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IHellper _helper;
        public EmployeeService(IHellper hellper)
        {
            _helper = hellper;
        }
        public async Task<IEnumerable<Dpartment>> GetDepartment()
        {
            string sp = "select * from Master_Department";
            var res = await _helper.GetAllAsync<Dpartment>(sp,null);
            return res;
        }
        public async Task<Response> AddAsync(Employee req)
        {
            var res = new Response
            {
                Statuscode = -1,
                Msg = "TempError"
            };
            string sp = string.Empty;
            if (req.Id == 0)
            {
                sp = @"insert into tbl_Employee(FirstName,LastName,Qualification,Addess,Salary,Department,EntryDate)
                            values(@FirstName,@LastName,@Qualification,@Addess,@Salary,@Department,GETDATE())";
            }
            else
            {
                sp = @"Update tbl_Employee set FirstName = @FirstName , LastName = @LastName,Qualification=@Qualification
                        ,Addess = @Addess,Salary=@Salary,Department=@Department,ModifyDate=GETDATE() where Id =@Id";
            }
            var i = await _helper.ExecuteProcAsync<int>(sp, new
            {
                req.Id,
                req.FirstName,
                req.LastName,
                req.Qualification,
                req.Addess,
                req.Salary,
                req.Department
            });
            if(i == 1)
            {
                res.Statuscode = 1;
                res.Msg = "Success";
            }
            return res;
        }
        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            string sp = "select * from tbl_Employee";
            var res = await _helper.GetAllAsync<Employee>(sp, null);
            return res;
        }
        public async Task<Employee> GetEmployeeById(int Id)
        {
            string sp = "select * from tbl_Employee where Id = @Id";
            var res = await _helper.GetAsync<Employee>(sp, new { Id });
            return res;
        }
        public async Task<Response> Delete(int Id)
        {
            var res = new Response
            {
                Statuscode = -1,
                Msg = "TempError"
            };
            string sp = "Delete from tbl_Employee where Id = @Id";
            var i = await _helper.ExecuteProcAsync<int>(sp, new
            {
                Id
            });
            if(i == 1)
            {
                res.Statuscode = 1;
                res.Msg = "Success";
            }
            return res;
        }
        public async Task<GetNewsDB> GetNews()
        {
            string sp = "select * from tbl_News";
            var res = await _helper.GetAllAsync<GetNewsDB>(sp, null);
            return res.FirstOrDefault();
        }
        public async Task<Response> AddNews(GetNewsDB req)
        {
            var res = new Response
            {
                Statuscode = -1,
                Msg = "TempError"
            };
            string sp = @"insert into tbl_News(Request,Resnponse)
                            values(@Request,@Resnponse)";
            var i = await _helper.ExecuteProcAsync<int>(sp, new
            {
                req.Request,
                req.Resnponse,
            });
            if (i == 1)
            {
                res.Statuscode = 1;
                res.Msg = "Success";
            }
            return res;
        }
    }
}
