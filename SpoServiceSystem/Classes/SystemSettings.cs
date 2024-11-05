using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpoServiceSystem.Classes
{
    public class SystemSettings : ApplicationSettingsBase
    {
        [UserScopedSetting, DefaultSettingValue("localhost")]
        public string MySqlServerName
        {
            get { return (string)this["MySqlServerName"]; }
            set { this["MySqlServerName"] = value; Save(); }
        }
        [UserScopedSetting, DefaultSettingValue("Server={0};Database={1};Uid={2};Pwd={3};")]
        public string TemplateStrConnection
        {
            get { return (string)this["TemplateStrConnection"]; }
            set { this["TemplateStrConnection"] = value; Save(); }
        }
        [UserScopedSetting, DefaultSettingValue("KAIT20")]
        public string MySqlDataBaze
        {
            get { return (string)this["MySqlDataBaze"]; }
            set { this["MySqlDataBaze"] = value; Save(); }
        }
        [UserScopedSetting, DefaultSettingValue("kait")]
        public string MySqlUserName
        {
            get { return (string)this["MySqlUserName"]; }
            set { this["MySqlUserName"] = value; Save(); }
        }
        [UserScopedSetting, DefaultSettingValue("kait20_1m")]
        public string MySqlPassword
        {
            get { return (string)this["MySqlPassword"]; }
            set { this["MySqlPassword"] = value; Save(); }
        }
        [UserScopedSetting, DefaultSettingValue("8080")]
        public int Port
        {
            get { return (int)this["Port"]; }
            set { this["Port"] = value; Save(); }
        }

    }
}
