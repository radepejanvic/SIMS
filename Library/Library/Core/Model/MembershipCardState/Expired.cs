using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model.MembershipCardState
{
    public class Expired : State
    {
        public Expired(int membershipCard) : base(membershipCard) { }
    }
}
