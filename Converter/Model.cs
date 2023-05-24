using System.Collections.ObjectModel;
using System.ComponentModel;
using Flurl.Http;

namespace Converter.Model;

public class Valute
{
    public VPP AUD { get; set; }
    public VPP AZN { get; set; }
    public VPP GBP { get; set; }
    public VPP AMD { get; set; }
    public VPP BYN { get; set; }
    public VPP BGN { get; set; }
    public VPP BRL { get; set; }
    public VPP HUF { get; set; }
    public VPP VND { get; set; }
    public VPP HKD { get; set; }
    public VPP GEL { get; set; }
    public VPP DKK { get; set; }
    public VPP AED { get; set; }
    public VPP USD { get; set; }
    public VPP EUR { get; set; }
    public VPP EGP { get; set; }
    public VPP INR { get; set; }
    public VPP IDR { get; set; }
    public VPP KZT { get; set; }
    public VPP CAD { get; set; }
    public VPP QAR { get; set; }
    public VPP KGS { get; set; }
    public VPP CNY { get; set; }
    public VPP MDL { get; set; }
    public VPP NZD { get; set; }
    public VPP NOK { get; set; }
    public VPP PLN { get; set; }
    public VPP RON { get; set; }
    public VPP XDR { get; set; }
    public VPP SGD { get; set; }
    public VPP TJS { get; set; }
    public VPP THB { get; set; }
    public VPP TRY { get; set; }
    public VPP TMT { get; set; }
    public VPP UZS { get; set; }
    public VPP UAH { get; set; }
    public VPP CZK { get; set; }
    public VPP SEK { get; set; }
    public VPP CHF { get; set; }
    public VPP RSD { get; set; }
    public VPP ZAR { get; set; }
    public VPP KRW { get; set; }
    public VPP JPY { get; set; }
    public VPP RUB { get; set; }

    public IEnumerable<VPP> Valutes
    {
        get
        {
            if (AUD != null) yield return AUD;
            if (AZN != null) yield return AZN;
            if (GBP != null) yield return GBP;
            if (AMD != null) yield return AMD;
            if (BYN != null) yield return BYN;
            if (BGN != null) yield return BGN;
            if (BRL != null) yield return BRL;
            if (HUF != null) yield return HUF;
            if (VND != null) yield return VND;
            if (HKD != null) yield return HKD;
            if (GEL != null) yield return GEL;
            if (DKK != null) yield return DKK;
            if (AED != null) yield return AED;
            if (USD != null) yield return USD;
            if (EUR != null) yield return EUR;
            if (EGP != null) yield return EGP;
            if (INR != null) yield return INR;
            if (IDR != null) yield return IDR;
            if (KZT != null) yield return KZT;
            if (CAD != null) yield return CAD;
            if (QAR != null) yield return QAR;
            if (KGS != null) yield return KGS;
            if (CNY != null) yield return CNY;
            if (MDL != null) yield return MDL;
            if (NZD != null) yield return NZD;
            if (NOK != null) yield return NOK;
            if (PLN != null) yield return PLN;
            if (RON != null) yield return RON;
            if (XDR != null) yield return XDR;
            if (SGD != null) yield return SGD;
            if (TJS != null) yield return TJS;
            if (THB != null) yield return THB;
            if (TRY != null) yield return TRY;
            if (TMT != null) yield return TMT;
            if (UZS != null) yield return UZS;
            if (UAH != null) yield return UAH;
            if (CZK != null) yield return CZK;
            if (SEK != null) yield return SEK;
            if (CHF != null) yield return CHF;
            if (RSD != null) yield return RSD;
            if (ZAR != null) yield return ZAR;
            if (KRW != null) yield return KRW;
            if (JPY != null) yield return JPY;
        }
    }
}
public class VPP
{
    public string ID { get; set; }
    public string NumCode { get; set; }
    public string CharCode { get; set; }
    public int Nominal { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
    public double Previous { get; set; }

    public override string ToString()
    {
        return Name;
    }
}

public class Root
{
    public DateTime Date { get; set; }
    public DateTime PreviousDate { get; set; }
    public string PreviousURL { get; set; }
    public DateTime Timestamp { get; set; }
    public Valute Valute { get; set; }
}

