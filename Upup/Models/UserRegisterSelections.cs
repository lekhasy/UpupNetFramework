using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upup.Globalization;

namespace Upup.Models
{
    public class SelectOptions
    {
        public SelectOptions(int value, string display)
        {
            Value = value;
            Display = display;
        }

        public int Value { get; private set; }
        public string Display { get; private set; }
    }

    public enum TypeOfBusinesses
    {
        // Không xác định
        Unknow = 0,
        // Tự động hóa
        Automation = 1,
        // Chế tạo máy
        MachineManufacturing = 2,
        // Sản xuất linh kiện
        ComponentManufacturing = 3,
        // Xưởng gia công
        MachiningWorkshop = 4,
        // Công ty thương mại
        CommerceCompany = 5,
        // Tổ chức giáo dục
        EducationOrganization = 6,
        // Tổ chức chính phủ
        GovernmentOrganization = 7,
        // Khác
        Other = 8
    }

    public static class TypeOfBusinessesExtensions
    {
        private static SelectOptions GetSelectOptions(this TypeOfBusinesses industry)
        {
            var display = string.Empty;            
            switch (industry)
            {
                case TypeOfBusinesses.Unknow:
                    display = Lang.Register_Select;
                    break;
                case TypeOfBusinesses.Automation:
                    display = Lang.Register_Automation;
                    break;
                case TypeOfBusinesses.MachineManufacturing:
                    display = Lang.Register_MachineManufacturing;
                    break;
                case TypeOfBusinesses.ComponentManufacturing:
                    display = Lang.Register_ComponentManufacturing;
                    break;
                case TypeOfBusinesses.MachiningWorkshop:
                    display = Lang.Register_MachiningWorkshop;
                    break;
                case TypeOfBusinesses.CommerceCompany:
                    display = Lang.Register_CommerceCompany;
                    break;
                case TypeOfBusinesses.EducationOrganization:
                    display = Lang.Register_EducationOrganization;
                    break;
                case TypeOfBusinesses.GovernmentOrganization:
                    display = Lang.Register_GovernmentOrganization;
                    break;
                case TypeOfBusinesses.Other:
                    display = Lang.Other;
                    break;
                default:
                    throw new NotImplementedException($"{industry} is not implemented");
            }

            return new SelectOptions((int)industry, display);
        }


        public static IEnumerable<SelectOptions> GetSelectionList()
        {
            var names = Enum.GetNames(typeof(TypeOfBusinesses));
            var options = new List<SelectOptions>(names.Length);
            foreach (var name in names)
            {
                Enum.TryParse(name, out TypeOfBusinesses val);
                options.Add(GetSelectOptions(val));
            }

            return options;
        }
    }

    //Ngành nghề phục vụ chính
    public enum MainServedIndustry
    {
        // --Hãy chọn--
        UnKnow = 0,
        // Ô tô
        Automotive = 1,
        // Hàng không/Quốc phòng
        Aerospace_Defense = 2,
        // Điện tử
        Electronics = 3,
        // Thiết bị ổ cứng
        Hard_Disk_Drive = 4,
        // Màn hình tinh thể lỏng
        Liquid_Crystal_Display = 5,
        // Y tế
        Medical = 6,
        // Thực phẩm/Tiêu dùng
        Food_Consumable = 7,
        // Bán dẫn
        Semiconductor = 8,
        // Khác
        Others = 9
    }

    public static class MainServedIndustryExtensions
    {
        private static SelectOptions GetSelectOptions(this MainServedIndustry servedIndustry)
        {
            var display = string.Empty;
            switch (servedIndustry)
            {
                case MainServedIndustry.UnKnow:
                    display = Lang.Register_Select;
                    break;
                case MainServedIndustry.Automotive:
                    display = Lang.Register_Automotive;
                    break;
                case MainServedIndustry.Aerospace_Defense:
                    display = Lang.Register_Aerospace_Defense;
                    break;
                case MainServedIndustry.Electronics:
                    display = Lang.Register_Electronics;
                    break;
                case MainServedIndustry.Hard_Disk_Drive:
                    display = Lang.Register_Hard_Disk_Drive;
                    break;
                case MainServedIndustry.Liquid_Crystal_Display:
                    display = Lang.Register_Liquid_Crystal_Display;
                    break;
                case MainServedIndustry.Medical:
                    display = Lang.Register_Medical;
                    break;
                case MainServedIndustry.Food_Consumable:
                    display = Lang.Register_Food_Consumable;
                    break;
                case MainServedIndustry.Semiconductor:
                    display = Lang.Register_Semiconductor;
                    break;
                case MainServedIndustry.Others:
                    display = Lang.Other;
                    break;
                default:
                    throw new NotImplementedException($"{servedIndustry} is not implemented");
            }
            return new SelectOptions((int)servedIndustry, display);
        }
        public static IEnumerable<SelectOptions> GetSelectionList()
        {
            var names = Enum.GetNames(typeof(MainServedIndustry));
            var options = new List<SelectOptions>(names.Length);
            foreach (var name in names)
            {
                Enum.TryParse(name, out MainServedIndustry val);
                options.Add(GetSelectOptions(val));
            }

            return options;
        }
    }

    public enum NumberOfDesigner
    {
        Unknow = 0,
        Zero = 1,
        OneToFive = 2,
        SixToTen = 3,
        TenToTwenty = 4,
        TwentyToFifty = 5,
        OverFifty = 6
    }

    public enum NumberOfEmployee
    {
        Unknow = 0,
        OneToTwenty = 1,
        TwentyToFifty = 2,
        FiftyToOneHundred = 3,
        OneToTwoHundred = 4,
        TwoToThreeHundred = 5,
        ThreeToFiveHundred = 6,
        FiveToOneThousand = 7,
        OverOneThousand = 8
    }

    public enum KnowFrom
    {
        Unknow = 0,
        Referrel_Colleagues = 1,
        Referrel_Customers_Business_Partners = 2,
        Magazine_Trade_Publication = 3,
        Internet = 4,
        Exhibition_Seminar = 5,
        Publicity = 6,
        Others = 7
    }

    public static class KnowFromExtensions
    {
        private static SelectOptions GetSelectOptions(this KnowFrom knowFrom)
        {
            var display = string.Empty;

            switch (knowFrom)
            {
                case KnowFrom.Unknow:
                    display = Lang.Register_Select;
                    break;
                case KnowFrom.Referrel_Colleagues:
                    display = Lang.Register_Referrel_Colleagues;
                    break;
                case KnowFrom.Referrel_Customers_Business_Partners:
                    display = Lang.Register_Referrel_Customers_Business_Partners;
                    break;
                case KnowFrom.Magazine_Trade_Publication:
                    display = Lang.Register_Magazine_Trade_Publication;
                    break;
                case KnowFrom.Internet:
                    display = Lang.Register_Internet;
                    break;
                case KnowFrom.Exhibition_Seminar:
                    display = Lang.Register_Exhibition_Seminar;
                    break;
                case KnowFrom.Publicity:
                    display = Lang.Register_Publicity;
                    break;
                case KnowFrom.Others:
                    display = Lang.Other;
                    break;
                default:
                    throw new NotImplementedException($"{knowFrom} is not implemented");
            }

            return new SelectOptions((int)knowFrom, display);
        }
        public static IEnumerable<SelectOptions> GetSelectionList()
        {
            var names = Enum.GetNames(typeof(KnowFrom));
            var options = new List<SelectOptions>(names.Length);
            foreach (var name in names)
            {
                Enum.TryParse(name, out KnowFrom val);
                options.Add(GetSelectOptions(val));
            }

            return options;
        }
    }
}