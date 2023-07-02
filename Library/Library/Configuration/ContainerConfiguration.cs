using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository;
using Library.Repository.Interface;
using Library.Serializer;
using Library.Service.TehnicalService;
using Library.Core.TehnicalService.Interface;
using Library.Core.Model;
using Library.Core.Repository;
using Library.Core.Repository.Interface;
using Library.GUI.Helpers.Generator;
using Library.Core.Service;

namespace Library.Configuration
{
    public static class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UserGenerator>().As<IUserGenerator>();
            builder.RegisterType<BookGenerator>().As<IBookGenerator>();

            // Here is the template cnofiguration for a single model type (next 4 lines).
            builder.RegisterType<ResourceConfigurationJSON<User>>().As<IResourceConfiguration<User>>();
            builder.RegisterType<SerializerJSON<User>>().As<ISerializer<User>>();
            builder.RegisterType<CRUDRepository<User>>().As<ICRUDRepository<User>>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            builder.RegisterType<ResourceConfigurationJSON<Person>>().As<IResourceConfiguration<Person>>();
            builder.RegisterType<SerializerJSON<Person>>().As<ISerializer<Person>>();
            builder.RegisterType<CRUDRepository<Person>>().As<ICRUDRepository<Person>>();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();

            builder.RegisterType<ResourceConfigurationJSON<Author>>().As<IResourceConfiguration<Author>>();
            builder.RegisterType<SerializerJSON<Author>>().As<ISerializer<Author>>();
            builder.RegisterType<CRUDRepository<Author>>().As<ICRUDRepository<Author>>();
            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();

            builder.RegisterType<ResourceConfigurationJSON<BookAndAuthor>>().As<IResourceConfiguration<BookAndAuthor>>();
            builder.RegisterType<SerializerJSON<BookAndAuthor>>().As<ISerializer<BookAndAuthor>>();
            builder.RegisterType<CRUDRepository<BookAndAuthor>>().As<ICRUDRepository<BookAndAuthor>>();
            builder.RegisterType<BookAndAuthorRepository>().As<IBookAndAuthorRepository>();

            builder.RegisterType<ResourceConfigurationJSON<BookCopy>>().As<IResourceConfiguration<BookCopy>>();
            builder.RegisterType<SerializerJSON<BookCopy>>().As<ISerializer<BookCopy>>();
            builder.RegisterType<CRUDRepository<BookCopy>>().As<ICRUDRepository<BookCopy>>();
            builder.RegisterType<BookCopyRepository>().As<IBookCopyRepository>();

            builder.RegisterType<ResourceConfigurationJSON<BookTitle>>().As<IResourceConfiguration<BookTitle>>();
            builder.RegisterType<SerializerJSON<BookTitle>>().As<ISerializer<BookTitle>>();
            builder.RegisterType<CRUDRepository<BookTitle>>().As<ICRUDRepository<BookTitle>>();
            builder.RegisterType<BookTitleRepository>().As<IBookTitleRepository>();

            //builder.RegisterType<ResourceConfigurationJSON<InventoryBook>>().As<IResourceConfiguration<InventoryBook>>();
            //builder.RegisterType<SerializerJSON<InventoryBook>>().As<ISerializer<InventoryBook>>();
            //builder.RegisterType<CRUDRepository<InventoryBook>>().As<ICRUDRepository<InventoryBook>>();
            //builder.RegisterType<InventoryBookRepository>().As<IInventoryBookRepository>();

            //builder.RegisterType<ResourceConfigurationJSON<LibraryBranch>>().As<IResourceConfiguration<LibraryBranch>>();
            //builder.RegisterType<SerializerJSON<LibraryBranch>>().As<ISerializer<LibraryBranch>>();
            //builder.RegisterType<CRUDRepository<LibraryBranch>>().As<ICRUDRepository<LibraryBranch>>();
            //builder.RegisterType<LibraryBranchRepository>().As<ILibraryBranchRepository>();

            builder.RegisterType<ResourceConfigurationJSON<Loan>>().As<IResourceConfiguration<Loan>>();
            builder.RegisterType<SerializerJSON<Loan>>().As<ISerializer<Loan>>();
            builder.RegisterType<CRUDRepository<Loan>>().As<ICRUDRepository<Loan>>();
            builder.RegisterType<LoanRepository>().As<ILoanRepository>();

            builder.RegisterType<ResourceConfigurationJSON<Membership>>().As<IResourceConfiguration<Membership>>();
            builder.RegisterType<SerializerJSON<Membership>>().As<ISerializer<Membership>>();
            builder.RegisterType<CRUDRepository<Membership>>().As<ICRUDRepository<Membership>>();
            builder.RegisterType<MembershipRepository>().As<IMembershipRepository>();

            builder.RegisterType<ResourceConfigurationJSON<MembershipCard>>().As<IResourceConfiguration<MembershipCard>>();
            builder.RegisterType<SerializerJSON<MembershipCard>>().As<ISerializer<MembershipCard>>();
            builder.RegisterType<CRUDRepository<MembershipCard>>().As<ICRUDRepository<MembershipCard>>();
            builder.RegisterType<MembershipCardRepository>().As<IMembershipCardRepository>();

            //builder.RegisterType<ResourceConfigurationJSON<Payment>>().As<IResourceConfiguration<Payment>>();
            //builder.RegisterType<SerializerJSON<Payment>>().As<ISerializer<Payment>>();
            //builder.RegisterType<CRUDRepository<Payment>>().As<ICRUDRepository<Payment>>();
            //builder.RegisterType<PaymentRepository>().As<IPaymentRepository>();

            builder.RegisterType<ResourceConfigurationJSON<Publisher>>().As<IResourceConfiguration<Publisher>>();
            builder.RegisterType<SerializerJSON<Publisher>>().As<ISerializer<Publisher>>();
            builder.RegisterType<CRUDRepository<Publisher>>().As<ICRUDRepository<Publisher>>();
            builder.RegisterType<PublisherRepository>().As<IPublisherRepository>();

            builder.RegisterType<LoginService>().As<ILoginService>();
            builder.RegisterType<MembersService>().As<IMembersService>();
            builder.RegisterType<LoaningService>().As<ILoaningService>();

            return builder.Build();
        }
    }
}
