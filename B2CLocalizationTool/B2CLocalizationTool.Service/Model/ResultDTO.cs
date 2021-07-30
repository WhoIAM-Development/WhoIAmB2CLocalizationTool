using B2CLocalizationTool.Service.Abstract;
using System.Collections.Generic;

namespace B2CLocalizationTool.Service.Model
{
    public class ResultDTO : IResultDTO
    {
        public bool IsSuccess { get; set; }
        public string OutputPath { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Warnings { get; set; }
        public IEnumerable<LocalizationInputModel> LocalizationResources {get;set;}
    }
}
