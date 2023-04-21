using System.Collections.Generic;

public interface ITargetManager
{
    public void Select(Planet planets);

    public void SelectMultiple(List<Planet> planets);

    public void DeselectAll();
}