using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Model.MembershipCardState
{
    public class State
    {
        public MembershipCard MembershipCard;
        public State(MembershipCard membershipCard) 
        {
            MembershipCard = membershipCard;
        }

    }
}
