﻿using System;
using System.Collections.Generic;
using OMoney.Data.Repositories;
using OMoney.Data.Repositories.Users;

namespace OMoney.Domain.Services.Validation.Users
{
    public class ActivateUserValidator 
    {
        private readonly IUserRepository _userRepository;
        private readonly string[] _sqlCheckList = { "--", ";--", ";", "/*", "*/", "@@", "@", "char", "nchar", "varchar", "nvarchar", "alter", "begin", "cast", "create",
                                       "cursor", "declare", "delete", "drop", "end", "exec", "execute", "fetch", "insert", "kill", "select", "sys", "sysobjects", "syscolumns",
                                           "table", "update"};
        public ActivateUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<string> Validate(string userId, string code)
        {
            if (userId == null) yield return "userId is null";
            if (code == null) yield return "code is null";
            if (string.IsNullOrWhiteSpace(userId)) yield return "userId is empty";
            if (string.IsNullOrWhiteSpace(code)) yield return "code is empty";
            if (_userRepository.FindById(userId) == null) yield return "userId does not exist";
            if (CheckForSql(userId)) yield return "SQL INJECTION";
            if (CheckForSql(code)) yield return "SQL INJECTION";
        }

        private bool CheckForSql(string param)
        {
            var checkString = param.Replace("'", "''");
            for (var i = 0; i <= _sqlCheckList.Length - 1; i++)
            {
                if ((checkString.IndexOf(_sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
