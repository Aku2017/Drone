﻿using AutoMapper.Execution;
using DroneApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Application.Converters
{
    public static  class EnumUtilConverter
    {
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }

        public static ModelType convertStringValuestoModelTypeEnum(string values)
        {
            ModelType enumValue;
            Enum.TryParse(values, out enumValue);
            return enumValue;
        }

        public static State convertStringValuestoStateTypeEnum(string values)
        {
            State enumValue;
            Enum.TryParse(values, out enumValue);
            return enumValue;
        }

    }
}
