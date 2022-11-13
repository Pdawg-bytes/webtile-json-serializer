using System;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

public class Program
{
    public static void Main()
    {
        var obj = new
        {
            manifestVersion = 1,
            name = "SEA & JFK weather",
            description = "This tile shows the current weather at SEA and JFK",
            version = 1,
            versionString = "1",
            author = "Microsoft Band Team",
            organization = "MS Health",
            contactEmail = "healthms@microsoft.com",
            tileIcon = new Dictionary<int, string>
            {
                [46] = "icons/tileIcon.png"
            },
            badgeIcon = new Dictionary<int, string>
            {
                [24] = "icons/badgeIcon.png",
            },
            icons = new
            {
                SEAIcon = "icons/SEA.png",
                JFKIcon = "icons/JFK.png",
            },
            refreshIntervalMinutes = 30,
            resources = new dynamic[] {
                new {
                    url = "http://services.faa.gov/airport/status/SEA?format=json",
                    style = "Simple",
                    content = new
                    {
                        SEAWeather = "weather.weather",
                        SEAvisibility = "weather.visibility"
                    },
                },
               new {
                    url = "http://services.faa.gov/airport/status/JFK?format=json",
                    style = "Simple",
                    content = new
                    {
                        JFKWeather = "weather.weather",
                        JFKvisibility = "weather.visibility"
                    },
                },
            },
            pages = new dynamic[]
            {
                new {
                    layout = "MSBand_NoScrollingText",
                    condition = "true",
                    textBindings = new []
                    {
                        new
                        {
                            elementId = "1",
                            value = "Airport Weather",
                        },
                        new
                        {
                            elementId = "2",
                            value = "SEA: {{SEAweather}}",
                        },
                        new
                        {
                            elementId = "3",
                            value = "JFK: {{JFKweather}}",
                        },
                    }
                },
                new {
                    layout = "MSBand_SingleMetricWithSecondary",
                    condition = "true",
                    iconBindings = new []
                    {
                        new
                        {
                            elementId = "21",
                            conditions = new[]
                            {
                                new
                                {
                                    condition = "true",
                                    icon = "SEAIcon",
                                },
                            },
                        },
                    },
                    textBindings = new []
                    {
                        new
                        {
                            elementId = "11",
                            value = "SEA",
                        },
                        new
                        {
                            elementId = "12",
                            value = "Visibility",
                        },
                        new
                        {
                            elementId = "22",
                            value = "{{SEAvisibility}}",
                        },
                    },
                },
                  new {
                    layout = "MSBand_SingleMetricWithSecondary",
                    condition = "true",
                    iconBindings = new []
                    {
                        new
                        {
                            elementId = "21",
                            conditions = new[]
                            {
                                new
                                {
                                    condition = "true",
                                    icon = "JFKIcon",
                                },
                            },
                        },
                    },
                    textBindings = new []
                    {
                        new
                        {
                            elementId = "11",
                            value = "JFK",
                        },
                        new
                        {
                            elementId = "12",
                            value = "Visibility",
                        },
                        new
                        {
                            elementId = "22",
                            value = "{{JFKvisibility}}",
                        },
                    },
                  },
                },
        };

        var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        Console.WriteLine(json);
    }
}