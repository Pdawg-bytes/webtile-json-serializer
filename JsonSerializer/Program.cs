using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
public class Program
{
        public static string ResourceType = "Simple";
        public static string TileTitle = "Fake Tile";
        public static string DescriptionTile = "This is a nice tile.";
        public static string AuthorTile = "Pdawg";
        public static string OrgTile = "Microsoft";
        public static string ResourceURL = "https://google.com";
        public static string PageType = "MSBand_ScrollingText";
        public static string TileEmail = "sampleemail@microsoft.com";
        public static int RefreshInt = 30;
        public static string E1 = "real element 1";
        public static string E2 = "real element 2";
        public static string E3 = "real element 3";
        public static string I1 = "real icon 1";
        public static string I2 = "real icon 2";
        public static string I3 = "real icon 3";
        public static string IN1 = "true";
        public static string IN2 = "true";
        public static string IN3 = "true";
        public static string EV1 = "some_binding";
        public static string EV2 = "{{description}}";
        public static string EV3 = "Test";

    public static void Main()
    {
         var model = new ObjectModel
            {
                ManifestVersion = 1,
                Name = TileTitle,
                Description = DescriptionTile,
                Version = 1,
                VersionString = "1",
                Author = AuthorTile,
                Organization = OrgTile,
                ContactEmail = TileEmail,
                TileIcon = new Dictionary<int, string>
                {
                    [46] = "icons/tileIcon.png"
                },
                BadgeIcon = new Dictionary<int, string>
                {
                    [24] = "icons/badgeIcon.png"
                },
                Icons = new Dictionary<string, string>
                {
                    ["iconTest"] = "newIcon1.png"
                },
                RefreshIntervalMinutes = RefreshInt,
                Resources = new List<WebTileResource>
                {
                    new WebTileResource
                    {
                        Url = ResourceURL,
                        Style = ResourceType,
                        Content = new Dictionary<string, string>
                        {
                            ["rssTitle"] = "title",
                            ["rssDesc"] = "description",
                            ["rssPubDate"] = "pubDate"
                        }
                    }
                },
                Pages = new List<PagesResource>
                {
                    new PagesResource
                    {
                        Layout = PageType,
                        Condition = "true",
                        IconBindings = new List<IconBinding>
                        {
                            new IconBinding
                            {
                                ElementId = I1,
                                Conditions = new List<ConditionClass>
                                {
                                    new ConditionClass
                                    {
                                        Condition = IN1,
                                        Icon = I1
                                    }
                                }
                            },
                            new IconBinding
                            {
                                ElementId = I2,
                                Conditions = new List<ConditionClass>
                                {
                                    new ConditionClass
                                    {
                                        Condition = IN2,
                                        Icon = I2
                                    }
                                }
                            },
                            new IconBinding
                            {
                                ElementId = I3,
                                Conditions = new List<ConditionClass>
                                {
                                    new ConditionClass
                                    {
                                        Condition = IN3,
                                        Icon = I3
                                    }
                                }
                            },
                        },
                        TextBindings = new List<TextBinding>
                        {
                            new TextBinding
                            {
                                ElementId = E1,
                                Value = EV1
                            },
                            new TextBinding
                            {
                                ElementId = E2,
                                Value = EV2
                            },
                            new TextBinding
                            {
                                ElementId = E3,
                                Value = EV3
                            }
                        }
                    }
                }
            };
            model.Icons.Add("testing", "fileName");

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore
            });

            Console.WriteLine(json);
    }
}