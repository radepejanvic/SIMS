using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Model;
using Library.Model;

namespace Library.Configuration
{
    public class ResourceConfigurationJSON<T> : IResourceConfiguration<T>
    {
        private string UserJSON = @"..\..\..\Data\user.json";
        private string PersonJSON = @"..\..\..\Data\person.json";
        private string MembershipJSON = @"..\..\..\Data\membership.json";
        private string MembershipCardJSON = @"..\..\..\Data\membershipCard.json";
        private string BookTitleJSON = @"..\..\..\Data\bookTitle.json";
        private string BookCopyJSON = @"..\..\..\Data\bookCopy.json";
        private string PublisherJSON = @"..\..\..\Data\publisher.json";
        private string AuthorJSON = @"..\..\..\Data\author.json";
        private string LibraryBranchJSON = @"..\..\..\Data\libraryBranch.json";
        private string LoanJSON = @"..\..\..\Data\loan.json";
        private string BookAndAuthorJSON = @"..\..\..\Data\bookAndAuthor.json";


        public string GetResourcePath()
        {
            return typeof(T).Name switch
            {
                nameof(User) => UserJSON,
                nameof(Person) => PersonJSON,
                nameof(Membership) => MembershipJSON,
                nameof(MembershipCard) => MembershipCardJSON,
                nameof(BookTitle) => BookTitleJSON,
                nameof(BookCopy) => BookCopyJSON,
                nameof(Publisher) => PublisherJSON,
                nameof(Author) => AuthorJSON,
                nameof(LibraryBranch) => LibraryBranchJSON,
                nameof(Loan) => LoanJSON,
                nameof(BookAndAuthor) => BookAndAuthorJSON,
                _ => string.Empty
            };

        }
    }
}
