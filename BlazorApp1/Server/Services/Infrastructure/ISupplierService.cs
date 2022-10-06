using BlazorApp1.Shared.DTO;

namespace BlazorApp1.Server.Services.Infrastructure
{
    public interface ISupplierService
    {
        public Task<List<SupplierDTO>> GetSuppliers();

        public Task<SupplierDTO> CreateSupplier(SupplierDTO Order);

        public Task<SupplierDTO> UpdateSupplier(SupplierDTO Order);

        public Task DeleteSupplier(int SupplierId);

        public Task<SupplierDTO> GetSupplierById(int Id);
    }
}
