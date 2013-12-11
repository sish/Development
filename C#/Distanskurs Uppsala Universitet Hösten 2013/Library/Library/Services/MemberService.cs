using Library.DomainObjects;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Library.Services
{
    public class MemberService : IService
    {
        /// <summary>
        /// Parameter for accessing the Member Repository.
        /// </summary>
        private MemberRepository memberRepository;

        static public string LBX_LOANS_BY_DATE = "Loans by date";
        static public string LBX_LOANS_BY_DATE_DESC = "Loans by date, latest first";
        static public string LBX_AVAILABLE_BOOKS = "Available Books for Loan";
        static public string LBX_CURRENT_LOANS = "Current Loans";

        /// <summary>
        /// Parameter holding regexp pattern for SSN (swedish).
        /// </summary>
        private const string SSN_PATTERN = "(1[0-9]{3}|2[0-9]{3})(1[0-2]|0[1-9])([0-3][0-9])-([0-9]{4})";

        /// <summary>
        /// Constructor
        /// </summary>
        public MemberService()
        {
            memberRepository = RepositoryFactory.Members;
        }
        
        /// <summary>
        /// Event property triggered whenever a member change is made in the database.
        /// </summary>
        public event EventHandler Updated;

        /// <summary>
        /// Method to get all members in database.
        /// </summary>
        /// <returns>IEnumerable&lt;Member&gt;</returns>
        public IEnumerable<Member> GetMembers()
        {
            return memberRepository.All().
                OrderBy(member => member.Name).
                ThenBy(member => member.PersonalID).
                ToList();
        }

        /// <summary>
        /// Method to get a filtered list of Members from name.
        /// </summary>
        /// <param name="text">string to look for, at least 3 chars otherwise the whole list is returned</param>
        /// <returns>IEnumerable&lt;Member&gt;</returns>
        public IEnumerable<Member> NameContainsIgnoreCase(string text)
        {
            IEnumerable<Member> retValue = memberRepository.All();
            if (3 <= text.Length)
            {
                retValue = retValue.
                    Where(member => member.Name.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) >= 0).
                    ToList();
            }
            return retValue;
        }

        /// <summary>
        /// Method to add a member to the database.
        /// </summary>
        /// <param name="member">Member to add</param>
        public void AddMember(Member member)
        {
            string error = string.Empty;
            if (3 > member.Name.Length)
            {
               throw new ArgumentException("Name must at least be 3 characters long.");
            }
            else if (true != ValidateSSN(member.PersonalID, out error))
            {
                throw new ArgumentException(error);
            }
            memberRepository.Add(member);
            Updated.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Method to validate a social sercurity number.
        /// </summary>
        /// <param name="ssn">string of the social sercurity number in format YYYYMMDD-NNNN</param>
        /// <param name="errortext">error message if validation fails. otherwise empty string.</param>
        /// <returns>bool</returns>
        public bool ValidateSSN(string ssn, out string errortext)
        {
            Regex rgx = new Regex(SSN_PATTERN, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(ssn);
            errortext = string.Empty;
            if (matches.Count == 0)
            {
                errortext = "Invalid SSN number, expected format is: YYYYMMDD-NNNN";
            }
            foreach (Match match in matches)
            {
                if (match.Groups.Count < 3)
                {
                    errortext = "Unable to find year, month or day in SSN.";
                    break;
                }
                DateTime CheckSSN = new DateTime(int.Parse(match.Groups[1].Value), // year
                    int.Parse(match.Groups[2].Value), // month
                    int.Parse(match.Groups[3].Value)); // day
                if (DateTime.Now < CheckSSN)
                {
                    errortext = "You have to be born to have a SSN.";
                    break;
                }
            }
            return (0 == errortext.Length);
        }

        /// <summary>
        /// Method to get selected filters for second listbox.
        /// </summary>
        /// <returns>List&lt;string&gt;</returns>
        public List<string> GetListBoxItems()
        {
            List<string> retValue = new List<string>();
            retValue.Add(LBX_LOANS_BY_DATE);
            retValue.Add(LBX_LOANS_BY_DATE_DESC);
            retValue.Add(LBX_AVAILABLE_BOOKS);
            retValue.Add(LBX_CURRENT_LOANS);
            return retValue.OrderBy(str => str).ToList();
        }

        /// <summary>
        /// Method to edit an existing member.
        /// </summary>
        /// <param name="member">Member to edit with edited values.</param>
        public void EditMember(Member member)
        {
            if (null == memberRepository.Find(member.ID))
            {
                throw new ArgumentException("EditMember received member with id " + member.ID + " that is unknown to the database.");
            }
            memberRepository.Edit(member);
            Updated.Invoke(this, new EventArgs());
        }

    }
}
