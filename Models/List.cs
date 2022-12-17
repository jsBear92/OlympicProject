using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OlympicProject.Models
{
    public class List
    {
    }

    public enum GenderList
    {
        Male,
        Female
    }

    public enum Medal
    {
        Gold,
        Silver,
        Bronze,
        [Display(Name = "No Medal")]
        NoMedal
    }

    public enum CountryList
    {
        Afghanistan,
        [Display(Name = "Åland Islands")]
        Åland_Islands,
        Albania,
        Algeria,
        [Display(Name = "American Samoa")]
        American_Samoa,
        Andorra,
        Angola,
        Anguilla,
        Antarctica,
        [Display(Name = "Antigua and Barbuda")]
        Antigua_and_Barbuda,
        Argentina,
        Armenia,
        Aruba,
        [Display(Name = "Australia")]
        Australia,
        Austria,
        Azerbaijan,
        Bahamas,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bermuda,
        Bhutan,
        Bolivia,
        [Display(Name = "Bosnia and Herzegovina")]
        Bosnia_and_Herzegovina,
        Botswana,
        [Display(Name = "Bouvet Island")]
        Bouvet_Island,
        Brazil,
        [Display(Name = "British Indian Ocean Territory")]
        British_Indian_Ocean_Territory,
        [Display(Name = "Brunei Darussalam")]
        Brunei_Darussalam,
        Bulgaria,
        [Display(Name = "Burkina Faso")]
        Burkina_Faso,
        Burundi,
        Cambodia,
        Cameroon,
        Canada,
        [Display(Name = "Cape Verde")]
        Cape_Verde,
        [Display(Name = "Cayman Islands")]
        Cayman_Islands,
        [Display(Name = "Central African Republic")]
        Central_African_Republic,
        Chad,
        Chile,
        China,
        [Display(Name = "Christmas Island")]
        Christmas_Island,
        [Display(Name = "Cocos (Keeling) Islands")]
        Cocos_Keeling_Islands,
        Colombia,
        Comoros,
        Congo,
        [Display(Name = "Congo, The Democratic Republic of The")]
        Congo_The_Democratic_Republic_of_The,
        [Display(Name = "Cook Islands")]
        Cook_Islands,
        [Display(Name = "Costa Rica")]
        Costa_Rica,
        [Display(Name = "Cote D'ivoire")]
        Cote_D_ivoire,
        Croatia,
        Cuba,
        Cyprus,
        [Display(Name = "Czech Republic")]
        Czech_Republic,
        Denmark,
        Djibouti,
        Dominica,
        [Display(Name = "Dominican Republic")]
        Dominican_Republic,
        Ecuador,
        Egypt,
        [Display(Name = "El Salvador")]
        El_Salvador,
        [Display(Name = "Equatorial Guinea")]
        EquatorialGuinea,
        Eritrea,
        Estonia,
        Ethiopia,
        [Display(Name = "Falkland Islands(Malvinas)")]
        FalklandIslands_Malvinas,
        [Display(Name = "Faroe Islands")]
        Faroe_Islands,
        Fiji,
        Finland,
        France,
        [Display(Name = "French Guiana")]
        French_Guiana,
        [Display(Name = "French Polynesia")]
        French_Polynesia,
        [Display(Name = "French Southern Territories")]
        French_Southern_Territories,
        Gabon,
        Gambia,
        Georgia,
        Germany,
        Ghana,
        Gibraltar,
        Greenland,
        Grenada,
        Guadeloupe,
        Guam,
        Guatemala,
        Guernsey,
        Guinea,
        [Display(Name = "Guinea bissau")]
        Guinea_bissau,
        Guyana,
        Haiti,
        [Display(Name = "Heard Island and Mcdonald Islands")]
        Heard_Island_and_Mcdonald_Islands,
        [Display(Name = "Holy See(Vatican City State)")]
        Holy_See_Vatican_City_State,
        Honduras,
        [Display(Name = "Hong Kong")]
        Hong_Kong,
        Hungary,
        Iceland,
        India,
        Indonesia,
        [Display(Name = "Iran, Islamic Republic of")]
        Iran_Islamic_Republic_of,
        Iraq,
        Ireland,
        [Display(Name = "Isle of Man")]
        Isle_of_Man,
        Israel,
        Italy,
        Jamaica,
        Japan,
        Jersey,
        Jordan,
        Kazakhstan,
        Kenya,
        Kiribati,
        [Display(Name = "Korea, Democratic People's Republic of")]
        Korea_Democratic_People_s_Republic_of,
        [Display(Name = "Korea, Republic of")]
        Korea_Republic_of,
        Kuwait,
        Kyrgyzstan,
        [Display(Name = "Lao People's Democratic Republic")]
        Lao_People_s_Democratic_Republic,
        Latvia,
        Lebanon,
        Lesotho,
        Liberia,
        [Display(Name = "Libyan Arab Jamahiriya")]
        Libyan_Arab_Jamahiriya,
        Liechtenstein,
        Lithuania,
        Luxembourg,
        Macao,
        [Display(Name = "Macedonia, The Former Yugoslav Republic of")]
        Macedonia_The_Former_Yugoslav_Republic_of,
        Madagascar,
        Malawi,
        Malaysia,
        Maldives,
        Mali,
        Malta,
        [Display(Name = "Marshall Islands")]
        Marshall_Islands,
        Martinique,
        Mauritania,
        Mauritius,
        Mayotte,
        Mexico,
        [Display(Name = "Micronesia, Federated States of")]
        Micronesia_Federated_States_of,
        [Display(Name = "Moldova, Republic of")]
        Moldova_Republic_of,
        Monaco,
        Mongolia,
        Montenegro,
        Montserrat,
        Morocco,
        Mozambique,
        Myanmar,
        Namibia,
        Nauru,
        Nepal,
        Netherlands,
        [Display(Name = "Netherlands Antilles")]
        Netherlands_Antilles,
        [Display(Name = "New Caledonia")]
        New_Caledonia,
        [Display(Name = "New Zealand")]
        New_Zealand,
        Nicaragua,
        Niger,
        Nigeria,
        Niue,
        [Display(Name = "Norfolk Island")]
        Norfolk_Island,
        [Display(Name = "Northern Mariana Islands")]
        Northern_Mariana_Islands,
        Norway,
        Oman,
        Pakistan,
        Palau,
        [Display(Name = "Palestinian Territory, Occupied")]
        Palestinian_Territory_Occupied,
        Panama,
        [Display(Name = "Papua New Guinea")]
        Papua_New_Guinea,
        Paraguay,
        Peru,
        Philippines,
        Pitcairn,
        Poland,
        Portugal,
        [Display(Name = "Puerto Rico")]
        Puerto_Rico,
        Qatar,
        Reunion,
        Romania,
        [Display(Name = "Russian Federation")]
        Russian_Federation,
        Rwanda,
        [Display(Name = "Saint Helena")]
        Saint_Helena,
        [Display(Name = "Saint Kitts and Nevis")]
        Saint_Kitts_and_Nevis,
        [Display(Name = "Saint Lucia")]
        Saint_Lucia,
        [Display(Name = "Saint Pierre and Miquelon")]
        Saint_Pierre_and_Miquelon,
        [Display(Name = "Saint Vincent and The Grenadines")]
        Saint_Vincent_and_The_Grenadines,
        Samoa,
        [Display(Name = "San Marino")]
        San_Marino,
        [Display(Name = "Sao Tome and Principe")]
        Sao_Tome_and_Principe,
        [Display(Name = "Saudi Arabia")]
        Saudi_Arabia,
        Senegal,
        Serbia,
        Seychelles,
        [Display(Name = "Sierra Leone")]
        Sierra_Leone,
        Singapore,
        Slovakia,
        Slovenia,
        [Display(Name = "Solomon Islands")]
        Solomon_Islands,
        Somalia,
        [Display(Name = "South Africa")]
        South_Africa,
        [Display(Name = "South Georgia and The South Sandwich Islands")]
        South_Georgia_and_The_South_Sandwich_Islands,
        Spain,
        [Display(Name = "Sri Lanka")]
        Sri_Lanka,
        Sudan,
        Suriname,
        [Display(Name = "Svalbard and Jan Mayen")]
        Svalbard_and_Jan_Mayen,
        Swaziland,
        Sweden,
        Switzerland,
        [Display(Name = "Syrian Arab Republic")]
        Syrian_Arab_Republic,
        [Display(Name = "Taiwan, Province of China")]
        Taiwan_Province_of_China,
        Tajikistan,
        [Display(Name = "Tanzania, United Republic of")]
        Tanzania_United_Republic_of,
        Thailand,
        [Display(Name = "Timor-leste")]
        Timor_leste,
        Togo,
        Tokelau,
        Tonga,
        [Display(Name = "Trinidad and Tobago")]
        Trinidad_and_Tobago,
        Tunisia,
        Turkey,
        Turkmenistan,
        [Display(Name = "Turks and Caicos Islands")]
        Turks_and_Caicos_Islands,
        Tuvalu,
        Uganda,
        Ukraine,
        [Display(Name = "United Arab Emirates")]
        United_Arab_Emirates,
        [Display(Name = "United Kingdom")]
        United_Kingdom,
        [Display(Name = "United States")]
        United_States,
        [Display(Name = "United States Minor Outlying Islands")]
        United_States_Minor_Outlying_Islands,
        Uruguay,
        Uzbekistan,
        Vanuatu,
        Venezuela,
        [Display(Name = "Viet Nam")]
        Viet_Nam,
        [Display(Name = "Virgin Islands, British")]
        Virgin_Islands_British,
        [Display(Name = "Virgin Islands, U.S.")]
        Virgin_Islands_US,
        [Display(Name = "Wallis and Futuna")]
        Wallis_and_Futuna,
        [Display(Name = "Western Sahara")]
        Western_Sahara,
        Yemen,
        Zambia,
        Zimbabwe,
    }
}
