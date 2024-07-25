using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShared.Entities;

public class Poll
{
    public string Statement { get; set; }

    public List<Option> Options { get; set; } = new()
    {
        new(),
        new(),
        new(),
        new()
    };
}
