using System;
using CleanArchitectureTemplate.Common;

namespace CleanArchitectureTemplate.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}