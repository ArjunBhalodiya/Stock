using System;
using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using Stock.DataAccess;
using Stock.Models;

namespace Stock.Repositories
{
    /// <summary>
    /// Company detail related database interaction 
    /// </summary>
    public class CompanyDetailRepository : ICompanyDetailRepository, IDisposable
    {
        private StockDataContext data;

        public CompanyDetailRepository()
        {
            data = new StockDataContext();
        }

        /// <summary>
        /// Add Company detail
        /// </summary>
        /// <param name="companyDetail"></param>
        /// <returns></returns>
        public bool Add(CompanyDetailVm companyDetail)
        {
            var companyDetailDm = Mapper.Map<CompanyDetailDm>(companyDetail);
            try
            {
                data.Entry(companyDetailDm).State = EntityState.Added;
                if (data.SaveChanges() > 0)
                    return true;
            }
            catch
            {

            }
            return false;
        }

        /// <summary>
        /// Edit Company detail
        /// </summary>
        /// <param name="companyDetail"></param>
        /// <returns></returns>
        public bool Edit(CompanyDetailVm companyDetail)
        {
            var companyDetailDm = Mapper.Map<CompanyDetailDm>(companyDetail);
            try
            {
                data.Entry(companyDetailDm).State = EntityState.Modified;
                if (data.SaveChanges() > 0)
                    return true;
            }
            catch
            {

            }
            return false;
        }

        /// <summary>
        /// Detele company detail
        /// </summary>
        /// <param name="securityId"></param>
        /// <returns></returns>
        public bool Delete(string securityId)
        {
            var companyDetailVm = Get(securityId);
            if (companyDetailVm == null)
                return false;

            var companyDetailDm = Mapper.Map<CompanyDetailDm>(companyDetailVm);
            try
            {
                data.Entry(companyDetailDm).State = EntityState.Deleted;
                if (data.SaveChanges() > 0)
                    return true;
            }
            catch
            {

            }
            return false;
        }

        /// <summary>
        /// Get company detail based on security ID
        /// </summary>
        /// <param name="securityId"></param>
        /// <returns></returns>
        public CompanyDetailVm Get(string securityId)
        {
            try
            {
                var companyDetailDm = data.CompanyDetails.Find(securityId);
                if (companyDetailDm != null)
                    return Mapper.Map<CompanyDetailVm>(companyDetailDm);
            }
            catch
            {

            }
            return null;
        }

        /// <summary>
        /// Get all companies
        /// </summary>
        /// <returns></returns>
        public List<CompanyDetailVm> Get()
        {
            try
            {
                var companyDetailDm = data.CompanyDetails.ToListAsync().Result;
                if (companyDetailDm != null)
                    return Mapper.Map<List<CompanyDetailVm>>(companyDetailDm);
            }
            catch
            {
            }
            return null;
        }

        public void Dispose()
        {
            if (data != null)
                data.Dispose();
        }
    }
}