using System.Collections.Generic;

namespace B2CLocalizationTool.Service.Abstract
{
    public interface IResultDTO
    {
        public bool IsSuccess { get; set; }
        public string OutputPath { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Warnings { get; set; }
    }
}
