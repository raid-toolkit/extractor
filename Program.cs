﻿using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using CommandLine;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RaidExtractor.Core;
using Raid.Client;
using System.Threading.Tasks;
using CommandLine.Text;

namespace RaidExtractor
{
    static class TaskExtensions
    {
        public static T WaitForResult<T>(this Task<T> task)
        {
            task.Wait();
            return task.Result;
        }
    }
    class Program
    {
        public static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    ProcessDictionaryKeys = true,
                    OverrideSpecifiedNames = false
                },
            },
        };

        public class Options
        {
            [Option('g', "nogui", Required = false, Default = false,
              HelpText = "Run this program without a GUI.")]
            public bool NoGui { get; set; }

            [Option('o', "output", Required = false, Default = "artifacts.json",
              HelpText = "Destination output file name.")]
            public string OutputFile { get; set; }

            [Option('t', "type", Required = false, Default = "json", HelpText = "Output Type: 'json' for JSON file output, 'zip' for ZIP file output.")]
            public string DumpType { get; set; }
        }

        static void RunGUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                RunGUI();
            }
            else
            {
                var parserResult = CommandLine.Parser.Default.ParseArguments<Options>(args);
                parserResult.WithParsed(Run)
                .WithNotParsed(errs =>
                {
                    MessageBox.Show(HelpText.AutoBuild(parserResult), "Usage");
                });
            }
        }

        private static void Run(Options o)
        {
            if (!o.NoGui)
            {
                RunGUI();
                return;
            }

            RaidToolkitClient client = new RaidToolkitClient();
            AccountDump dump;
            try
            {
                client.Connect();
                var accounts = client.AccountApi.GetAccounts().WaitForResult();
                dump = client.AccountApi.GetAccountDump(accounts[0].Id).WaitForResult();
                dump.FileVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an error during Extraction: {ex.Message}");
                return;
            }

            var outFile = o.OutputFile;
            var json = JsonConvert.SerializeObject(dump, Formatting.Indented, SerializerSettings);
            if (o.DumpType.ToLower() == "zip")
            {
                if (!outFile.ToLower().Contains("zip")) outFile += ".zip";
                File.Delete(outFile);

                using (var memoryStream = new MemoryStream())
                {
                    using (ZipArchive archive = ZipFile.Open(outFile, ZipArchiveMode.Create))
                    {
                        var artifactFile = archive.CreateEntry("artifacts.json");

                        using (var entryStream = artifactFile.Open())
                        {
                            using (var streamWriter = new StreamWriter(entryStream))
                            {
                                streamWriter.Write(json);
                            }
                        }
                    }
                }
            }
            else
            {
                if (o.DumpType.ToLower() != "json") Console.WriteLine("Unknown Output type. Outputting file in JSON format.");
                File.WriteAllText(outFile, json);
            }
            Console.WriteLine($"Output file {outFile} has been created.");
        }
    }
}
