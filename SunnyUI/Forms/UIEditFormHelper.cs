﻿/******************************************************************************
 * SunnyUI 开源控件库、工具类库、扩展类库、多页面开发框架。
 * CopyRight (C) 2012-2021 ShenYongHua(沈永华).
 * QQ群：56829229 QQ：17612584 EMail：SunnyUI@QQ.Com
 *
 * Blog:   https://www.cnblogs.com/yhuse
 * Gitee:  https://gitee.com/yhuse/SunnyUI
 * GitHub: https://github.com/yhuse/SunnyUI
 *
 * SunnyUI.dll can be used for free under the GPL-3.0 license.
 * If you use this code, please keep this note.
 * 如果您使用此代码，请保留此说明。
 ******************************************************************************
 * 文件名称: UIEditFormHelper.cs
 * 文件说明: 编辑窗体帮助类
 * 当前版本: V3.0
 * 创建日期: 2020-12-28
 *
 * 2020-12-28: V2.2.10 增加文件说明
******************************************************************************/

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;

namespace Sunny.UI
{
    public enum EditType
    {
        Text,
        Integer,
        Double,
        Date,
        DateTime,
        Password
    }

    public class EditInfo
    {
        public string DataPropertyName { get; set; }

        public EditType EditType { get; set; }

        public string Text { get; set; }

        public object Value { get; set; }

        public bool CheckEmpty { get; set; }

        public bool Enabled { get; set; }

        public bool HalfWidth { get; set; }
    }

    public class UIEditOption
    {
        public readonly List<EditInfo> Infos = new List<EditInfo>();

        public readonly ConcurrentDictionary<string, EditInfo> Dictionary = new ConcurrentDictionary<string, EditInfo>();

        public string Text { get; set; } = "编辑";

        public bool AutoLabelWidth { get; set; }

        public int LabelWidth { get; set; } = 180;

        public int ValueWidth { get; set; } = 320;

        public void AddText(string dataPropertyName, string text, string value, bool checkEmpty, bool enabled = true)
        {
            if (Dictionary.ContainsKey(dataPropertyName))
                throw new DuplicateNameException(dataPropertyName + ": 已经存在");

            EditInfo info = new EditInfo()
            {
                DataPropertyName = dataPropertyName,
                EditType = EditType.Text,
                Text = text,
                Value = value,
                CheckEmpty = checkEmpty,
                Enabled = enabled
            };

            Infos.Add(info);
            Dictionary.TryAdd(info.DataPropertyName, info);
        }

        public void AddPassword(string dataPropertyName, string text, string value, bool checkEmpty, bool enabled = true)
        {
            if (Dictionary.ContainsKey(dataPropertyName))
                throw new DuplicateNameException(dataPropertyName + ": 已经存在");

            EditInfo info = new EditInfo()
            {
                DataPropertyName = dataPropertyName,
                EditType = EditType.Password,
                Text = text,
                Value = value,
                CheckEmpty = checkEmpty,
                Enabled = enabled
            };

            Infos.Add(info);
            Dictionary.TryAdd(info.DataPropertyName, info);
        }

        public void AddDouble(string dataPropertyName, string text, double value, bool enabled = true, bool halfWidth = true)
        {
            if (Dictionary.ContainsKey(dataPropertyName))
                throw new DuplicateNameException(dataPropertyName + ": 已经存在");

            EditInfo info = new EditInfo()
            {
                DataPropertyName = dataPropertyName,
                EditType = EditType.Double,
                Text = text,
                Value = value,
                Enabled = enabled,
                HalfWidth = halfWidth
            };

            Infos.Add(info);
            Dictionary.TryAdd(info.DataPropertyName, info);
        }

        public void AddInteger(string dataPropertyName, string text, int value, bool enabled = true, bool halfWidth = true)
        {
            if (Dictionary.ContainsKey(dataPropertyName))
                throw new DuplicateNameException(dataPropertyName + ": 已经存在");

            EditInfo info = new EditInfo()
            {
                DataPropertyName = dataPropertyName,
                EditType = EditType.Integer,
                Text = text,
                Value = value,
                Enabled = enabled,
                HalfWidth = halfWidth
            };

            Infos.Add(info);
            Dictionary.TryAdd(info.DataPropertyName, info);
        }

        public void AddDate(string dataPropertyName, string text, DateTime value, bool enabled = true, bool halfWidth = true)
        {
            if (Dictionary.ContainsKey(dataPropertyName))
                throw new DuplicateNameException(dataPropertyName + ": 已经存在");

            EditInfo info = new EditInfo()
            {
                DataPropertyName = dataPropertyName,
                EditType = EditType.Date,
                Text = text,
                Value = value,
                Enabled = enabled,
                HalfWidth = halfWidth
            };

            Infos.Add(info);
            Dictionary.TryAdd(info.DataPropertyName, info);
        }

        public void AddDateTime(string dataPropertyName, string text, DateTime value, bool enabled = true, bool halfWidth = false)
        {
            if (Dictionary.ContainsKey(dataPropertyName))
                throw new DuplicateNameException(dataPropertyName + ": 已经存在");

            EditInfo info = new EditInfo()
            {
                DataPropertyName = dataPropertyName,
                EditType = EditType.DateTime,
                Text = text,
                Value = value,
                Enabled = enabled,
                HalfWidth = halfWidth
            };

            Infos.Add(info);
            Dictionary.TryAdd(info.DataPropertyName, info);
        }
    }
}
