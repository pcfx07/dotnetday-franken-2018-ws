using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DdfApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace DdfApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private static readonly List<Customer> _customers = JsonConvert.DeserializeObject<List<Customer>>(@"
[
	{
		""id"": ""5DDC790D-5325-9FC5-4D2C-0F925258C4D5"",
		""firstName"": ""Eve"",
		""lastName"": ""Carey"",
		""age"": 29
	},
	{
		""id"": ""5D3BAC36-FF00-020E-4AB8-B05D840033E4"",
		""firstName"": ""Karen"",
		""lastName"": ""Klein"",
		""age"": 54
	},
	{
		""id"": ""3E128097-7B84-EE9C-682D-A0D01F46038A"",
		""firstName"": ""Cally"",
		""lastName"": ""Chavez"",
		""age"": 50
	},
	{
		""id"": ""62449B81-4A0C-9067-E2D6-B74A3E21D02D"",
		""firstName"": ""Gay"",
		""lastName"": ""Mendez"",
		""age"": 48
	},
	{
		""id"": ""2187D970-7690-5620-9424-AAE6490FB615"",
		""firstName"": ""Hillary"",
		""lastName"": ""Morton"",
		""age"": 24
	},
	{
		""id"": ""95760722-21B2-F958-1DC5-29E17DBF1C10"",
		""firstName"": ""Noelle"",
		""lastName"": ""Woods"",
		""age"": 37
	},
	{
		""id"": ""A180A14C-7F34-DCA1-224B-011537300D33"",
		""firstName"": ""Karly"",
		""lastName"": ""Lane"",
		""age"": 62
	},
	{
		""id"": ""7B2D694F-80B6-289F-D7E4-44B768AF7AE0"",
		""firstName"": ""Maya"",
		""lastName"": ""Glass"",
		""age"": 62
	},
	{
		""id"": ""B3B5B3CD-4C32-351B-E4BA-3B78430A9757"",
		""firstName"": ""Mari"",
		""lastName"": ""Bryant"",
		""age"": 47
	},
	{
		""id"": ""0FB83075-7CA3-E7A6-3502-85E75FDE53B3"",
		""firstName"": ""Hollee"",
		""lastName"": ""Lott"",
		""age"": 67
	},
	{
		""id"": ""392B15FC-A6F1-35A6-4470-EFB66C47C2F3"",
		""firstName"": ""Maggy"",
		""lastName"": ""Chan"",
		""age"": 17
	},
	{
		""id"": ""D48BFF78-72A6-6FAE-13BD-50A3EFC59823"",
		""firstName"": ""Justine"",
		""lastName"": ""Lewis"",
		""age"": 13
	},
	{
		""id"": ""746C8AA0-134D-D81D-E7EC-E931CE81AA2B"",
		""firstName"": ""Natalie"",
		""lastName"": ""Petersen"",
		""age"": 28
	},
	{
		""id"": ""B8362495-E6DC-A81F-EE6F-E441D5A599D8"",
		""firstName"": ""Althea"",
		""lastName"": ""Lewis"",
		""age"": 84
	},
	{
		""id"": ""0E977363-9597-734C-5F0A-ECEEB236391C"",
		""firstName"": ""Kelly"",
		""lastName"": ""Stout"",
		""age"": 47
	},
	{
		""id"": ""9C496625-45CF-C685-F11E-BA01420781A1"",
		""firstName"": ""Maris"",
		""lastName"": ""Dunn"",
		""age"": 27
	},
	{
		""id"": ""27C3E521-A2F2-CA7F-12CB-A01760284998"",
		""firstName"": ""Shannon"",
		""lastName"": ""Faulkner"",
		""age"": 21
	},
	{
		""id"": ""8BFA2AB9-7903-BFE3-E178-EC161216EA88"",
		""firstName"": ""Ariana"",
		""lastName"": ""Woodard"",
		""age"": 62
	},
	{
		""id"": ""5DA9DCF0-26A2-B977-8161-EA0DA5072E80"",
		""firstName"": ""Yoko"",
		""lastName"": ""Glover"",
		""age"": 20
	},
	{
		""id"": ""BE4101C6-EAF6-37BA-2C02-8F86C9569EFD"",
		""firstName"": ""Marah"",
		""lastName"": ""Ortiz"",
		""age"": 53
	},
	{
		""id"": ""CB96AF8A-D59D-4C8E-091B-5B4556F6FFBE"",
		""firstName"": ""Roary"",
		""lastName"": ""Herrera"",
		""age"": 47
	},
	{
		""id"": ""2D073C61-596C-B2B7-C79E-5391A337326E"",
		""firstName"": ""Irene"",
		""lastName"": ""Hurley"",
		""age"": 69
	},
	{
		""id"": ""666D0B1C-75D5-58FB-9920-DA6766F9B736"",
		""firstName"": ""Violet"",
		""lastName"": ""Hawkins"",
		""age"": 49
	},
	{
		""id"": ""5617443C-3503-74A4-F79D-C8134A9B9916"",
		""firstName"": ""Daria"",
		""lastName"": ""Lambert"",
		""age"": 38
	},
	{
		""id"": ""309DFA1A-6347-3C31-F646-9CB161873FE2"",
		""firstName"": ""Amena"",
		""lastName"": ""Villarreal"",
		""age"": 36
	},
	{
		""id"": ""2FB5842E-0942-390B-BB2C-8F8000C82859"",
		""firstName"": ""Nita"",
		""lastName"": ""Fowler"",
		""age"": 14
	},
	{
		""id"": ""30A3DC65-A234-76B3-43DA-0AFC37BAEC56"",
		""firstName"": ""Avye"",
		""lastName"": ""Owens"",
		""age"": 87
	},
	{
		""id"": ""40BC1C3E-E0CE-DC58-E33E-F45FE5A6DBC2"",
		""firstName"": ""Claudia"",
		""lastName"": ""Hart"",
		""age"": 24
	},
	{
		""id"": ""0B9977EF-F3D0-A4ED-FD9A-60007E23E630"",
		""firstName"": ""Cailin"",
		""lastName"": ""Estes"",
		""age"": 20
	},
	{
		""id"": ""3F8DF303-17C6-72D2-7FD4-2548EF6B0546"",
		""firstName"": ""Yeo"",
		""lastName"": ""Riley"",
		""age"": 13
	},
	{
		""id"": ""A1CA316C-0F32-25C6-9BC3-8481631B07F7"",
		""firstName"": ""Ingrid"",
		""lastName"": ""Martinez"",
		""age"": 53
	},
	{
		""id"": ""5CB33480-F8B3-1DE9-B60A-E5B50115F472"",
		""firstName"": ""Hope"",
		""lastName"": ""Paul"",
		""age"": 76
	},
	{
		""id"": ""47FF2DCC-F448-2B32-398D-91CB40727C72"",
		""firstName"": ""Eliana"",
		""lastName"": ""Mckenzie"",
		""age"": 55
	},
	{
		""id"": ""9AD0E5AC-68E0-382E-C73F-5FB79E29343A"",
		""firstName"": ""Pandora"",
		""lastName"": ""Mann"",
		""age"": 87
	},
	{
		""id"": ""CBFCA647-0BE5-0354-74AC-25BEF0B42956"",
		""firstName"": ""Denise"",
		""lastName"": ""Simmons"",
		""age"": 62
	},
	{
		""id"": ""FD3B33C3-706C-A1EA-AA86-C1639244A296"",
		""firstName"": ""Kiayada"",
		""lastName"": ""Davidson"",
		""age"": 14
	},
	{
		""id"": ""5E78AB87-BD8A-B452-4813-206F31ADFA8D"",
		""firstName"": ""Audrey"",
		""lastName"": ""Dixon"",
		""age"": 47
	},
	{
		""id"": ""2853431E-14B0-816F-6437-108B53820563"",
		""firstName"": ""Erica"",
		""lastName"": ""Noble"",
		""age"": 69
	},
	{
		""id"": ""C7851FE7-D281-0F06-272D-38DDDE031841"",
		""firstName"": ""Desiree"",
		""lastName"": ""Macdonald"",
		""age"": 38
	},
	{
		""id"": ""C4C59CAE-10F2-054E-9CE0-FDD4BC02A322"",
		""firstName"": ""Amela"",
		""lastName"": ""Rutledge"",
		""age"": 46
	},
	{
		""id"": ""4990F24E-C03D-7E87-422D-7601CA7498D7"",
		""firstName"": ""Denise"",
		""lastName"": ""Copeland"",
		""age"": 25
	},
	{
		""id"": ""85B2ED3C-469B-963B-6503-5BEAEB65CF80"",
		""firstName"": ""Lynn"",
		""lastName"": ""Walter"",
		""age"": 30
	},
	{
		""id"": ""3CD894EB-7540-D34F-75C0-5CF049A5C7F6"",
		""firstName"": ""Rachel"",
		""lastName"": ""Walter"",
		""age"": 83
	},
	{
		""id"": ""9EDF85B8-5B73-3658-0E1B-C91C11ED0256"",
		""firstName"": ""Xena"",
		""lastName"": ""Obrien"",
		""age"": 76
	},
	{
		""id"": ""92A6354D-50F6-4E81-472C-FF3F1A9AF845"",
		""firstName"": ""Ingrid"",
		""lastName"": ""Wolf"",
		""age"": 90
	},
	{
		""id"": ""F51BA1E1-DA19-2FFD-84A8-38983EDB4753"",
		""firstName"": ""Cameron"",
		""lastName"": ""Shannon"",
		""age"": 63
	},
	{
		""id"": ""A3DF4CCF-613F-097B-AF8F-0643E4AD40FE"",
		""firstName"": ""Amethyst"",
		""lastName"": ""Peterson"",
		""age"": 64
	},
	{
		""id"": ""220E17BC-D520-458C-0BB4-76B4DD87419C"",
		""firstName"": ""Kessie"",
		""lastName"": ""Rollins"",
		""age"": 49
	},
	{
		""id"": ""0012E8C8-9616-A231-B3DA-E8E9FC46E6C1"",
		""firstName"": ""Liberty"",
		""lastName"": ""Burns"",
		""age"": 85
	},
	{
		""id"": ""FFFA0667-76BC-4076-711B-E8E06C6347D3"",
		""firstName"": ""Iris"",
		""lastName"": ""Justice"",
		""age"": 66
	},
	{
		""id"": ""311B0C31-928C-2BE8-1BF5-4BE2A446DD8E"",
		""firstName"": ""Ursula"",
		""lastName"": ""Buckley"",
		""age"": 77
	},
	{
		""id"": ""B4593C03-85FB-FE06-0ABA-A38AFA84D737"",
		""firstName"": ""Jemima"",
		""lastName"": ""Sykes"",
		""age"": 24
	},
	{
		""id"": ""57F12E4A-8B18-E6AF-7495-82B2A77A6061"",
		""firstName"": ""Pearl"",
		""lastName"": ""Finley"",
		""age"": 80
	},
	{
		""id"": ""5885DDF0-9675-C5D5-4E57-B2694E766B31"",
		""firstName"": ""Hayley"",
		""lastName"": ""Love"",
		""age"": 67
	},
	{
		""id"": ""BA82A567-AF68-EC4F-7CB5-E7E1C30C7336"",
		""firstName"": ""Hermione"",
		""lastName"": ""Booker"",
		""age"": 75
	},
	{
		""id"": ""40C7FAA5-67E4-1B48-9238-4D19A2D85C3C"",
		""firstName"": ""Alisa"",
		""lastName"": ""Brock"",
		""age"": 46
	},
	{
		""id"": ""26EC267D-EF61-3AE2-8411-3C0A05A48CF2"",
		""firstName"": ""Shelby"",
		""lastName"": ""Briggs"",
		""age"": 12
	},
	{
		""id"": ""1D20B75A-B649-9B23-633F-B4297A690505"",
		""firstName"": ""Kelsey"",
		""lastName"": ""Norris"",
		""age"": 26
	},
	{
		""id"": ""F50DD7D3-ECB9-98B5-C902-41071F292C8D"",
		""firstName"": ""Gwendolyn"",
		""lastName"": ""Cummings"",
		""age"": 55
	},
	{
		""id"": ""E6584EC6-3603-B34F-882B-ADD1CDFF7CB3"",
		""firstName"": ""Cora"",
		""lastName"": ""Beach"",
		""age"": 76
	},
	{
		""id"": ""935B2D24-8EF5-425B-DEBB-12B423722E76"",
		""firstName"": ""Aimee"",
		""lastName"": ""Bowman"",
		""age"": 61
	},
	{
		""id"": ""2E7181CD-4B55-CB95-4B83-4A6B5D13F786"",
		""firstName"": ""Mechelle"",
		""lastName"": ""Mercer"",
		""age"": 89
	},
	{
		""id"": ""68688A61-5589-A22E-E85B-E4BD2397C3D6"",
		""firstName"": ""Alisa"",
		""lastName"": ""Sloan"",
		""age"": 52
	},
	{
		""id"": ""BACC4B79-7388-E7F3-4985-54D6B78380B9"",
		""firstName"": ""Chiquita"",
		""lastName"": ""Gross"",
		""age"": 15
	},
	{
		""id"": ""FAC163DE-802F-7594-CF5C-841ABA1FA3B0"",
		""firstName"": ""Brenna"",
		""lastName"": ""Roberts"",
		""age"": 71
	},
	{
		""id"": ""94447CD7-714A-40BF-C417-0C65D714AD83"",
		""firstName"": ""Rhea"",
		""lastName"": ""Maddox"",
		""age"": 32
	},
	{
		""id"": ""9A07668C-6669-50D0-AA15-E30EA1502D03"",
		""firstName"": ""Echo"",
		""lastName"": ""Daniels"",
		""age"": 47
	},
	{
		""id"": ""738CAD80-9C99-38D5-81C9-E9CEDE58AAE4"",
		""firstName"": ""Pandora"",
		""lastName"": ""Cardenas"",
		""age"": 68
	},
	{
		""id"": ""9C5624F4-E339-F731-A16E-4E8653F859B3"",
		""firstName"": ""Jena"",
		""lastName"": ""Steele"",
		""age"": 11
	},
	{
		""id"": ""871757C6-097B-5E3D-8581-39746C90C644"",
		""firstName"": ""Lareina"",
		""lastName"": ""Dotson"",
		""age"": 52
	},
	{
		""id"": ""6EB96998-B2A4-3CB4-34AF-E44BC5D970C8"",
		""firstName"": ""Skyler"",
		""lastName"": ""Campbell"",
		""age"": 86
	},
	{
		""id"": ""22F4DCF7-D177-4BD0-4421-4EE4D4DBD764"",
		""firstName"": ""Whoopi"",
		""lastName"": ""Meyer"",
		""age"": 68
	},
	{
		""id"": ""B394565E-3B4F-DA09-CAC0-336BDCE9D245"",
		""firstName"": ""Ashely"",
		""lastName"": ""House"",
		""age"": 39
	},
	{
		""id"": ""92283C05-4F4B-93F4-3052-50B31D50AFEB"",
		""firstName"": ""Liberty"",
		""lastName"": ""Owens"",
		""age"": 33
	},
	{
		""id"": ""E585B819-1131-4EB3-6C85-1494EC8E2EF2"",
		""firstName"": ""Cally"",
		""lastName"": ""Burns"",
		""age"": 77
	},
	{
		""id"": ""98012FE3-9671-B982-C81F-F7D90FE6918F"",
		""firstName"": ""Illana"",
		""lastName"": ""Mcfarland"",
		""age"": 54
	},
	{
		""id"": ""8CECD525-FC66-FE7F-6BE1-F8891125204B"",
		""firstName"": ""Isadora"",
		""lastName"": ""Dillon"",
		""age"": 35
	},
	{
		""id"": ""1DBC5F51-70C4-AF13-2B55-2F4F004B2AB2"",
		""firstName"": ""Beverly"",
		""lastName"": ""Wyatt"",
		""age"": 43
	},
	{
		""id"": ""2FAA0948-EA05-8522-9DB1-675840246BAD"",
		""firstName"": ""Linda"",
		""lastName"": ""Mitchell"",
		""age"": 88
	},
	{
		""id"": ""8633CE8A-48B4-EB2F-D84A-408B833D2F15"",
		""firstName"": ""Brynne"",
		""lastName"": ""Cervantes"",
		""age"": 31
	},
	{
		""id"": ""EB6A8F83-235D-EFB9-8261-62F6B8AC4343"",
		""firstName"": ""Aurora"",
		""lastName"": ""Lee"",
		""age"": 89
	},
	{
		""id"": ""DAF2D205-118E-4665-456D-7024C94418B4"",
		""firstName"": ""Idona"",
		""lastName"": ""Leach"",
		""age"": 76
	},
	{
		""id"": ""3CC03212-8A67-CCBB-BADE-ECD2AA9BF5F5"",
		""firstName"": ""Lee"",
		""lastName"": ""Trujillo"",
		""age"": 89
	},
	{
		""id"": ""F3C4DFAD-F07D-1EDA-BCEC-53CA2ECC7CF0"",
		""firstName"": ""Stella"",
		""lastName"": ""Berg"",
		""age"": 27
	},
	{
		""id"": ""D5FD5633-754A-159B-9433-3065E44FD3C6"",
		""firstName"": ""Farrah"",
		""lastName"": ""Lawrence"",
		""age"": 40
	},
	{
		""id"": ""0117E684-C8E8-11CD-426C-0DD1A17DA534"",
		""firstName"": ""Savannah"",
		""lastName"": ""Burns"",
		""age"": 77
	},
	{
		""id"": ""30B0C917-35C3-C5F8-C097-4BA4A7DE2313"",
		""firstName"": ""Candace"",
		""lastName"": ""Sosa"",
		""age"": 69
	},
	{
		""id"": ""82F8F0E2-5D7E-A356-9989-EA6BD2155538"",
		""firstName"": ""Buffy"",
		""lastName"": ""Shaw"",
		""age"": 38
	},
	{
		""id"": ""D499C1E4-6462-43D7-4C42-17C1398FFB70"",
		""firstName"": ""Kirby"",
		""lastName"": ""Snyder"",
		""age"": 54
	},
	{
		""id"": ""0FE25FDE-4C56-3378-A3BD-788CE94B0898"",
		""firstName"": ""Florence"",
		""lastName"": ""Combs"",
		""age"": 17
	},
	{
		""id"": ""6389D6AB-449D-CAE9-45C8-2FAC2261A7B2"",
		""firstName"": ""Ariel"",
		""lastName"": ""Flynn"",
		""age"": 27
	},
	{
		""id"": ""4D335412-5251-50A9-735B-7A2D4085BB42"",
		""firstName"": ""Lysandra"",
		""lastName"": ""Beasley"",
		""age"": 47
	},
	{
		""id"": ""50D8DFA9-0ABC-7FB9-F24D-73BC202320CB"",
		""firstName"": ""Aurora"",
		""lastName"": ""Wilkerson"",
		""age"": 75
	},
	{
		""id"": ""FE0925B2-F1A8-9467-E581-8A1B9C7DA8E0"",
		""firstName"": ""Kirsten"",
		""lastName"": ""Branch"",
		""age"": 78
	},
	{
		""id"": ""70F45CBE-87A1-F0A0-01D8-A0994AD4C2B7"",
		""firstName"": ""Bethany"",
		""lastName"": ""Gould"",
		""age"": 82
	},
	{
		""id"": ""A890273E-AAE1-69DE-C229-4692E8865027"",
		""firstName"": ""Cynthia"",
		""lastName"": ""Good"",
		""age"": 83
	},
	{
		""id"": ""A9005C2D-EF2F-9921-0423-8081139A25FD"",
		""firstName"": ""Lael"",
		""lastName"": ""Harrington"",
		""age"": 86
	},
	{
		""id"": ""9A65B955-5786-1BF0-F3DD-0C374AEFB80E"",
		""firstName"": ""Fiona"",
		""lastName"": ""Lowe"",
		""age"": 57
	},
	{
		""id"": ""CE6E42AB-BC8D-E026-91B9-0DA460D7E5C5"",
		""firstName"": ""Kevyn"",
		""lastName"": ""Garza"",
		""age"": 20
	},
	{
		""id"": ""4A7DE236-0312-02F3-3E4A-4180A1216156"",
		""firstName"": ""Barbara"",
		""lastName"": ""Sullivan"",
		""age"": 65
	},
	{
		""id"": ""0A4F40AF-3EC4-CA76-202A-FAAA35DB54F3"",
		""firstName"": ""Ebony"",
		""lastName"": ""Glass"",
		""age"": 21
	},
	{
		""id"": ""D7B6D930-94EB-02B6-6B40-97BF21C61B31"",
		""firstName"": ""Kiara"",
		""lastName"": ""Hewitt"",
		""age"": 64
	},
	{
		""id"": ""E0DB845E-0C90-528D-9EB8-E2D0BFC616F3"",
		""firstName"": ""Francesca"",
		""lastName"": ""Peterson"",
		""age"": 65
	},
	{
		""id"": ""13431EA3-0988-6047-153B-014693359CF1"",
		""firstName"": ""Alice"",
		""lastName"": ""Joyner"",
		""age"": 72
	},
	{
		""id"": ""8466DAE3-8354-F20E-C420-4F9B3152F73B"",
		""firstName"": ""Adrienne"",
		""lastName"": ""Mcleod"",
		""age"": 13
	},
	{
		""id"": ""806856DC-3743-7577-55F1-FD7A40DD0CEB"",
		""firstName"": ""Beatrice"",
		""lastName"": ""Mcgee"",
		""age"": 32
	},
	{
		""id"": ""3D9AF989-DE61-BFD9-1764-AC1DA889E218"",
		""firstName"": ""Tamara"",
		""lastName"": ""Cooley"",
		""age"": 50
	},
	{
		""id"": ""3D31E2BD-292B-A3BB-E8A9-E676F06776D4"",
		""firstName"": ""Marah"",
		""lastName"": ""Daugherty"",
		""age"": 47
	},
	{
		""id"": ""C08B110B-2B54-D99D-E1A5-29C104C317DE"",
		""firstName"": ""Fleur"",
		""lastName"": ""Valencia"",
		""age"": 23
	},
	{
		""id"": ""2ED2FD68-103C-78A4-D46B-30CC8B4C910E"",
		""firstName"": ""Dawn"",
		""lastName"": ""Cruz"",
		""age"": 81
	},
	{
		""id"": ""780AB551-3513-8CD1-8622-EB371B297D41"",
		""firstName"": ""Rhonda"",
		""lastName"": ""Daniels"",
		""age"": 61
	},
	{
		""id"": ""C274F68D-8DBD-9004-2A32-FE1EBED0D1B3"",
		""firstName"": ""Fatima"",
		""lastName"": ""Hunt"",
		""age"": 59
	},
	{
		""id"": ""48CC9C17-64C2-F158-4E27-A1FF55E160B7"",
		""firstName"": ""Britanni"",
		""lastName"": ""Cruz"",
		""age"": 54
	},
	{
		""id"": ""5B249813-CFBF-F250-1754-1FD452AAFA14"",
		""firstName"": ""Madison"",
		""lastName"": ""Oneill"",
		""age"": 54
	},
	{
		""id"": ""1D6A3EDC-1799-7A2E-9A7D-CA0B988689A2"",
		""firstName"": ""Alexis"",
		""lastName"": ""Mercado"",
		""age"": 55
	},
	{
		""id"": ""42DFD23B-5772-0015-7DB7-8E142526D162"",
		""firstName"": ""Frances"",
		""lastName"": ""Wolfe"",
		""age"": 15
	},
	{
		""id"": ""A2A31E08-35BB-9491-E158-A2B419FE77A2"",
		""firstName"": ""Wynne"",
		""lastName"": ""Gray"",
		""age"": 14
	},
	{
		""id"": ""1909FA55-871B-2F0F-23AF-3F1137B6220B"",
		""firstName"": ""Lana"",
		""lastName"": ""Jennings"",
		""age"": 58
	},
	{
		""id"": ""3C1F3AEE-7334-CF67-8E63-9A6406D16EE8"",
		""firstName"": ""Tara"",
		""lastName"": ""Mitchell"",
		""age"": 41
	},
	{
		""id"": ""7B2C5D83-E3A2-823A-BECA-E8652019721D"",
		""firstName"": ""Emerald"",
		""lastName"": ""Glass"",
		""age"": 31
	},
	{
		""id"": ""2378C6EB-E92C-E43F-F215-C06404D47531"",
		""firstName"": ""Fiona"",
		""lastName"": ""Ballard"",
		""age"": 22
	},
	{
		""id"": ""AABEF87A-288F-0183-9956-A88DF1C95902"",
		""firstName"": ""Katelyn"",
		""lastName"": ""Whitaker"",
		""age"": 32
	},
	{
		""id"": ""6AFED8B4-0E27-3C2B-EE51-70472C51C526"",
		""firstName"": ""Iona"",
		""lastName"": ""Cook"",
		""age"": 30
	},
	{
		""id"": ""35D3967F-F2F0-F524-55E4-90323C414921"",
		""firstName"": ""Hayley"",
		""lastName"": ""Oneill"",
		""age"": 15
	},
	{
		""id"": ""8A421F7F-FEBF-D837-A3BC-E64A15770205"",
		""firstName"": ""Gloria"",
		""lastName"": ""Hurst"",
		""age"": 90
	},
	{
		""id"": ""BD59531E-F025-FC68-1567-49AFC467C82F"",
		""firstName"": ""Olivia"",
		""lastName"": ""Mcgee"",
		""age"": 40
	},
	{
		""id"": ""33552900-9A83-939C-F9AF-6EDE14479AF2"",
		""firstName"": ""Nadine"",
		""lastName"": ""Rosario"",
		""age"": 23
	},
	{
		""id"": ""C2DA2398-ECDD-9C67-C27D-2BFFEB2DA509"",
		""firstName"": ""Gemma"",
		""lastName"": ""Valencia"",
		""age"": 26
	},
	{
		""id"": ""917F45B8-DED6-9F19-8929-C36E0E2D3E13"",
		""firstName"": ""Mallory"",
		""lastName"": ""Cote"",
		""age"": 20
	},
	{
		""id"": ""5B55424C-1366-F08E-9C00-F22495B7C488"",
		""firstName"": ""Aiko"",
		""lastName"": ""Walton"",
		""age"": 10
	},
	{
		""id"": ""B62CBBCE-198E-947C-80F4-0063864BBC71"",
		""firstName"": ""Veronica"",
		""lastName"": ""Martin"",
		""age"": 11
	},
	{
		""id"": ""BF3EDFC6-30ED-CFB4-5AEE-9AEF40BEF107"",
		""firstName"": ""Ginger"",
		""lastName"": ""Bullock"",
		""age"": 67
	},
	{
		""id"": ""8C5E5032-19FE-51D3-B3C6-B8A629E34272"",
		""firstName"": ""Maite"",
		""lastName"": ""Gilmore"",
		""age"": 49
	},
	{
		""id"": ""BDCFB167-19C2-F4B8-673F-F0B28D50E2BA"",
		""firstName"": ""Jessamine"",
		""lastName"": ""Mejia"",
		""age"": 65
	},
	{
		""id"": ""0BD05A07-6F51-3309-343D-358141426FC1"",
		""firstName"": ""Blythe"",
		""lastName"": ""Reid"",
		""age"": 71
	},
	{
		""id"": ""FF670048-6BA8-6D7A-EDB5-F85D33BF2D1C"",
		""firstName"": ""Basia"",
		""lastName"": ""Price"",
		""age"": 58
	},
	{
		""id"": ""E4325EFC-9CD8-36D5-ABA1-25A121DCB3BE"",
		""firstName"": ""Gwendolyn"",
		""lastName"": ""Rosa"",
		""age"": 30
	},
	{
		""id"": ""B232BF0B-6588-3C42-74DB-11C84224E03E"",
		""firstName"": ""Jennifer"",
		""lastName"": ""Robles"",
		""age"": 81
	},
	{
		""id"": ""4DD8B860-D7DF-457A-F89A-949058E9FDD1"",
		""firstName"": ""Whilemina"",
		""lastName"": ""Luna"",
		""age"": 60
	},
	{
		""id"": ""47FB38AD-FC7E-64D7-68B1-0BE510492D9D"",
		""firstName"": ""Dakota"",
		""lastName"": ""Peck"",
		""age"": 39
	},
	{
		""id"": ""44AA98F5-BD6A-FC58-4051-9AE368F581BD"",
		""firstName"": ""Alyssa"",
		""lastName"": ""Hansen"",
		""age"": 81
	},
	{
		""id"": ""0F4BB619-987B-0A4A-B9BB-641CAAF7CC29"",
		""firstName"": ""Sybil"",
		""lastName"": ""Albert"",
		""age"": 36
	},
	{
		""id"": ""A48E5FAD-50D1-A0E7-CF9D-F45B1988B3D2"",
		""firstName"": ""Rebecca"",
		""lastName"": ""Vance"",
		""age"": 68
	},
	{
		""id"": ""E591183F-71AB-D5E0-0B38-84D908D995C0"",
		""firstName"": ""Karyn"",
		""lastName"": ""Golden"",
		""age"": 25
	},
	{
		""id"": ""215D51C7-7456-0C08-EA02-DEE232F26302"",
		""firstName"": ""Hollee"",
		""lastName"": ""Tanner"",
		""age"": 54
	},
	{
		""id"": ""950750DF-A1EC-D922-D884-9218D38BAA00"",
		""firstName"": ""Ebony"",
		""lastName"": ""Byers"",
		""age"": 53
	},
	{
		""id"": ""1994FAF8-31D2-077C-B90F-C4BA030B1E50"",
		""firstName"": ""Suki"",
		""lastName"": ""Savage"",
		""age"": 87
	},
	{
		""id"": ""AF4E48B6-3AB9-C866-D1A4-83D50F33E0EA"",
		""firstName"": ""Urielle"",
		""lastName"": ""Bush"",
		""age"": 73
	},
	{
		""id"": ""9CA4FB4E-9208-0AD8-D13A-FD61E81979B5"",
		""firstName"": ""Jorden"",
		""lastName"": ""Chandler"",
		""age"": 56
	},
	{
		""id"": ""D1946D4A-C5E4-910E-7F19-C4C35B3C3601"",
		""firstName"": ""Maggie"",
		""lastName"": ""Sanford"",
		""age"": 34
	},
	{
		""id"": ""1D317E23-3363-FAA0-A509-AA8F09FF3F97"",
		""firstName"": ""Tana"",
		""lastName"": ""Lindsey"",
		""age"": 77
	},
	{
		""id"": ""2840ED53-516F-C68B-1BC4-7D72E696A1A5"",
		""firstName"": ""Idona"",
		""lastName"": ""Morgan"",
		""age"": 83
	},
	{
		""id"": ""45BA7A19-A938-B651-30A0-784F1CC5D8E3"",
		""firstName"": ""Alana"",
		""lastName"": ""Sharp"",
		""age"": 31
	},
	{
		""id"": ""A6109FC2-0D27-AEF3-C0F7-40B6949452CD"",
		""firstName"": ""Madaline"",
		""lastName"": ""Franklin"",
		""age"": 36
	},
	{
		""id"": ""EC4A552A-64D7-F0DC-0C51-B1A3E185DD27"",
		""firstName"": ""Darryl"",
		""lastName"": ""Goodwin"",
		""age"": 43
	},
	{
		""id"": ""171B78DE-F7A8-FDB4-1BE5-823EE2BF47B2"",
		""firstName"": ""Bianca"",
		""lastName"": ""Rosales"",
		""age"": 89
	},
	{
		""id"": ""D01E83A0-BFC3-D8BD-7D28-C74114ADF276"",
		""firstName"": ""Willow"",
		""lastName"": ""Pruitt"",
		""age"": 48
	},
	{
		""id"": ""6FCE44F3-1BA5-C0D4-5BCD-2B58DC86B7AC"",
		""firstName"": ""Katell"",
		""lastName"": ""Giles"",
		""age"": 22
	},
	{
		""id"": ""B509FEC0-D542-92C7-630C-AB833E1A87CE"",
		""firstName"": ""Rhonda"",
		""lastName"": ""Wilkinson"",
		""age"": 63
	},
	{
		""id"": ""C46A5492-EC0E-AE06-1FC3-F62DA78E38B7"",
		""firstName"": ""Madonna"",
		""lastName"": ""Cain"",
		""age"": 85
	},
	{
		""id"": ""B5D41307-697A-2475-5B93-4869490A6A99"",
		""firstName"": ""Regan"",
		""lastName"": ""Roberson"",
		""age"": 11
	},
	{
		""id"": ""39024E8F-86E7-1409-9053-D1DAAAA4D29B"",
		""firstName"": ""Jolie"",
		""lastName"": ""Garner"",
		""age"": 73
	},
	{
		""id"": ""AC0C7683-9001-3374-7B9C-98611F17F227"",
		""firstName"": ""Rowan"",
		""lastName"": ""Torres"",
		""age"": 69
	},
	{
		""id"": ""8EA9F26F-E1AD-BBA6-FFFA-0838D2659EAA"",
		""firstName"": ""Whoopi"",
		""lastName"": ""Schwartz"",
		""age"": 84
	},
	{
		""id"": ""BC5DE6D7-0D25-0589-EB3A-1417ACCA61AD"",
		""firstName"": ""Darryl"",
		""lastName"": ""Farley"",
		""age"": 83
	},
	{
		""id"": ""9DF6ED3E-F612-0D7F-BA98-CC4AF2C23693"",
		""firstName"": ""Kerry"",
		""lastName"": ""Walker"",
		""age"": 76
	},
	{
		""id"": ""A558ACAD-5048-9435-6793-3D8BF66E6B65"",
		""firstName"": ""Savannah"",
		""lastName"": ""Gilliam"",
		""age"": 17
	},
	{
		""id"": ""0F2ACF69-085E-34FC-D6E1-9415E742C478"",
		""firstName"": ""Cailin"",
		""lastName"": ""Bentley"",
		""age"": 17
	},
	{
		""id"": ""694F277C-E46C-4273-5730-74959634C411"",
		""firstName"": ""Imani"",
		""lastName"": ""Gillespie"",
		""age"": 30
	},
	{
		""id"": ""C2E9030A-1301-8FAF-27A0-AF8341E354B5"",
		""firstName"": ""Paloma"",
		""lastName"": ""Glover"",
		""age"": 60
	},
	{
		""id"": ""3CEFEE88-CDA0-D87F-FB15-1D6453FC8A6B"",
		""firstName"": ""Nola"",
		""lastName"": ""Mcguire"",
		""age"": 20
	},
	{
		""id"": ""E58F427D-2394-FFEC-6710-FA1B47C16E75"",
		""firstName"": ""Petra"",
		""lastName"": ""Garcia"",
		""age"": 22
	},
	{
		""id"": ""7481ED9C-0654-CF60-798A-D3C9F91F27AA"",
		""firstName"": ""Regina"",
		""lastName"": ""Valencia"",
		""age"": 79
	},
	{
		""id"": ""834AF1ED-6979-B8F1-9491-C2C41021F4AF"",
		""firstName"": ""Jolene"",
		""lastName"": ""Baldwin"",
		""age"": 53
	},
	{
		""id"": ""75B92C64-0D4C-9DBC-2B92-D303047A26C7"",
		""firstName"": ""Sydnee"",
		""lastName"": ""Gonzales"",
		""age"": 80
	},
	{
		""id"": ""37819829-B9D8-D801-48B2-01AF52445A1D"",
		""firstName"": ""Zorita"",
		""lastName"": ""Bradshaw"",
		""age"": 42
	},
	{
		""id"": ""8B1584D8-0E25-C803-CFC6-60EC77FA6AC0"",
		""firstName"": ""Lareina"",
		""lastName"": ""Lamb"",
		""age"": 57
	},
	{
		""id"": ""5651E8D3-9EE9-A820-E18A-708F57671116"",
		""firstName"": ""Phyllis"",
		""lastName"": ""Craft"",
		""age"": 84
	},
	{
		""id"": ""55C16573-8425-79FE-A9AF-8424D3FF223B"",
		""firstName"": ""Rhonda"",
		""lastName"": ""Burt"",
		""age"": 71
	},
	{
		""id"": ""6469AE03-0563-F523-53EE-6D4109891DDA"",
		""firstName"": ""Nina"",
		""lastName"": ""Newman"",
		""age"": 11
	},
	{
		""id"": ""092BBFE3-41EE-4811-2C7E-C2B811E4C997"",
		""firstName"": ""Dana"",
		""lastName"": ""Waters"",
		""age"": 67
	},
	{
		""id"": ""F488BC0E-FC00-24B7-5C80-7A12887B0BC2"",
		""firstName"": ""Amela"",
		""lastName"": ""Long"",
		""age"": 76
	},
	{
		""id"": ""24C9D133-5939-E063-D35F-09FC824CB1C2"",
		""firstName"": ""Kelsie"",
		""lastName"": ""Reeves"",
		""age"": 74
	},
	{
		""id"": ""998B3236-042B-B8CA-BA40-4AFA09587354"",
		""firstName"": ""Kylan"",
		""lastName"": ""Vaughan"",
		""age"": 21
	},
	{
		""id"": ""5251B9F6-CDF4-069A-A57F-E649B55702CC"",
		""firstName"": ""Freya"",
		""lastName"": ""Freeman"",
		""age"": 68
	},
	{
		""id"": ""F0D6C6C6-0E08-9F05-0AFF-EC20CE047B01"",
		""firstName"": ""Jessamine"",
		""lastName"": ""Banks"",
		""age"": 87
	},
	{
		""id"": ""00BA3FD7-DE33-E9D4-3400-695CF5ECEF4A"",
		""firstName"": ""Autumn"",
		""lastName"": ""Mcdowell"",
		""age"": 26
	},
	{
		""id"": ""375CF4B8-72B7-13B2-D4A8-606A0F062452"",
		""firstName"": ""Lila"",
		""lastName"": ""Wiley"",
		""age"": 84
	},
	{
		""id"": ""7F839989-3E89-34F6-B5A1-2494F7CF9EA2"",
		""firstName"": ""Dahlia"",
		""lastName"": ""Hatfield"",
		""age"": 58
	},
	{
		""id"": ""6ADA975C-F1E6-8DBF-5BB6-52682A310700"",
		""firstName"": ""Susan"",
		""lastName"": ""Wallace"",
		""age"": 69
	},
	{
		""id"": ""7DC811BB-9317-7128-4988-AD707DB1880B"",
		""firstName"": ""Karina"",
		""lastName"": ""Casey"",
		""age"": 47
	},
	{
		""id"": ""D16BE4C7-BAAE-73B9-98FE-EA2EE8E8AA12"",
		""firstName"": ""Reagan"",
		""lastName"": ""Ewing"",
		""age"": 40
	},
	{
		""id"": ""CE1527CC-7D6F-CE53-DE85-461D0A73D2F7"",
		""firstName"": ""Demetria"",
		""lastName"": ""Santos"",
		""age"": 64
	},
	{
		""id"": ""928E158F-6F09-3DDE-D45A-EBA0AC6D0CB5"",
		""firstName"": ""Bethany"",
		""lastName"": ""Farmer"",
		""age"": 38
	},
	{
		""id"": ""8CF0D3E1-13FE-A4B0-FF68-72A9B4212548"",
		""firstName"": ""Rebekah"",
		""lastName"": ""Stout"",
		""age"": 35
	},
	{
		""id"": ""6410E3A4-8255-708E-B926-5E4438488C7F"",
		""firstName"": ""Kirsten"",
		""lastName"": ""Potts"",
		""age"": 47
	},
	{
		""id"": ""81547BA6-B939-38EC-0EBE-2A6945357289"",
		""firstName"": ""Whoopi"",
		""lastName"": ""Quinn"",
		""age"": 88
	},
	{
		""id"": ""043CC014-54BB-FE7D-669B-5FB02665AEDE"",
		""firstName"": ""Charlotte"",
		""lastName"": ""Hayes"",
		""age"": 90
	},
	{
		""id"": ""F6B600FC-7C2C-3995-7E65-8FD37BFA6C24"",
		""firstName"": ""Grace"",
		""lastName"": ""Chandler"",
		""age"": 45
	},
	{
		""id"": ""61AC88ED-899B-B844-3DB2-AFAFD206B2FC"",
		""firstName"": ""Francesca"",
		""lastName"": ""Molina"",
		""age"": 36
	}
]
");

        /// <summary>
        /// Fetches all customers.
        /// </summary>
        /// <returns>A collection of customers.</returns>
        /// <response code="200">Fetched customers successfully.</response>
        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        /// <summary>
        /// Query a customer by it's identifier
        /// </summary>
        /// <param name="id">Identifier of the Customer</param>
        /// <returns>If valid identifier is passed, a customer instance</returns>
        /// <response code="400">If invalid request has been sent</response>
        /// <response code="404">If no customer is found with id</response>
        [ProducesResponseType(typeof(Customer), 200)]
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id == Guid.Empty)
            {
                return BadRequest("Got Guid.Empty");
            }

            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound("No customer found with Id");
            }

            return Ok(customer);
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult CreateCustomer([FromBody]Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newCustomer == null)
            {
                return BadRequest("Customer is null");
            }
            newCustomer.Id = Guid.NewGuid();

            _customers.Add(newCustomer);
            return Created(Url.Action("GetCustomerById", new { newCustomer.Id}), 
                newCustomer);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id == Guid.Empty)
            {
                return BadRequest("No Guid given, can't delete");
            }

            var customer = _customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound($"No Customer with id {id} found.");
            }

            _customers.Remove(customer);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomerById(Guid id, [FromBody] BaseCustomer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id == Guid.Empty)
            {
                return BadRequest("No valid Guid provided for Update Action");
            }

            if (customer == null)
            {
                return BadRequest("No Customer provided, can't execute Update Action");
            }

            var currentCustomer = _customers.FirstOrDefault(c => c.Id == id);
            if (currentCustomer == null)
            {
                return NotFound($"No customer found with id {id}");
            }

            currentCustomer.Age = customer.Age;
            currentCustomer.FirstName = customer.FirstName;
            currentCustomer.LastName = customer.LastName;
            return Ok(currentCustomer);
        }
    }
}