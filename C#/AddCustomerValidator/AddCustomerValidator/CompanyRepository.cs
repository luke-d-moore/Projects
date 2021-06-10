using AddCustomerValidator.Interfaces;

namespace AddCustomerValidator
{
    public class CompanyRepository : ICompanyRepo
    {
        public Company GetById(int id)
        {
            Company company = null;
            //access the database here and get the data for the company
            company.Name = "test";
            company.Classification = Classification.Gold;
            company.Id = 1;
            return company;
        }
    }
}
