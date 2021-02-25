using System;
using Sample.Helpers;

namespace Sample.Models
{
    public class SampleItem : BaseNotifier
    {
        public SampleItem(string name, Type pageType)
        {
            Name = name;
            PageType = pageType;
        }
        public string Name { get; }

        public Type PageType { get; }
    }
}
