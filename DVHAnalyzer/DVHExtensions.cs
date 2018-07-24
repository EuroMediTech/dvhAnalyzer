using System;
using System.Linq;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace DVHAnalyzer
{
  public static class DvhExtensions
  {
    public static DoseValue GetDoseAtVolume(this PlanningItem pitem, Structure structure, double volume, VolumePresentation volumePresentation, DoseValuePresentation requestedDosePresentation)
    {
      if (pitem is PlanSetup)
      {
        return ((PlanSetup)pitem).GetDoseAtVolume(structure, volume, volumePresentation, requestedDosePresentation);
      }
      else
      {
        if (requestedDosePresentation != DoseValuePresentation.Absolute)
          throw new ApplicationException("Only absolute dose supported for Plan Sums");
        DVHData dvh = pitem.GetDVHCumulativeData(structure, DoseValuePresentation.Absolute, volumePresentation, 0.001);
        return DvhExtensions.DoseAtVolume(dvh, volume);
      }
    }
    public static double GetVolumeAtDose(this PlanningItem pitem, Structure structure, DoseValue dose, VolumePresentation requestedVolumePresentation)
    {
      if (pitem is PlanSetup)
      {
        return ((PlanSetup)pitem).GetVolumeAtDose(structure, dose, requestedVolumePresentation);
      }
      else
      {
        DVHData dvh = pitem.GetDVHCumulativeData(structure, DoseValuePresentation.Absolute, requestedVolumePresentation, 0.001);
        return DvhExtensions.VolumeAtDose(dvh, dose.Dose);
      }
    }

    public static DoseValue DoseAtVolume(DVHData dvhData, double volume)
    {
      if (dvhData == null || dvhData.CurveData.Count() == 0)
        return DoseValue.UndefinedDose();
      double absVolume = dvhData.CurveData[0].VolumeUnit == "%" ? volume * dvhData.Volume * 0.01 : volume;
      if (volume < 0.0 || absVolume > dvhData.Volume)
        return DoseValue.UndefinedDose();

      DVHPoint[] hist = dvhData.CurveData;
      for (int i = 0; i < hist.Length; i++)
      {
        if (hist[i].Volume < volume)
          return hist[i].DoseValue;
      }
      return DoseValue.UndefinedDose();
    }

    public static double VolumeAtDose(DVHData dvhData, double dose)
    {
      if (dvhData == null)
        return Double.NaN;

      DVHPoint[] hist = dvhData.CurveData;
      int index = (int)(hist.Length * dose / dvhData.MaxDose.Dose);
      if (index < 0 || index > hist.Length)
        return 0.0; //Double.NaN;
      else
        return hist[index].Volume;
    }
  }
}