using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart.MFB.ERP.Common.Core.Entities;
using Smart.MFB.ERP.Data.Core.Contract;
using Smart.MFB.ERP.Data.Core.Contract.Seed;

namespace Smart.MFB.ERP.Data.Core
{
    [Export(typeof(ISeedData))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class SeedData : ISeedData
    {
        private CoreContext _context;
        public void Execute(string mode)
        {
            _context = new CoreContext();

            BuildGroupData();
            //BuildGroupRoleData();
            BuildCountryData();
            BuildStateData();
            BuildCityData();
            BuildLanguageData();
            BuildReligionData();
            BuildThemeData();

        }
        void BuildThemeData()
        {
            if (!_context.ThemeSet.Any())
            {
                _context.ThemeSet.Add(
                    new Theme()
                    {
                        Code = "smart-style-2",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );
                _context.SaveChanges();
            }
        }
        void BuildGroupData()
        {
            if (!_context.GroupSet.Any())
            {
                _context.GroupSet.Add(
                    new Group()
                    {
                        Name = "Administrator",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );
                _context.GroupSet.Add(
                    new Group()
                    {
                        Name = "Faculty",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );
                _context.GroupSet.Add(
                    new Group()
                    {
                        Name = "Student",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );
                _context.GroupSet.Add(
                   new Group()
                   {
                       Name = "Parent",
                       Active = true,
                       Deleted = false,
                       CreatedBy = "Auto",
                       CreatedOn = DateTime.Now,
                       UpdatedBy = "Auto",
                       UpdatedOn = DateTime.Now
                   }
               );
                _context.SaveChanges();
            }
        }
        public void UserGroupRole()
        {
            if (!_context.GroupRoleSet.Any() && _context.RoleSet.Any())
            {
                _context.GroupRoleSet.Add(
                    new GroupRole()
                    {
                        GroupId = 1,
                        RoleId = 1,
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.GroupRoleSet.Add(
                   new GroupRole()
                   {
                       GroupId = 1,
                       RoleId = 3,
                       Active = true,
                       Deleted = false,
                       CreatedBy = "Auto",
                       CreatedOn = DateTime.Now,
                       UpdatedBy = "Auto",
                       UpdatedOn = DateTime.Now
                   }
               );

                _context.GroupRoleSet.Add(
                   new GroupRole()
                   {
                       GroupId = 1,
                       RoleId = 19,
                       Active = true,
                       Deleted = false,
                       CreatedBy = "Auto",
                       CreatedOn = DateTime.Now,
                       UpdatedBy = "Auto",
                       UpdatedOn = DateTime.Now
                   }
               );


                _context.GroupRoleSet.Add(
                   new GroupRole()
                   {
                       GroupId = 1,
                       RoleId = 25,
                       Active = true,
                       Deleted = false,
                       CreatedBy = "Auto",
                       CreatedOn = DateTime.Now,
                       UpdatedBy = "Auto",
                       UpdatedOn = DateTime.Now
                   }
               );


                _context.GroupRoleSet.Add(
                   new GroupRole()
                   {
                       GroupId = 1,
                       RoleId = 15,
                       Active = true,
                       Deleted = false,
                       CreatedBy = "Auto",
                       CreatedOn = DateTime.Now,
                       UpdatedBy = "Auto",
                       UpdatedOn = DateTime.Now
                   }
               );

                _context.GroupRoleSet.Add(
                   new GroupRole()
                   {
                       GroupId = 2,
                       RoleId = 4,
                       Active = true,
                       Deleted = false,
                       CreatedBy = "Auto",
                       CreatedOn = DateTime.Now,
                       UpdatedBy = "Auto",
                       UpdatedOn = DateTime.Now
                   }
               );

                _context.GroupRoleSet.Add(
                   new GroupRole()
                   {
                       GroupId = 2,
                       RoleId = 25,
                       Active = true,
                       Deleted = false,
                       CreatedBy = "Auto",
                       CreatedOn = DateTime.Now,
                       UpdatedBy = "Auto",
                       UpdatedOn = DateTime.Now
                   }
               );

                _context.GroupRoleSet.Add(
                   new GroupRole()
                   {
                       GroupId = 2,
                       RoleId = 15,
                       Active = true,
                       Deleted = false,
                       CreatedBy = "Auto",
                       CreatedOn = DateTime.Now,
                       UpdatedBy = "Auto",
                       UpdatedOn = DateTime.Now
                   }
               );


                _context.SaveChanges();
            }
        }

        void BuildCountryData()
        {
            if (!_context.CountrySet.Any())
            {
                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AF",
                        Name = "Afghanistan",
                        ShortCode = "93",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AL",
                        Name = "Albania",
                        ShortCode = "355",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "DZ",
                        Name = "Algeria",
                        ShortCode = "213",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AS",
                        Name = "American Samoa",
                        ShortCode = "+1 684",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AD",
                        Name = "Andorra",
                        ShortCode = "376",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AO",
                        Name = "Angola",
                        ShortCode = "244",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AQ",
                        Name = "Antarctica",
                        ShortCode = "672",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AG",
                        Name = "Antigua and Barbuda",
                        ShortCode = "+1 268",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AR",
                        Name = "Argentina",
                        ShortCode = "54",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AM",
                        Name = "Armenia",
                        ShortCode = "374",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AW",
                        Name = "Aruba",
                        ShortCode = "297",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AU",
                        Name = "Australia",
                        ShortCode = "61",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AT",
                        Name = "Austria",
                        ShortCode = "43",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AZ",
                        Name = "Azerbaijan",
                        ShortCode = "994",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BS",
                        Name = "Bahamas",
                        ShortCode = "+1 242",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BH",
                        Name = "Bahrain",
                        ShortCode = "973",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BD",
                        Name = "Bangladesh",
                        ShortCode = "880",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BB",
                        Name = "Barbados",
                        ShortCode = "+1 242",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BY",
                        Name = "Belarus",
                        ShortCode = "357",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BE",
                        Name = "Belgium",
                        ShortCode = "32",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BZ",
                        Name = "Belize",
                        ShortCode = "501",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BJ",
                        Name = "Benin",
                        ShortCode = "229",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BM",
                        Name = "Bermuda",
                        ShortCode = "+1 441",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BT",
                        Name = "Bhutan",
                        ShortCode = "975",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BO",
                        Name = "Bolivia",
                        ShortCode = "591",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BA",
                        Name = "Bosnia and Herzegovina",
                        ShortCode = "387",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BW",
                        Name = "Botswana",
                        ShortCode = "267",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BV",
                        Name = "Bouvet Island",
                        ShortCode = "",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BR",
                        Name = "Brazil",
                        ShortCode = "55",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "IO",
                        Name = "British Indian Ocean Territory",
                        ShortCode = "246",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BN",
                        Name = "Brunei Darussalam",
                        ShortCode = "673",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BG",
                        Name = "Bulgaria",
                        ShortCode = "359",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BF",
                        Name = "Burkina Faso",
                        ShortCode = "226",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "BI",
                        Name = "Burundi",
                        ShortCode = "257",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "KH",
                        Name = "Cambodia",
                        ShortCode = "855",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CM",
                        Name = "Cameroon",
                        ShortCode = "237",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CA",
                        Name = "Canada",
                        ShortCode = "1",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CV",
                        Name = "Cape Verde",
                        ShortCode = "238",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "KY",
                        Name = "Cayman Islands",
                        ShortCode = "+1 345",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CF",
                        Name = "Central African Republic",
                        ShortCode = "236",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TD",
                        Name = "Chad",
                        ShortCode = "235",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CL",
                        Name = "Chile",
                        ShortCode = "56",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CN",
                        Name = "China",
                        ShortCode = "86",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CX",
                        Name = "Christmas Island",
                        ShortCode = "61",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CC",
                        Name = "Cocos (Keeling) Islands",
                        ShortCode = "",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CO",
                        Name = "Colombia",
                        ShortCode = "61",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "KM",
                        Name = "Comoros",
                        ShortCode = "57",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CG",
                        Name = "Congo (Brazzaville) ",
                        ShortCode = "242",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CD",
                        Name = "Congo, Democratic Republic of the",
                        ShortCode = "243",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CK",
                        Name = "Cook Islands ",
                        ShortCode = "682",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CR",
                        Name = "Costa Rica",
                        ShortCode = "506",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CI",
                        Name = "Côte d'Ivoire",
                        ShortCode = "225",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "HR",
                        Name = "Croatia",
                        ShortCode = "385",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CU",
                        Name = "Cuba",
                        ShortCode = "53",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CY",
                        Name = "Cyprus",
                        ShortCode = "357",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CZ",
                        Name = "Czech Republic",
                        ShortCode = "420",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "DK",
                        Name = "Denmark",
                        ShortCode = "45",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "DJ",
                        Name = "Djibouti",
                        ShortCode = "253",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "DM",
                        Name = "Dominica",
                        ShortCode = "+1 767",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "DO",
                        Name = "Dominican Republic",
                        ShortCode = "+1 849",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "EC",
                        Name = "Ecuador",
                        ShortCode = "593",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "EG",
                        Name = "Egypt",
                        ShortCode = "20",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SV",
                        Name = "El Salvador",
                        ShortCode = "503",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GQ",
                        Name = "Equatorial Guinea",
                        ShortCode = "240",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "ER",
                        Name = "Eritrea",
                        ShortCode = "291",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "EE",
                        Name = "Estonia",
                        ShortCode = "372",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "ET",
                        Name = "Ethiopia",
                        ShortCode = "251",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "FK",
                        Name = "Falkland Islands (Malvinas)",
                        ShortCode = "500",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "FO",
                        Name = "Faroe Islands",
                        ShortCode = "298",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "FJ",
                        Name = "Fiji",
                        ShortCode = "679",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "FI",
                        Name = "Finland",
                        ShortCode = "358",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "FR",
                        Name = "France",
                        ShortCode = "33",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GF",
                        Name = "French Guiana",
                        ShortCode = "594",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PF",
                        Name = "French Polynesia",
                        ShortCode = "689",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TF",
                        Name = "French Southern Territories",
                        ShortCode = "",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GA",
                        Name = "Gabon",
                        ShortCode = "241",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GM",
                        Name = "Gambia",
                        ShortCode = "220",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GE",
                        Name = "Georgia",
                        ShortCode = "995",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "DE",
                        Name = "Germany",
                        ShortCode = "49",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GH",
                        Name = "Ghana",
                        ShortCode = "233",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GI",
                        Name = "Gibraltar ",
                        ShortCode = "350",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GR",
                        Name = "Greece ",
                        ShortCode = "30",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GL",
                        Name = "Greenland",
                        ShortCode = "299",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GD",
                        Name = "Grenada",
                        ShortCode = "+1 473",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GP",
                        Name = "Guadeloupe",
                        ShortCode = "590",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GU",
                        Name = "Guam",
                        ShortCode = "+1 671",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GT",
                        Name = "Guernsey",
                        ShortCode = "44",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GN",
                        Name = "Guinea",
                        ShortCode = "224",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GW",
                        Name = "Guinea-Bissau",
                        ShortCode = "245",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GY",
                        Name = "Guyana",
                        ShortCode = "592",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "HT",
                        Name = "Haiti",
                        ShortCode = "509",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "HM",
                        Name = "Heard Island and Mcdonald Islands",
                        ShortCode = "",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "HN",
                        Name = "Honduras",
                        ShortCode = "504",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "HK",
                        Name = "Hong Kong",
                        ShortCode = "852",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "HU",
                        Name = "Hungary",
                        ShortCode = "36",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "IS",
                        Name = "Iceland",
                        ShortCode = "353",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {

                        Code = "IN",
                        Name = "India",
                        ShortCode = "91",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {

                        Code = "ID",
                        Name = "Indonesia",
                        ShortCode = "62",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {

                        Code = "IR",
                        Name = "Iran, Islamic Republic of Iran",
                        ShortCode = "98",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {

                        Code = "IQ",
                        Name = "Iraq",
                        ShortCode = "964",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {

                        Code = "IE",
                        Name = "Ireland",
                        ShortCode = "353",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {

                        Code = "IL",
                        Name = "Israel",
                        ShortCode = "972",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {

                        Code = "IT",
                        Name = "Italy",
                        ShortCode = "39",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {

                        Code = "JM",
                        Name = "Jamaica",
                        ShortCode = "+1 876",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {

                        Code = "JP",
                        Name = "Japan",
                        ShortCode = "81",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "JO",
                        Name = "Jordan",
                        ShortCode = "962",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "KZ",
                        Name = "Kazakhstan",
                        ShortCode = "7",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "KE",
                        Name = "Kenya",
                        ShortCode = "254",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "KI",
                        Name = "Kiribati",
                        ShortCode = "686",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "KP",
                        Name = "Korea, Democratic People's Republic of",
                        ShortCode = "850",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "KR",
                        Name = "Korea, Republic of",
                        ShortCode = "82",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "KW",
                        Name = "Kuwait",
                        ShortCode = "965",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "KG",
                        Name = "Kyrgyzstan",
                        ShortCode = "996",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "LA",
                        Name = "LAO People's Democratic Republic",
                        ShortCode = "856",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "LV",
                        Name = "Latvia",
                        ShortCode = "371",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "LB",
                        Name = "Lebanon",
                        ShortCode = "961",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "LS",
                        Name = "Lesotho",
                        ShortCode = "266",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "LR",
                        Name = "Liberia",
                        ShortCode = "231",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "LY",
                        Name = "Libya",
                        ShortCode = "218",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "LI",
                        Name = "Liechtenstein",
                        ShortCode = "423",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "LT",
                        Name = "Lithuania",
                        ShortCode = "370",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "LU",
                        Name = "Luxembourg",
                        ShortCode = "352",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MO",
                        Name = "Macao",
                        ShortCode = "853",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MK",
                        Name = "Macedonia, Republic of Macedonia",
                        ShortCode = "389",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MG",
                        Name = "Madagascar",
                        ShortCode = "261",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MW",
                        Name = "Malawi",
                        ShortCode = "265",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MY",
                        Name = "Malaysia",
                        ShortCode = "60",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MV",
                        Name = "Maldives",
                        ShortCode = "960",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "ML",
                        Name = "Mali",
                        ShortCode = "223",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MT",
                        Name = "Malta",
                        ShortCode = "356",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MH",
                        Name = "Marshall Islands",
                        ShortCode = "692",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MQ",
                        Name = "Martinique",
                        ShortCode = "596",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MR",
                        Name = "Mauritania",
                        ShortCode = "222",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MU",
                        Name = "Mauritius",
                        ShortCode = "230",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "YT",
                        Name = "Mayotte",
                        ShortCode = "262",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MX",
                        Name = "Mexico",
                        ShortCode = "52",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "FM",
                        Name = "Micronesia, Federated States of Micronesia",
                        ShortCode = "691",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MD",
                        Name = "Moldova",
                        ShortCode = "373",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MC",
                        Name = "Monaco",
                        ShortCode = "377",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MN",
                        Name = "Mongolia",
                        ShortCode = "976",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "ME",
                        Name = "Montenegro",
                        ShortCode = "",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MS",
                        Name = "Montserrat",
                        ShortCode = "+1 664",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MA",
                        Name = "Morocco",
                        ShortCode = "212",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MZ",
                        Name = "Mozambique",
                        ShortCode = "258",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MM",
                        Name = "Myanmar",
                        ShortCode = "",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "NA",
                        Name = "Namibia",
                        ShortCode = "264",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "NR",
                        Name = "Nauru",
                        ShortCode = "674",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "NP",
                        Name = "Nepal",
                        ShortCode = "977",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "NL",
                        Name = "Netherlands",
                        ShortCode = "31",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AN2",
                        Name = "Netherlands Antilles",
                        ShortCode = "599",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "NC",
                        Name = "New Caledonia",
                        ShortCode = "687",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "NZ",
                        Name = "New Zealand",
                        ShortCode = "64",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "NI",
                        Name = "Nicaragua",
                        ShortCode = "505",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "NE",
                        Name = "Niger",
                        ShortCode = "234",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "NG",
                        Name = "Nigeria",
                        ShortCode = "234",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "NU",
                        Name = "Niue",
                        ShortCode = "683",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "NF",
                        Name = "Norfolk Island",
                        ShortCode = "672",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "MP",
                        Name = "Northern Mariana Islands",
                        ShortCode = "+1 670",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "NO",
                        Name = "Norway",
                        ShortCode = "47",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "OM",
                        Name = "Oman",
                        ShortCode = "968",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PK",
                        Name = "Pakistan",
                        ShortCode = "92",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );
                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PW",
                        Name = "Palau",
                        ShortCode = "680",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PS",
                        Name = "Palestinian Territory, Occupied",
                        ShortCode = "",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PA",
                        Name = "Panama",
                        ShortCode = "507",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PG",
                        Name = "Papua New Guinea",
                        ShortCode = "675",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PY",
                        Name = "Paraguay",
                        ShortCode = "595",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PE",
                        Name = "Peru",
                        ShortCode = "51",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PH",
                        Name = "Philippines",
                        ShortCode = "63",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PN",
                        Name = "Pitcairn",
                        ShortCode = "",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PL",
                        Name = "Poland",
                        ShortCode = "48",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PT",
                        Name = "Portugal",
                        ShortCode = "351",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PR",
                        Name = "Puerto Rico",
                        ShortCode = "+1 939",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "QA",
                        Name = "Qatar",
                        ShortCode = "974",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "RE",
                        Name = "Réunion",
                        ShortCode = "262",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "RO",
                        Name = "Romania",
                        ShortCode = "40",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "RU",
                        Name = "Russian Federation",
                        ShortCode = "7",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "RW",
                        Name = "Rwanda",
                        ShortCode = "250",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SH",
                        Name = "Saint Helena",
                        ShortCode = "290",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "KN",
                        Name = "Saint Kitts and Nevis",
                        ShortCode = "+1 869",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "LC",
                        Name = "Saint Lucia",
                        ShortCode = "+1 758",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "PM",
                        Name = "Saint Pierre and Miquelon ",
                        ShortCode = "508",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "VC",
                        Name = "Saint Vincent and Grenadines",
                        ShortCode = "+1 784",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "WS",
                        Name = "Samoa",
                        ShortCode = "685",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SM",
                        Name = "San Marino",
                        ShortCode = "378",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "ST",
                        Name = "Sao Tome and Principe",
                        ShortCode = "239",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SA",
                        Name = "Saudi Arabia",
                        ShortCode = "966",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SN",
                        Name = "Senegal",
                        ShortCode = "211",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "RS",
                        Name = "Serbia",
                        ShortCode = "",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SC",
                        Name = "Seychelles",
                        ShortCode = "248",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SL",
                        Name = "Sierra Leone",
                        ShortCode = "232",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SG",
                        Name = "Singapore",
                        ShortCode = "65",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SK",
                        Name = "Slovakia",
                        ShortCode = "421",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SI",
                        Name = "Slovenia",
                        ShortCode = "386",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SB",
                        Name = "Solomon Islands",
                        ShortCode = "677",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SO",
                        Name = "Somalia",
                        ShortCode = "252",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "ZA",
                        Name = "South Africa",
                        ShortCode = "27",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GS",
                        Name = "South Georgia and the South Sandwich Islands",
                        ShortCode = "",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "ES",
                        Name = "Spain",
                        ShortCode = "34",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "LK",
                        Name = "Sri Lanka",
                        ShortCode = "94",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SD",
                        Name = "Sudan",
                        ShortCode = "249",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SR",
                        Name = "Suriname",
                        ShortCode = "597",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SJ",
                        Name = "Svalbard and Jan Mayen Islands",
                        ShortCode = "47",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );


                _context.CountrySet.Add(
                        new Country()
                        {
                            Code = "SZ",
                            Name = "Swaziland",
                            ShortCode = "268",
                            Active = true,
                            Deleted = false,
                            CreatedBy = "Auto",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Auto",
                            UpdatedOn = DateTime.Now
                        }
                    );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SE",
                        Name = "Sweden",
                        ShortCode = "46",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "CH",
                        Name = "Switzerland",
                        ShortCode = "41",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "SY",
                        Name = "Syrian Arab Republic (Syria)",
                        ShortCode = "963",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TW",
                        Name = "Taiwan, Republic of China",
                        ShortCode = "886",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TJ",
                        Name = "Tajikistan",
                        ShortCode = "992",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TZ",
                        Name = "Tanzania, United Republic of",
                        ShortCode = "255",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TH",
                        Name = "Thailand",
                        ShortCode = "66",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TL",
                        Name = "Timor-Leste",
                        ShortCode = "670",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TG",
                        Name = "Togo",
                        ShortCode = "228",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TK",
                        Name = "Tokelau",
                        ShortCode = "690",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TO",
                        Name = "Tonga",
                        ShortCode = "676",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TT",
                        Name = "Trinidad and Tobago",
                        ShortCode = "+1 868",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TN",
                        Name = "Tunisia",
                        ShortCode = "216",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TR",
                        Name = "Turkey ",
                        ShortCode = "90",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TM",
                        Name = "Turkmenistan",
                        ShortCode = "993",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TC",
                        Name = "Turks and Caicos Islands",
                        ShortCode = "+1 649",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "TV",
                        Name = "Tuvalu",
                        ShortCode = "688",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "UG",
                        Name = "Uganda",
                        ShortCode = "256",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "UA",
                        Name = "Ukraine",
                        ShortCode = "380",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "AE",
                        Name = "United Arab Emirates",
                        ShortCode = "971",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "GB",
                        Name = "United Kingdom",
                        ShortCode = "44",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "US",
                        Name = "United Kingdom America",
                        ShortCode = "1",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "UM",
                        Name = "United States Minor Outlying Islands",
                        ShortCode = "598",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "UY",
                        Name = "Uruguay",
                        ShortCode = "998",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "UZ",
                        Name = "Uzbekistan",
                        ShortCode = "678",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "VU",
                        Name = "Vanuatu",
                        ShortCode = "58",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "VE",
                        Name = "Venezuela",
                        ShortCode = "84",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "VN",
                        Name = "Viet Nam",
                        ShortCode = "+1 340",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "VG",
                        Name = "Virgin Islands, British",
                        ShortCode = "",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "VI",
                        Name = "Virgin Islands, US",
                        ShortCode = "",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "WF",
                        Name = "Wallis and Futuna",
                        ShortCode = "681",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "EH",
                        Name = "Western Sahara",
                        ShortCode = "212",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "YE",
                        Name = "Yemen",
                        ShortCode = "967",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "ZM",
                        Name = "Zambia",
                        ShortCode = "260",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CountrySet.Add(
                    new Country()
                    {
                        Code = "ZW",
                        Name = "Zimbabwe",
                        ShortCode = "263",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.SaveChanges();
            }
        }

        void BuildStateData()
        {
            if (!_context.StateSet.Any())
            {
                _context.StateSet.Add(
                      new State()
                      {
                          Code = "AB",
                          Name = "Abia",
                          CountryCode = "NG",
                          Active = true,
                          Deleted = false,
                          CreatedBy = "Auto",
                          CreatedOn = DateTime.Now,
                          UpdatedBy = "Auto",
                          UpdatedOn = DateTime.Now
                      }
                    );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "AD",
                        Name = "Adamawa",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "AK",
                        Name = "Akwa Ibom",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "AN",
                        Name = "Anambra",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "BA",
                        Name = "Bauchi",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "BY",
                        Name = "Bayelsa",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );


                _context.StateSet.Add(
                    new State()
                    {
                        Code = "BE",
                        Name = "Benue",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "BO",
                        Name = "Borno",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "CR",
                        Name = "Cross River",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "DE",
                        Name = "Delta",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "EB",
                        Name = "Ebonyi",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "ED",
                        Name = "Edo",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "Ek",
                        Name = "Ekiti",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "EN",
                        Name = "Enugu",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "FT",
                        Name = "Abuja (FCT)",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "GO",
                        Name = "Gombe",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "IM",
                        Name = "Imo",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "JI",
                        Name = "Jigawa",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "KD",
                        Name = "Kaduna",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "KA",
                        Name = "Kano",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "KT",
                        Name = "Katsina",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "KB",
                        Name = "Kebbi",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "KO",
                        Name = "Kogi",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "KW",
                        Name = "Kwara",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "LG",
                        Name = "Lagos",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "NA",
                        Name = "Nasarawa",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "NI",
                        Name = "Niger",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "OG",
                        Name = "Ogun",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "ON",
                        Name = "Ondo",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "OS",
                        Name = "Osun",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "OY",
                        Name = "Oyo",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "PL",
                        Name = "Plateau",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "RI",
                        Name = "Rivers",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "SO",
                        Name = "Sokoto",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "TA",
                        Name = "Taraba",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "YO",
                        Name = "Yobe",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                    new State()
                    {
                        Code = "ZA",
                        Name = "Zamfara",
                        CountryCode = "NG",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.StateSet.Add(
                      new State()
                      {
                          Code = "BARB01",
                          Name = "Barbuda",
                          CountryCode = "AG",
                          Active = true,
                          Deleted = false,
                          CreatedBy = "Auto",
                          CreatedOn = DateTime.Now,
                          UpdatedBy = "Auto",
                          UpdatedOn = DateTime.Now
                      }
                    );

                _context.StateSet.Add(
                  new State()
                  {
                      Code = "SAGE02",
                      Name = "Saint George",
                      CountryCode = "AG",
                      Active = true,
                      Deleted = false,
                      CreatedBy = "Auto",
                      CreatedOn = DateTime.Now,
                      UpdatedBy = "Auto",
                      UpdatedOn = DateTime.Now
                  }
                );

                _context.StateSet.Add(
                  new State()
                  {
                      Code = "SAJO03",
                      Name = "Saint John",
                      CountryCode = "AG",
                      Active = true,
                      Deleted = false,
                      CreatedBy = "Auto",
                      CreatedOn = DateTime.Now,
                      UpdatedBy = "Auto",
                      UpdatedOn = DateTime.Now
                  }
                );
                _context.StateSet.Add(
                  new State()
                  {
                      Code = "SAMA04",
                      Name = "Saint Mary",
                      CountryCode = "AG",
                      Active = true,
                      Deleted = false,
                      CreatedBy = "Auto",
                      CreatedOn = DateTime.Now,
                      UpdatedBy = "Auto",
                      UpdatedOn = DateTime.Now
                  }
                  );

                _context.StateSet.Add(
                  new State()
                  {
                      Code = "SAPA05",
                      Name = "Saint Paul",
                      CountryCode = "AG",
                      Active = true,
                      Deleted = false,
                      CreatedBy = "Auto",
                      CreatedOn = DateTime.Now,
                      UpdatedBy = "Auto",
                      UpdatedOn = DateTime.Now
                  }
                  );



                _context.StateSet.Add(
                new State()
                {
                    Code = "SAPE06",
                    Name = "Saint Peter",
                    CountryCode = "AG",
                    Active = true,
                    Deleted = false,
                    CreatedBy = "Auto",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "Auto",
                    UpdatedOn = DateTime.Now
                }
                );

                _context.StateSet.Add(
                new State()
                {
                    Code = "SAPH07",
                    Name = "Saint Philip",
                    CountryCode = "AG",
                    Active = true,
                    Deleted = false,
                    CreatedBy = "Auto",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "Auto",
                    UpdatedOn = DateTime.Now
                }
                );


                //Angentina


                _context.StateSet.Add(
                      new State()
                      {
                          Code = "BUAI01",
                          Name = "Buenos Aires",
                          CountryCode = "AR",
                          Active = true,
                          Deleted = false,
                          CreatedBy = "Auto",
                          CreatedOn = DateTime.Now,
                          UpdatedBy = "Auto",
                          UpdatedOn = DateTime.Now
                      }
                    );

                _context.StateSet.Add(
                  new State()
                  {
                      Code = "CATA02",
                      Name = "Catamarca",
                      CountryCode = "AR",
                      Active = true,
                      Deleted = false,
                      CreatedBy = "Auto",
                      CreatedOn = DateTime.Now,
                      UpdatedBy = "Auto",
                      UpdatedOn = DateTime.Now
                  }
                );

                _context.StateSet.Add(
                  new State()
                  {
                      Code = "CHAC03",
                      Name = "Chaco",
                      CountryCode = "AR",
                      Active = true,
                      Deleted = false,
                      CreatedBy = "Auto",
                      CreatedOn = DateTime.Now,
                      UpdatedBy = "Auto",
                      UpdatedOn = DateTime.Now
                  }
                );
                _context.StateSet.Add(
                  new State()
                  {
                      Code = "CHUB04",
                      Name = "Chubut",
                      CountryCode = "AR",
                      Active = true,
                      Deleted = false,
                      CreatedBy = "Auto",
                      CreatedOn = DateTime.Now,
                      UpdatedBy = "Auto",
                      UpdatedOn = DateTime.Now
                  }
                  );

                _context.StateSet.Add(
                  new State()
                  {
                      Code = "CORD05",
                      Name = "Cordoba",
                      CountryCode = "AR",
                      Active = true,
                      Deleted = false,
                      CreatedBy = "Auto",
                      CreatedOn = DateTime.Now,
                      UpdatedBy = "Auto",
                      UpdatedOn = DateTime.Now
                  }
                  );



                _context.StateSet.Add(
                new State()
                {
                    Code = "CORR06",
                    Name = "Corrientes",
                    CountryCode = "AR",
                    Active = true,
                    Deleted = false,
                    CreatedBy = "Auto",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "Auto",
                    UpdatedOn = DateTime.Now
                }
                );

                _context.StateSet.Add(
                new State()
                {
                    Code = "DIFE07",
                    Name = "Distrito Federal",
                    CountryCode = "AR",
                    Active = true,
                    Deleted = false,
                    CreatedBy = "Auto",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "Auto",
                    UpdatedOn = DateTime.Now
                }
                );

                _context.StateSet.Add(
                 new State()
                 {
                     Code = "ENRI08",
                     Name = "Entre Rios",
                     CountryCode = "AR",
                     Active = true,
                     Deleted = false,
                     CreatedBy = "Auto",
                     CreatedOn = DateTime.Now,
                     UpdatedBy = "Auto",
                     UpdatedOn = DateTime.Now
                 }
                 );

                _context.StateSet.Add(
               new State()
               {
                   Code = "FORM09",
                   Name = "Formosa",
                   CountryCode = "AR",
                   Active = true,
                   Deleted = false,
                   CreatedBy = "Auto",
                   CreatedOn = DateTime.Now,
                   UpdatedBy = "Auto",
                   UpdatedOn = DateTime.Now
               }
               );
                _context.StateSet.Add(
           new State()
           {
               Code = "JUJU10",
               Name = "Jujuy",
               CountryCode = "AR",
               Active = true,
               Deleted = false,
               CreatedBy = "Auto",
               CreatedOn = DateTime.Now,
               UpdatedBy = "Auto",
               UpdatedOn = DateTime.Now
           }
           );
                _context.StateSet.Add(
               new State()
               {
                   Code = "LAPA11",
                   Name = "La Pampa",
                   CountryCode = "AR",
                   Active = true,
                   Deleted = false,
                   CreatedBy = "Auto",
                   CreatedOn = DateTime.Now,
                   UpdatedBy = "Auto",
                   UpdatedOn = DateTime.Now
               }
               );


                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "LARI12",
                                         Name = "La Rioja",
                                         CountryCode = "AR",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );

                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "MEND13",
                                         Name = "Mendoza",
                                         CountryCode = "AR",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );

                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "MISI14",
                                         Name = "Misiones",
                                         CountryCode = "AR",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );
                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "RINE15",
                                         Name = "Rio Negro",
                                         CountryCode = "AR",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );

                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "SALT16",
                                         Name = "Salta",
                                         CountryCode = "AR",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );

                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "SAJU17",
                                         Name = "San Juan",
                                         CountryCode = "AR",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );

                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "SALU18",
                                         Name = "San Luis",
                                         CountryCode = "AR",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );

                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "SACR19",
                                         Name = "Santa Cruz",
                                         CountryCode = "AR",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );

                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "SAFE20",
                                         Name = "Santa Fe",
                                         CountryCode = "AR",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );


                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "SADE21",
                                         Name = "Santiago del Estero",
                                         CountryCode = "AR",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );

                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "TIDF22",
                                         Name = "Tierra del Fuego",
                                         CountryCode = "AR",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );
                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "TUCU21",
                                         Name = "Tucuman",
                                         CountryCode = "AR",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );



                //            // Amenia




                _context.StateSet.Add(
                      new State()
                      {
                          Code = "ARAG01",
                          Name = "Aragatsotn",
                          CountryCode = "AM",
                          Active = true,
                          Deleted = false,
                          CreatedBy = "Auto",
                          CreatedOn = DateTime.Now,
                          UpdatedBy = "Auto",
                          UpdatedOn = DateTime.Now
                      }
                    );

                _context.StateSet.Add(
                  new State()
                  {
                      Code = "ARAR02",
                      Name = "Ararat",
                      CountryCode = "AM",
                      Active = true,
                      Deleted = false,
                      CreatedBy = "Auto",
                      CreatedOn = DateTime.Now,
                      UpdatedBy = "Auto",
                      UpdatedOn = DateTime.Now
                  }
                );

                _context.StateSet.Add(
                  new State()
                  {
                      Code = "ARMA03",
                      Name = "Armavir",
                      CountryCode = "AM",
                      Active = true,
                      Deleted = false,
                      CreatedBy = "Auto",
                      CreatedOn = DateTime.Now,
                      UpdatedBy = "Auto",
                      UpdatedOn = DateTime.Now
                  }
                );
                _context.StateSet.Add(
                  new State()
                  {
                      Code = "GEGH04",
                      Name = "Gegharkunik",
                      CountryCode = "AM",
                      Active = true,
                      Deleted = false,
                      CreatedBy = "Auto",
                      CreatedOn = DateTime.Now,
                      UpdatedBy = "Auto",
                      UpdatedOn = DateTime.Now
                  }
                  );

                _context.StateSet.Add(
                  new State()
                  {
                      Code = "KOTO05",
                      Name = "Kotaik",
                      CountryCode = "AM",
                      Active = true,
                      Deleted = false,
                      CreatedBy = "Auto",
                      CreatedOn = DateTime.Now,
                      UpdatedBy = "Auto",
                      UpdatedOn = DateTime.Now
                  }
                  );



                _context.StateSet.Add(
                new State()
                {
                    Code = "LORI06",
                    Name = "Lori",
                    CountryCode = "AM",
                    Active = true,
                    Deleted = false,
                    CreatedBy = "Auto",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "Auto",
                    UpdatedOn = DateTime.Now
                }
                );

                _context.StateSet.Add(
                new State()
                {
                    Code = "SHIR07",
                    Name = "Shirak",
                    CountryCode = "AM",
                    Active = true,
                    Deleted = false,
                    CreatedBy = "Auto",
                    CreatedOn = DateTime.Now,
                    UpdatedBy = "Auto",
                    UpdatedOn = DateTime.Now
                }
                );

                _context.StateSet.Add(
                 new State()
                 {
                     Code = "STEP08",
                     Name = "Stepanakert",
                     CountryCode = "AM",
                     Active = true,
                     Deleted = false,
                     CreatedBy = "Auto",
                     CreatedOn = DateTime.Now,
                     UpdatedBy = "Auto",
                     UpdatedOn = DateTime.Now
                 }
                 );

                _context.StateSet.Add(
               new State()
               {
                   Code = "SYUN09",
                   Name = "Syunik",
                   CountryCode = "AM",
                   Active = true,
                   Deleted = false,
                   CreatedBy = "Auto",
                   CreatedOn = DateTime.Now,
                   UpdatedBy = "Auto",
                   UpdatedOn = DateTime.Now
               }
               );
                _context.StateSet.Add(
           new State()
           {
               Code = "TAVU10",
               Name = "Tavush",
               CountryCode = "AM",
               Active = true,
               Deleted = false,
               CreatedBy = "Auto",
               CreatedOn = DateTime.Now,
               UpdatedBy = "Auto",
               UpdatedOn = DateTime.Now
           }
           );
                _context.StateSet.Add(
               new State()
               {
                   Code = "VADZ11",
                   Name = "Vayots Dzor",
                   CountryCode = "AM",
                   Active = true,
                   Deleted = false,
                   CreatedBy = "Auto",
                   CreatedOn = DateTime.Now,
                   UpdatedBy = "Auto",
                   UpdatedOn = DateTime.Now
               }
               );


                _context.StateSet.Add(
                                     new State()
                                     {
                                         Code = "YERE12",
                                         Name = "Yerevan",
                                         CountryCode = "AM",
                                         Active = true,
                                         Deleted = false,
                                         CreatedBy = "Auto",
                                         CreatedOn = DateTime.Now,
                                         UpdatedBy = "Auto",
                                         UpdatedOn = DateTime.Now
                                     }
                                     );
                
                _context.SaveChanges();
        }
    }


    void BuildCityData()
        {
            if (!_context.CitySet.Any())
            {
                _context.CitySet.Add(
                    new City()
                    {
                        Code = "IKJ",
                        Name = "Ikeja",
                        StateId = 2,
                        StateCode = "13",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CitySet.Add(
                    new City()
                    {
                        Code = "ISL",
                        Name = "Lagos Island",
                        StateId = 1,
                        StateCode = "11",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.CitySet.Add(
                    new City()
                    {
                        Code = "IKD",
                        Name = "Ikorodu",
                        StateId = 3,
                        StateCode = "12",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.SaveChanges();
            }
        }

        void BuildLanguageData()
        {
            if (!_context.LanguageSet.Any())
            {
                _context.LanguageSet.Add(
                   new Language()
                   {
                       Code = "AB",
                       Name = " Abkhazian",
                       Active = true,
                       Deleted = false,
                       CreatedBy = "Auto",
                       CreatedOn = DateTime.Now,
                       UpdatedBy = "Auto",
                       UpdatedOn = DateTime.Now
                   }
               );

                _context.LanguageSet.Add(
                        new Language()
                        {
                            Code = "AA",
                            Name = " Afar",
                            Active = true,
                            Deleted = false,
                            CreatedBy = "Auto",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Auto",
                            UpdatedOn = DateTime.Now
                        }
                    );

                _context.LanguageSet.Add(
                        new Language()
                        {
                            Code = "AF",
                            Name = " Afrikaans",
                            Active = true,
                            Deleted = false,
                            CreatedBy = "Auto",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Auto",
                            UpdatedOn = DateTime.Now
                        }
                    );

                _context.LanguageSet.Add(
                        new Language()
                        {
                            Code = "SQ",
                            Name = " Albanian",
                            Active = true,
                            Deleted = false,
                            CreatedBy = "Auto",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Auto",
                            UpdatedOn = DateTime.Now
                        }
                    );

                _context.LanguageSet.Add(
                        new Language()
                        {
                            Code = "AM",
                            Name = " Amharic",
                            Active = true,
                            Deleted = false,
                            CreatedBy = "Auto",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Auto",
                            UpdatedOn = DateTime.Now
                        }
                    );

                _context.LanguageSet.Add(
                        new Language()
                        {
                            Code = "AR",
                            Name = " Arabic",
                            Active = true,
                            Deleted = false,
                            CreatedBy = "Auto",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Auto",
                            UpdatedOn = DateTime.Now
                        }
                    );

                _context.LanguageSet.Add(
                        new Language()
                        {
                            Code = "AN",
                            Name = " Aragonese",
                            Active = true,
                            Deleted = false,
                            CreatedBy = "Auto",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Auto",
                            UpdatedOn = DateTime.Now
                        }
                    );



                _context.LanguageSet.Add(
                        new Language()
                        {
                            Code = "HY",
                            Name = "Armenian",
                            Active = true,
                            Deleted = false,
                            CreatedBy = "Auto",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Auto",
                            UpdatedOn = DateTime.Now
                        }
                    );
                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "AS",
                        Name = " Assamese",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "AY",
                        Name = " Aymara",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "AZ",
                        Name = " Azerbaijani",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "BA",
                        Name = " Bashkir",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "EU",
                        Name = "Basque",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "BN",
                        Name = "Bengali",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "DZ",
                        Name = "Bhutani",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "BH",
                        Name = "Bihari",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "BI",
                        Name = " Bislama",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "BR",
                        Name = "Breton",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );
                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "BG",
                        Name = "Bulgarian",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "MY",
                        Name = "Burmese",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "BE",
                        Name = "Byelorussian",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "KM",
                        Name = "Cambodian",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "CA",
                        Name = " Catalan",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "ZH",
                        Name = "Chinese",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "CO",
                        Name = "Corsican",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "DA",
                        Name = "Danish",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "NL",
                        Name = "Dutch",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "EN",
                        Name = "English",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "EO",
                        Name = "Esperanto",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "ET",
                        Name = "Estonian",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "FJ",
                        Name = "Fiji",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "FR",
                        Name = "French",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "FY",
                        Name = "Frisian",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "GL",
                        Name = "Galician",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "GD",
                        Name = "Gaelic (Scottish)",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "GV",
                        Name = "Gaelic (Manx)",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "DE",
                        Name = "German",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "EL",
                        Name = "Greek",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "GN",
                        Name = "Guarani",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "HA",
                        Name = "Hausa",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "HE",
                        Name = "Hebrew",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "HI",
                        Name = "Hindi",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "IN",
                        Name = "Indonesian",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "IA",
                        Name = "Interlingua",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "IE",
                        Name = "Interlingue",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "IU",
                        Name = "Inuktitut",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "GA",
                        Name = "Irish",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "IG",
                        Name = "Igbo",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "IT",
                        Name = "Italian",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "JA",
                        Name = "Japanese",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "JV",
                        Name = "Javanese",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "KO",
                        Name = "Korean",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "KU",
                        Name = "Kurdish",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "LA",
                        Name = "Latin",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );
                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "LV",
                        Name = "Latvian (Lettish)",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "NA",
                        Name = "Nauru",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "NE",
                        Name = "Nepali",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "PA",
                        Name = "Punjabi",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "PT",
                        Name = "Portuguese",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "RO",
                        Name = "Romanian",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "RU",
                        Name = "Russian",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "SM",
                        Name = "Samoan",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "SG",
                        Name = "Sangro",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "TN",
                        Name = "Setswana",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "ES",
                        Name = "Spanish",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "TK",
                        Name = "Turkmen",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "CY",
                        Name = "Welsh",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "WO",
                        Name = "Wolof",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "YO",
                        Name = "Yoruba",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.LanguageSet.Add(
                    new Language()
                    {
                        Code = "ZU",
                        Name = "Zulu",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.SaveChanges();
            }
        }

        void BuildReligionData()
        {
            if (!_context.ReligionSet.Any())
            {
                _context.ReligionSet.Add(
                    new Religion()
                    {
                        Code = "IS",
                        Name = "Islam",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.ReligionSet.Add(
                    new Religion()
                    {
                        Code = "CT",
                        Name = "Christian",
                        Active = true,
                        Deleted = false,
                        CreatedBy = "Auto",
                        CreatedOn = DateTime.Now,
                        UpdatedBy = "Auto",
                        UpdatedOn = DateTime.Now
                    }
                );

                _context.ReligionSet.Add(
                   new Religion()
                   {
                       Code = "OT",
                       Name = "Others",
                       Active = true,
                       Deleted = false,
                       CreatedBy = "Auto",
                       CreatedOn = DateTime.Now,
                       UpdatedBy = "Auto",
                       UpdatedOn = DateTime.Now
                   }
               );

                _context.SaveChanges();
            }
        }
    }
}
