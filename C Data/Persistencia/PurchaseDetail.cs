namespace Data.Persistencia;

public class PurchaseDetail
{
     private readonly AppDbContext _appDbContext;
    
    public CompanyData(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<Company> GetById(int id)
    {
        return await _appDbContext.Companies.Where(c => c.Id == id && c.IsActive == true).FirstOrDefaultAsync();
    }

    public async Task<List<Company>> GetByName(Company company)
    {
        return await _appDbContext.Companies.Where(c => c.Name.Contains(company.Name)
                                                       && c.IsActive == true).ToListAsync();
    }

    public async Task<List<Company>> GetAll()
    {
        return await _appDbContext.Companies.Where(c => c.IsActive == true).ToListAsync();
    }

    public async Task<List<Company>> GetByRuc(Company company)
    {
        return await _appDbContext.Companies.Where(c => c.Ruc.Contains(company.Ruc)
                                                       && c.IsActive == true).ToListAsync();
    }

    public async Task<bool> Create(Company company)
    {
        try
        {
            _appDbContext.Companies.Add(company);
            await _appDbContext.SaveChangesAsync();

            return true;
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
            var companyUpdated = _appDbContext.Companies.Where(c => c.Id == id).FirstOrDefault();

            companyUpdated.Name = company.Name;
            companyUpdated.Mail = company.Mail;
            companyUpdated.Description = company.Description;
            companyUpdated.Ruc = company.Ruc;
            companyUpdated.Phone = company.Phone;
            companyUpdated.Address = company.Address;
            companyUpdated.ProfilePicture = company.ProfilePicture;
            companyUpdated.DateUpdated = DateTime.Now;

            _appDbContext.Companies.Update(companyUpdated);
            await _appDbContext.SaveChangesAsync();
            return true;
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
            var companyDeleted = _appDbContext.Companies.Where(c => c.Id == id).FirstOrDefault();
            
            companyDeleted.IsActive = false;
            companyDeleted.DateUpdated = DateTime.Now;

            _appDbContext.Companies.Update(companyDeleted);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}