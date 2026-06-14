using System.Collections.Generic;

namespace Additions
{
    public class HudModel
    {
        public List<IObservableData> SubModels { get; } = new();

        public HudModel(params IObservableData[] models)
        {
            if (models != null)
            {
                SubModels.AddRange(models);
            }
        }
    }
}