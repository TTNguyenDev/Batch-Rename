using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiniProject_Batch_Rename
{
    public class Preset
    {
        string _presetName;
        List<IAction> _actions = new List<IAction>();

        public string presetName { get => _presetName; set => _presetName = value; }
        public List<IAction> actions { get => _actions; set => _actions = value; }

        public Preset(string presetName, List<IAction> actions)
        {
            _presetName = presetName;
            _actions = actions;
        }

        public Preset()
        {
            
        }

        public Preset loadPreset(string path)
        {
            string[] lines = File.ReadAllLines(path);
            
            foreach (string line in lines)
            {
                if (line == lines[0])
                {
                    _presetName = line;
                }
                else
                {
                    string[] result = line.Split('~');
                    switch (result[0])
                    {
                        case "replace":
                            _actions.Add(new Replacer() { Args = new ReplaceArgs() { OldFile = result[1], NewFile = result[2] } });
                            break;
                        case "newCase":
                            _actions.Add(new NewCase() { Args = new NewCaseArg() { type = int.Parse(result[1]) } });
                            break;
                        case "move":
                            //default value is 13. config later
                            _actions.Add(new Move() { Args = new MoveArgs() { amount = 13 } });
                            break;
                        case "fullnameNormalize":
                            _actions.Add(new FullNameNormalize() { Args = new FullNameNormalizeArgs() { } });
                            break;
                        case "guid":
                            _actions.Add(new GUIDName() { Args = new GUIDArgs() { } });
                            break;
                    }
                }
            }
            return new Preset(_presetName, _actions);
        }

        public void savePreset(string name, List<IAction> actions)
        {
            _presetName = name;
            _actions = actions;
            var path = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamWriter writer = new StreamWriter(path + _presetName + ".txt"))
            {
                writer.WriteLine(name);

                //_actions[0].Args.ToString();
                foreach (var action in _actions)
                {
                    switch (action.ToString())
                    {
                        case "replace":
                            var replace = action as Replacer;
                            var replaceArgs = replace.Args as ReplaceArgs;
                            writer.WriteLine($"replace~{replaceArgs.OldFile}~{replaceArgs.NewFile}");
                            break;

                        case "newCase":
                            var newCase = action as NewCase;
                            var newCaseArgs = newCase.Args as NewCaseArg;
                            writer.WriteLine($"newCase~{newCaseArgs.type}");
                            break;

                        case "move":
                            var move = action as Move;
                            var moveArgs = move.Args as MoveArgs;
                            writer.WriteLine($"move~{moveArgs.amount}");
                            break;

                        case "fullnameNormalize":
                            writer.WriteLine($"fullnameNormalize");
                            break;

                        case "guid":
                            writer.WriteLine($"guid");
                            break;
                    }
                }

            }
        }


    }
}
