using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;

namespace Domain.Service;

public class CompanyDomain : ICompanyDomain
{
    private readonly ICompanyData _companyData;
    
    public CompanyDomain(ICompanyData companyData)
    {
        _companyData = companyData;
    }
    public async Task<Company> GetById(int id)
    {
        var result = await _companyData.GetById(id);
        if (result == null)
            throw new KeyNotFoundException("Company not found");
        return result;
    }

    public async Task<List<Company>> GetByName(Company company)
    {
        var result = await _companyData.GetByName(company);
        if (result == null)
            throw new KeyNotFoundException("Name of Company not found");
        return result;
    }

    public async Task<List<Company>> GetAll()
    {
        var result = await _companyData.GetAll();
        if (result == null)
            throw new KeyNotFoundException("We dont' have registered companies");
        return result;
    }

    public async Task<List<Company>> GetByRuc(Company company)
    {
        var result = await _companyData.GetByRuc(company);
        if (result == null)
            throw new KeyNotFoundException("Ruc not found");
        return result;
    }

    public async Task<bool> Create(Company company)
    {
        try
        {
            var result = await _companyData.GetByRuc(company);

            if (result != null && result.Count == 0)
            {
                return await _companyData.Create(company);
            }

            return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Update(Company company, int id)
    {
        try
        {
            var result = await _companyData.GetByRuc(company);

            if (result != null && result.Count == 0)
            {
                return await _companyData.Update(company, id);
            }

            return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var result = await _companyData.GetById(id);

            if (result != null )
            {
                return await _companyData.Delete(id);
            }

            return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}