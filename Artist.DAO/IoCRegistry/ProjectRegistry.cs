using Artist.DAO.Business.Interfaces;
using Artist.DAO.Business.ValueAdded;
using Artist.DAO.Implementations;
using Artist.DAO.Interfaces;
using StructureMap.Configuration.DSL;

namespace Artist.DAO.IoCRegistry
{
    public class ProjectRegistry : Registry
    {
        public ProjectRegistry()
        {
           
            ForRequestedType<IAddressRepository>().TheDefault.Is.OfConcreteType<AddressRepository>();
            ForRequestedType<IAddressService>().TheDefault.Is.OfConcreteType<AddressService>();
            //
            For<ICustomerRepository>().Add<CustomerRepository>();
            For<ICustomerService>().Add<CustomerService>();
            //
            ForRequestedType<IElectronicMailRepository>().TheDefault.Is.OfConcreteType<ElectronicMailRepository>();
            ForRequestedType<IElectronicMailService>().TheDefault.Is.OfConcreteType<ElectronicMailService>();
            //
            ForRequestedType<IOrderDetailRepository>().TheDefault.Is.OfConcreteType<OrderDetailRepository>();
            ForRequestedType<IOrderDetailService>().TheDefault.Is.OfConcreteType<OrderDetailService>();
            //
            ForRequestedType<IOrderRepository>().TheDefault.Is.OfConcreteType<OrderRepository>();
            ForRequestedType<IOrderService>().TheDefault.Is.OfConcreteType<OrderService>();
            //
            ForRequestedType<IProductPricingRepository>().TheDefault.Is.OfConcreteType<ProductPricingRepository>();
            ForRequestedType<IProductPricingService>().TheDefault.Is.OfConcreteType<ProductPricingService>();
            //
            ForRequestedType<IProductRepository>().TheDefault.Is.OfConcreteType<ProductRepository>();
            ForRequestedType<IProductService>().TheDefault.Is.OfConcreteType<ProductService>();          
            //
            ForRequestedType<IPromotionRepository>().TheDefault.Is.OfConcreteType<PromotionRepository>();
            ForRequestedType<IPromotionService>().TheDefault.Is.OfConcreteType<PromotionService>();
            //
            ForRequestedType<ITelephoneRepository>().TheDefault.Is.OfConcreteType<TelephoneRepository>();
            ForRequestedType<ITelephoneService>().TheDefault.Is.OfConcreteType<TelephoneService>();
            For<ITelephoneService>().Add<TelephoneService>();

        }
    }
}