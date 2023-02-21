﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using CountryViewer.DataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace CountryViewer.DataAccess.DataContext
{
    public partial class ApplicationDbContext
    {
        private IApplicationDbContextProcedures _procedures;

        public virtual IApplicationDbContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new ApplicationDbContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IApplicationDbContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GetContinentWithCountryCountResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<GetCountriesByContinentResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<SearchCountryByNameResult>().HasNoKey().ToView(null);
        }
    }

    public partial class ApplicationDbContextProcedures : IApplicationDbContextProcedures
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDbContextProcedures(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<List<GetContinentWithCountryCountResult>> GetContinentWithCountryCountAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetContinentWithCountryCountResult>("EXEC @returnValue = [dbo].[GetContinentWithCountryCount]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<GetCountriesByContinentResult>> GetCountriesByContinentAsync(string ContinentName, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "ContinentName",
                    Size = 100,
                    Value = ContinentName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<GetCountriesByContinentResult>("EXEC @returnValue = [dbo].[GetCountriesByContinent] @ContinentName", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<SearchCountryByNameResult>> SearchCountryByNameAsync(string NameSearchText, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "NameSearchText",
                    Size = 100,
                    Value = NameSearchText ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<SearchCountryByNameResult>("EXEC @returnValue = [dbo].[SearchCountryByName] @NameSearchText", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}